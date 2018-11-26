//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using System.Linq;
//using DBRepository.Interfaces;
//using ExcelDataReader;
//using Models.Models.DataModels;

//namespace DBRepository.Repository
//{
//    public class FileRepository: BaseRepository, IFileRepository
//    {
//        int currentSubHead = 0, currentSignificative = 0;
//        List<int> years = new List<int>();
//        private RepositoryContext Context { get; }

//        public FileRepository(string connectionString, IRepositoryContextFactory contextFactory, RepositoryContext context) : base(connectionString, contextFactory) { }
//        public async Task UploadTransMonee(IFormFile file)
//        {
//            using (var context = ContextFactory.CreateDbContext(ConnectionString))
//            {
//                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.OpenReadStream()))
//                {
//                    try
//                    {
//                        while (excelReader.Read())
//                        {
//                            string s = ReadCell(excelReader, 1);
//                            string s1 = ReadCell(excelReader, 3);
                            
//                            if (s != null)
//                            {
//                                if (Regex.IsMatch(s, @"^\d.\d "))
//                                {
//                                    try
//                                    {
//                                        Regex pattern = new Regex(@"\d.\d (.*),");
//                                        string str = pattern.Match(s).Groups[1].Value;
//                                        context.Subheadings.Add(new Subheading() { SubheadingName = str, HeadingId = 3 });
//                                        currentSubHead = context.Subheadings.FirstOrDefault(p => p.SubheadingName == str).SubheadingId;
//                                    }
//                                    catch (Exception) { }
//                                }

//                                if (Regex.IsMatch(s, @"^\d.\d.\d "))
//                                {
//                                    try
//                                    {
//                                        Regex pattern = new Regex(@"\d.\d.\d (.*),");
//                                        string str = pattern.Match(s).Groups[1].Value;
//                                        context.Significatives.Add(new Significative() { SignificativeName = str, SubheadingId = currentSubHead });
//                                        currentSignificative = context.Significatives.FirstOrDefault(p => p.SignificativeName == str).SignificativeId;
//                                    }
//                                    catch (Exception) { }
//                                }
                                

//                                if (s1 != null)
//                                {
//                                    ReadValues(excelReader, context, s);
//                                }
//                            }
//                            else
//                            {
//                                if (s1 != null)
//                                {
//                                    ReadYears(excelReader);
//                                }
//                            }
//                        }
//                        await context.SaveChangesAsync();
//                    }
//                    catch (Exception) { }
//                }
//            }
//        }

//        private void ReadValues(IExcelDataReader reader, RepositoryContext context, string country)
//        {
//            try
//            {
//                var significative = context.Significatives.FirstOrDefault(p => p.SignificativeId == currentSignificative);
//                for (int i = 3; i < reader.FieldCount; ++i)
//                {
//                    significative.ElementOfSectionSignificates.Add(
//                        new ElementOfSectionSignificate
//                        {
//                            SignificativeId = currentSignificative,
//                            Count = float.Parse(reader.GetValue(i).ToString()),
//                            ElementOfsectionId = context.ElementOfSections.FirstOrDefault(
//                                p => p.ElementOfSectionName == years[i - 3].ToString()
//                                ).ElementOfSectionId,
//                            CountryId = context.Countries.FirstOrDefault(p => p.CountryName == country).CountryId
//                        });
//                }
//            }
//            catch (Exception) { }
//        }

//        private void ReadYears(IExcelDataReader reader)
//        {
//            try
//            {
//                for (int i = 3; i < reader.FieldCount; ++i)
//                {
//                    int year = int.Parse(new Regex(@"\d\d$").Match(reader.GetString(i)).Value);
//                    if (year > 90)
//                    {
//                        years.Add(1900 + year);
//                    }
//                    else
//                    {
//                        years.Add(2000 + year);
//                    }
//                }
//            }
//            catch (Exception) { }
//        }

//        private string ReadCell(IExcelDataReader reader, int row)
//        {
//            string s;
//            try
//            {
//                s = reader.GetValue(1).ToString();
//            }
//            catch (Exception) { s = null; }
//            return s;
//        }

//        public async Task UploadCountry(IFormFile file)
//        {
//            using (var context = ContextFactory.CreateDbContext(ConnectionString))
//            {
//                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.OpenReadStream()))
//                {
//                    try
//                    {
//                        excelReader.NextResult();
//                        excelReader.Read();
//                        excelReader.Read();
//                        while (excelReader.Read())
//                        {
//                            context.Countries.Add(new Country() { CountryName = excelReader.GetString(1) });
//                        }
//                        await context.SaveChangesAsync();
//                    }
//                    catch (Exception) { }
//                }
//            }
//        }
//    }
//}
