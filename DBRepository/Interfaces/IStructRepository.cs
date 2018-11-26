using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Models.Models.DataModels;
using Models.Models.StructModels;

namespace DBRepository.Interfaces
{
    public interface IStructRepository
    {
        List<Heading> GetStruct();
        Task AddSubheading(string subheadName, int subheadHeadId);
        Task UpdateSubheading(int subheadId, string subheadName, int subheadHeadId);
        Task AddSignifficative(string significativeName, int significativeId);
        Task UpdateSignificative(int significativeId, string significativeName, int subheadId);
        Task AddDimension(string dimensionName, int dimensionParrent);
        Task<List<Dimension>> GetAllMainDimensions();
        Task<Dictionary<int, AllStructValueObject>> GetAllDimensions();
    }
}
