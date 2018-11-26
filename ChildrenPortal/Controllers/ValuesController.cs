using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBRepository.Interfaces;
using Models.Models.ValueModels;
using Models.Models.DataModels;

namespace ChildrenPortal.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       
        IValueRepository Values { get; }
        public ValuesController(IValueRepository values)
        {
            Values = values;
        }
        [HttpPost]
        public ActionResult<TestValuesModel> GetTestValue([FromBody]int significativeId)
        {
            TestValuesModel list = Values.GetSignificatives(significativeId);
            return Ok(list);
        }

        
    }
}
