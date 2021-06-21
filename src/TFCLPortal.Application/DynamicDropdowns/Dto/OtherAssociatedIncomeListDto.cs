using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(OtherAssociatedIncome))]
    public class OtherAssociatedIncomeListDto : Entity
    {
        public string Name { get; set; }
    }
}
