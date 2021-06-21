using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.Banks;
using TFCLPortal.DynamicDropdowns.AcademicSessions;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(Bank))]
    public class BankListDto : Entity
    {
        public string Name { get; set; }
    }
}
