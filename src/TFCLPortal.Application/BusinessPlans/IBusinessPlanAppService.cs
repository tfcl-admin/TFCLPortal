using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessPlans.Dto;

namespace TFCLPortal.BusinessPlans
{
    public interface IBusinessPlanAppService : IApplicationService
    {
        Task<BusinessPlanListDto> GetBusinessPlanById(int Id);
        Task<string> CreateBusinessPlan(CreateBusinessPlanDto input);
        Task<string> UpdateBusinessPlan(UpdateBusinessPlanDto input);
        Task<BusinessPlanListDto> GetBusinessPlanByApplicationId(int ApplicationId);
        bool CheckBusinessPlanByApplicationId(int ApplicationId);
    }
}
