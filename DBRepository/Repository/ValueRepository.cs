using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Models.Models.DataModels;
using Models.Models.ValueModels;

namespace DBRepository.Repository
{
    public class ValueRepository:IValueRepository
    {
        private List<Country> Countries { get; set; }
        private List<ElementOfSection> ElementOfSections { get; set; }
        private List<ElementOfSectionSignificate> ElementOfSectionSignificates { get; set; }
        private RepositoryContext Context { get; }
        public ValueRepository(RepositoryContext context)
        {
            Context = context;

        }
        
        public TestValuesModel GetSignificatives(int singificativeId)
        {
            List<TestValues> testValues = new List<TestValues>();
            try
            {
                Countries = Context.Countries.ToList();
                ElementOfSections = Context.ElementOfSections
                    .Join(Context.ElementOfSectionSignificates,
                    sign => sign.ElementOfSectionId,
                    el => el.ElementOfSectionId,
                    (el, sign) => el)
                    .GroupBy(x => x.ElementOfSectionName)
                    .Select(x => x.FirstOrDefault())
                    .ToList();
                ElementOfSectionSignificates = Context.ElementOfSectionSignificates.Where(x => x.SignificativeId == singificativeId).ToList();
                foreach (var record in ElementOfSectionSignificates)
                {
                    testValues.Add(new TestValues
                    {
                        Value = record.Count,
                        Country = Countries.FirstOrDefault(x => x.CountryId == record.CountryId).CountryName,
                        ElementOfSection = ElementOfSections.FirstOrDefault(x => x.ElementOfSectionId == record.ElementOfSectionId).ElementOfSectionName
                    });
                }
            }
            catch(Exception e)
            {

            }
            return new TestValuesModel
            {
                Countries = Countries.Select(x => x.CountryName).ToList(),
                Years = ElementOfSections.Select(x => x.ElementOfSectionName).ToList(),
                TestValues = testValues
            };
        }
    }
}
