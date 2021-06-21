using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(OtherSourceOfIncome))]
    public class OtherSourceOfIncomeListDto : Entity
    {
        public string Name { get; set; }
    }
}
