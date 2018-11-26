using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChildrenPortal.Services.Interfaces;
using Models.Models.DataModels;
using Models.Models.StructModels;

namespace ChildrenPortal.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StructController : ControllerBase
    {
        private IStructService DataService { get; }
        public StructController(IStructService dataService)
        {
            DataService = dataService;
        }
        [HttpGet]
        public IEnumerable<Heading> GetStruct()
        {
            List<Heading> head = DataService.GetStruct();
            return head;
        }

        [HttpPost]
        public async Task AddSignificative(AddStructNameParent addStruct)
        {
            await DataService.AddSignifficative(addStruct.Name, addStruct.ParentId);
        }

        public async Task AddSubheading(AddStructNameParent addStruct)
        {
            await DataService.AddSubheading(addStruct.Name, addStruct.ParentId);
        }

        public async Task UpdateSubheading(UpdateStructNameParent updateStruct)
        {
            await DataService.UpdateSubheading(updateStruct.Id, updateStruct.Name, updateStruct.ParentId);
        }

        public async Task UpdateSignificative(UpdateStructNameParent updateStruct)
        {
            await DataService.UpdateSignificative(updateStruct.Id, updateStruct.Name, updateStruct.ParentId);
        }

        public async Task AddDimension(AddStructNameParent addDimention)
        {
            await DataService.AddDimension(addDimention.Name, addDimention.ParentId);
        }

        public async Task<ActionResult<IEnumerable<Dimension>>> GetAllMainDimensions()
        {
            List<Dimension> list = await DataService.GetAllMainDimensions();
            return Ok(list);
        }


        public async Task<ActionResult<IEnumerable<AllStructModel>>> GetAllDimensions()
        {
            Dictionary<int, AllStructValueObject> list = await DataService.GetAllDimensions();
            return Ok(list);
        }
    }
}