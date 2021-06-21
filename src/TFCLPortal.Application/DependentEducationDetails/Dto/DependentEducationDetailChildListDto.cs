using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DependentEducationDetails.Dto
{
    [AutoMapFrom(typeof(DependentEducationDetailChild))]
    public class DependentEducationDetailChildListDto : Entity<int>
    {
        public int FK_DependentEducationId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string dependentClass { get; set; }
        public string EiName { get; set; }
        public string MonthlyFee { get; set; }
        public int PaymentFrequency { get; set; }
        public string PaymentFrequencyName { get; set; }
    }
}
