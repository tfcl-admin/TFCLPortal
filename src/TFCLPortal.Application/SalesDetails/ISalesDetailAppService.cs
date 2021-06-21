using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.SalesDetails.Dto;

namespace TFCLPortal.SalesDetails
{
    public interface ISalesDetailAppService : IApplicationService
    {
        Task<SalesDetailListDto> GetSalesDetailById(int Id);
        Task CreateSalesDetail(CreateSalesDetailDto input);
        Task<string> UpdateSalesDetail(UpdateSalesDetailDto input);
        Task<SalesDetailListDto> GetSalesDetailByApplicationId(int ApplicationId);
        bool CheckSalesDetailByApplicationId(int ApplicationId);
    }
}
