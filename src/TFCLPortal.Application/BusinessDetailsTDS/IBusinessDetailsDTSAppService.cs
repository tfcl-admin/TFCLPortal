using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessDetailsTDS.Dto;

namespace TFCLPortal.BusinessDetailsTDS
{
    public interface IBusinessDetailsTDSAppService : IApplicationService
    {
        Task<BusinessDetailTDSListDto> GetBusinessDetailTDSById(int Id);
        Task CreateBusinessDetailTDS(CreateParentBusinessDetailTDSDto input);
        Task<string> UpdateBusinessDetailTDS(UpdateBusinessDetailTDSDto input);
        Task<ParentBusinessDetailTDSListDto> GetBusinessDetailTDSByApplicationId(int ApplicationId);
        bool CheckBusinessDetailTDSByApplicationId(int ApplicationId);
    }
}
