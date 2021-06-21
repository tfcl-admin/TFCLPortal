using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessDetails.Dto;

namespace TFCLPortal.BusinessDetails
{
    public interface IBusinessDetailsAppService :IApplicationService
    {
        Task<BusinessDetailDto> GetBusinessDetailById(int Id);

        Task  <List<School_Branch>> GetSchoolBranches(int FK_BusinessDetailId);
        Task CreateBusinessDetail(CreateBusinessDetailDto input);
        Task<string> UpdateBusinessDetail(UpdateBusinessDetailDto input);
        Task<BusinessDetailDto> GetBusinessDetailByApplicationId(int ApplicationId);
        bool CheckBusinessDetailByApplicationId(int ApplicationId);
    }
}
