using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Models.ValueModels;

namespace DBRepository.Interfaces
{
    public interface IValueRepository
    {
        TestValuesModel GetSignificatives(int significativeId);
    }
}
