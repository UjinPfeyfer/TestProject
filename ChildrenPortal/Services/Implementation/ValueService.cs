using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenPortal.Services.Interfaces;
using DBRepository.Interfaces;
using Models.Models.ValueModels;

namespace ChildrenPortal.Services.Implementation
{
    public class ValueService: IValueService
    {
        IValueRepository ValueRepository { get; }
        public ValueService(IValueRepository valueRepository)
        {
            ValueRepository = valueRepository;
        }

        public TestValuesModel GetSignificatives(int significativeId)
        {
            return ValueRepository.GetSignificatives(significativeId);
        }
    }
}
