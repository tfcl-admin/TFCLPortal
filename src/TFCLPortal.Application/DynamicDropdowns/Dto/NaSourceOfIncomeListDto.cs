using Abp.AutoMapper;
using TFCLPortal.DynamicDropdowns.NaSourceOfIncomes;
using Abp.Domain.Entities;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(NaSourceOfIncome))]
    public class NaSourceOfIncomeListDto : Entity
    {
        public string Name { get; set; }
    }


}
