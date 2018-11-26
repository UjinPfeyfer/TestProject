using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models.DataModels;
using Models.Models.StructModels;


namespace ChildrenPortal.Services.Interfaces
{
    public interface IStructService
    {
        List<Heading> GetStruct();
        Task AddSubheading(string subheadName, int subheadHeadId);
        Task UpdateSubheading(int subheadId, string subheadName, int subheadHeadId);
        Task AddSignifficative(string significativeName, int ssignificativeId);
        Task UpdateSignificative(int significativeId, string significativeName, int subheadId);
        Task AddDimension(string dimensionName, int dimensionParrent);
        Task<List<Dimension>> GetAllMainDimensions();
        Task<Dictionary<int, AllStructValueObject>> GetAllDimensions();
    }
}
