using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessIncomeSchools;

namespace TFCLPortal.BusinessIncomes.Dto
{
    [AutoMapTo(typeof(BusinessIncome))]
    public class UpdateBusinessIncomeDto : Entity<int>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        
        public string TotalFeeCollection { get; set; }
        public string AnyOtherIncome { get; set; }
        public string GrandTotalIncome { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string OtherSourceOfFund { get; set; }
        public List<UpdateBusinessChildDto> updatebusinesschild { get; set; }
    }
}
