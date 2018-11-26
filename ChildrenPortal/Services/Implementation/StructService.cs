using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Models.Models.DataModels;
using Models.Models.StructModels;
using ChildrenPortal.Services.Interfaces;

namespace ChildrenPortal.Services.Implementation
{
    public class StructService : IStructService
    {
        IStructRepository StructRepository { get; }
        public StructService(IStructRepository structRepository)
        {
            StructRepository = structRepository;
        }

        public List<Heading> GetStruct()
        {
            return StructRepository.GetStruct();
        }

        public async Task AddSubheading(string subheadName, int subheadHeadId)
        {
            await StructRepository.AddSubheading(subheadName, subheadHeadId);
        }
        public async Task UpdateSubheading(int subheadId, string subheadName, int subheadHeadId)
        {
            await StructRepository.UpdateSubheading(subheadId, subheadName, subheadHeadId);
        }
        public async Task AddSignifficative(string significativeName, int significativeId)
        {
            await StructRepository.AddSignifficative(significativeName, significativeId);
        }
        public async Task UpdateSignificative(int significativeId, string significativeName, int subheadId)
        {
            await StructRepository.UpdateSignificative(significativeId, significativeName, subheadId);
        }

        public async Task AddDimension(string dimensionName, int dimensionParrent)
        {
            await StructRepository.AddDimension(dimensionName, dimensionParrent);
        }
        public async Task<List<Dimension>> GetAllMainDimensions()
        {
            return await StructRepository.GetAllMainDimensions();
        }
        public async Task<Dictionary<int, AllStructValueObject>> GetAllDimensions()
        {
            return await StructRepository.GetAllDimensions();
        }
    }
}
