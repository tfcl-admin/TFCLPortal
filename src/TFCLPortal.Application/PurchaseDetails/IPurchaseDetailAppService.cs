using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.PurchaseDetails.Dto;

namespace TFCLPortal.PurchaseDetails
{
    public interface IPurchaseDetailAppService : IApplicationService
    {
        Task<PurchaseDetailListDto> GetPurchaseDetailById(int Id);
        Task CreatePurchaseDetail(CreatePurchaseDetailDto input);
        Task<string> UpdatePurchaseDetail(UpdatePurchaseDetailDto input);
        Task<PurchaseDetailListDto> GetPurchaseDetailByApplicationId(int ApplicationId);
        bool CheckPurchaseDetailByApplicationId(int ApplicationId);
    }
}
