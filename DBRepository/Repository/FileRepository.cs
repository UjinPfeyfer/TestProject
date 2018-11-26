using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DBRepository.Interfaces;
using ExcelDataReader;
using Models.Models.DataModels;
using FastMember;

namespace DBRepository.Repository
{
    public class FileRepository: BaseRepository, IFileRepository
    {
        int currentSubHead, currentSignificative, currentHeading = 4;
        List<int> years = new List<int>();
        Dictionary<string, int> headings = new Dictionary<string, int>();
        Dictionary<string, int> countries = new Dictionary<string, int>();
        Dictionary<string, int> significates = new Dictionary<string, int>();
        Dictionary<string, int> subheadings = new Dictionary<string, int>();
        ElementOfSectionSignificates elements = new ElementOfSectionSignificates();
        
        private RepositoryContext Context { get; }

        public FileRepository(string connectionString, IRepositoryContextFactory contextFactory, RepositoryContext context) : base(connectionString, contextFactory)
        {
            Context = context;
        }
        public async Task UploadTransMonee(IFormFile file)
        {
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.OpenReadStream()))
            {
                try
                {
                    ReadStartData();
                    while (excelReader.Read())
                    {
                        string firstRowData = ReadCell(excelReader, 1);

                        if (firstRowData != null)
                        {
                            if (Regex.IsMatch(firstRowData, @"^\d.\d+ "))
                            {
                                FindSubheading(excelReader, firstRowData);
                            }

                            if (Regex.IsMatch(firstRowData, @"^\d.\d.\d+ "))
                            {
                                FindSignificative(firstRowData);
                            }

                            if (countries.ContainsKey(firstRowData))
                            {
                                await ReadValues(excelReader, firstRowData);
                            }
                        }
                        
                        if (excelReader.Depth % 5000 == 0 || excelReader.Depth == excelReader.RowCount - 1)
                        {
                            WriteInBaseFast();
                        }
                    }
                    await Context.SaveChangesAsync();
                }
                catch (Exception e) { }

            }
            
        }

        private async Task ReadValues(IExcelDataReader reader, string country)
        {
            try
            {
                for (int i = 3; i < reader.FieldCount; ++i)
                {
                    try
                    {
                        var a = reader.GetValue(i);
                        if (a == null || a.ToString() == "-")
                        {
                            continue;
                        }
                        float co = float.Parse(a.ToString());
                        elements.Add(

                            new ElementOfSectionSignificate
                            {
                                SignificativeId = currentSignificative,
                                Count = co,
                                ElementOfSectionId = i + 7, // костыль
                                CountryId = countries[country]
                            });
                    }
                    catch (Exception e) { }
                }
            }
            catch (Exception e) { }
        }

        private string ReadCell(IExcelDataReader reader, int row)
        {
            var s = reader.GetValue(row);
            if (s == null)
                return null;
            return s.ToString();
        }

        public async Task UploadCountry(IFormFile file)
        {
            using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.OpenReadStream()))
            {
                try
                {
                    excelReader.NextResult();
                    excelReader.Read();
                    excelReader.Read();
                    while (excelReader.Read())
                    {
                        Context.Countries.Add(new Country() { CountryName = excelReader.GetString(1) });
                    }
                    await Context.SaveChangesAsync();
                }
                catch (Exception e) { }
            }
        }

        private void ReadCountry()
        {
            countries = Context.Countries.ToDictionary(t=>t.CountryName, t=>t.CountryId);
        }

        private void ReadSignificate()
        {
            significates = Context.Significatives.ToDictionary(t => t.SignificativeName, t => t.SignificativeId);
        }

        private void ReadSubheading()
        {
            subheadings = Context.Subheadings
                .Select(x => new Subheading { SubheadingName = x.SubheadingName, SubheadingId = x.SubheadingId })
                .Where(x => x.SubheadingName != "Общие показатели")
                .ToDictionary(t => t.SubheadingName, t => t.SubheadingId);
        }

        private void ReadHeading()
        {
            headings = Context.Headings
                .ToDictionary(t => t.HeadingName, t => t.HeadingId);
        }

        private string GetNormalString(string pattern, string numString)
        {
            Regex pat = new Regex(pattern);
            return pat.Match(numString).Groups[1].Value;
        }

        private void ReadStartData()
        {
            ReadHeading();
            ReadCountry();
            ReadSignificate();
            ReadSubheading();
        }

        private void FindSubheading(IExcelDataReader excelReader, string s)
        {
            try
            {
                string s2 = ReadCell(excelReader, 0);
                if (s2 != null)
                {
                    string head = GetNormalString(@"^\d+ (.*)", s2);

                    if (headings.ContainsKey(head))
                    {
                        currentHeading = headings[head];
                    }
                    else
                    {
                        var heiding = new Heading() { HeadingName = head };
                        Context.Headings.Add(heiding);
                        Context.SaveChanges();
                        headings.Add(head, heiding.HeadingId);
                        currentHeading = heiding.HeadingId;
                    }
                }
                string str = GetNormalString(@"^\d.\d+ (.*)", s);
                if (str == "Общие показатели")
                {
                    var tempSubhead = Context.Subheadings
                        .Select(x => new Subheading { SubheadingId = x.SubheadingId, SubheadingName = x.SubheadingName, HeadingId = x.HeadingId })
                        .Where(x => x.SubheadingName == str && x.HeadingId == currentHeading).FirstOrDefault();
                    if (tempSubhead == null)
                    {
                        var subh = new Subheading() { SubheadingName = str, HeadingId = currentHeading };
                        Context.Subheadings.Add(subh);
                        currentSubHead = subh.SubheadingId;
                    }
                    else
                    {
                        currentSubHead = tempSubhead.SubheadingId;
                    }
                }
                else
                {
                    if (subheadings.ContainsKey(str))
                    {
                        currentSubHead = subheadings[str];
                    }
                    else
                    {
                        var subh = new Subheading() { SubheadingName = str, HeadingId = currentHeading };
                        Context.Subheadings.Add(subh);
                        Context.SaveChanges();
                        subheadings.Add(str, subh.SubheadingId);
                        currentSubHead = subh.SubheadingId;
                    }
                }
            }
            catch (Exception e) { }
        }

        private void FindSignificative(string firstRowData)
        {
            try
            {
                string str = GetNormalString(@"\d.\d.\d+ (.*)", firstRowData);
                if (significates.ContainsKey(str))
                {
                    currentSignificative = significates[str];
                }
                else
                {
                    var sign = new Significative() { SignificativeName = str, SubheadingId = currentSubHead };
                    Context.Significatives.Add(sign);
                    Context.SaveChanges();
                    significates.Add(str, sign.SignificativeId);
                    currentSignificative = sign.SignificativeId;
                }
            }
            catch (Exception e) { }
        }

        private void WriteInBaseFast()
        {
            using (IDataReader reader = ObjectReader.Create(elements))
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                conn.Open();
                bulkCopy.DestinationTableName = "[ElementOfSectionSignificates]";
                bulkCopy.ColumnMappings.Add("SignificativeId", "SignificativeId");
                bulkCopy.ColumnMappings.Add("Count", "Count");
                bulkCopy.ColumnMappings.Add("ElementOfSectionId", "ElementOfSectionId");
                bulkCopy.ColumnMappings.Add("CountryId", "CountryId");
                bulkCopy.WriteToServer(reader);
                elements.Clear();
            }
        }
    }
}
