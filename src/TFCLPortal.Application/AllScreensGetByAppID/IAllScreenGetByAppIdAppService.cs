using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AllScreensGetByAppID.Dto;

namespace TFCLPortal.AllScreensGetByAppID
{
    public interface IAllScreenGetByAppIdAppService : IApplicationService
    {
        Task<AllScreenGetByAppIdDto> AllScreenGetByApplicationId(int ApplicationId);
        //Task<List<AllScreenGetByAppIdDto>> AllScreenGetBySdeId(int SDE_Id);
        Task<AllScreenGetBySDEidDto> AllScreenGetBySdeId(int SDE_Id);
        Task<AllScreenGetBySDEidDto> AllScreenGetBySdeIdImproved(int SDE_Id);
        Task<AllScreenGetBySDEidDto> AllScreenGetBySdeIdImprovedTaggedPortfolio(int SDE_Id);
        Task<GetDataForCRSdto> getDataForCRS(int ApplicationId);


        Task<List<LoanStatusDto>> getUpdatedStatus();
        Task<string> getUpdatedStatusAndInsert();
    }
}
