using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models.ValueModels;

namespace ChildrenPortal.Services.Interfaces
{
    public interface IValueService
    {
        TestValuesModel GetSignificatives(int significativeId);
    }
}
