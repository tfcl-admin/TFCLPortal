using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS.Dto;

namespace TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS
{
    public interface ISalesPurchaseTDSAppService : IApplicationService
    {
        Task<SalesPurchaseTDSListDto> GetSalesPurchaseTDSById(int Id);
        Task CreateSalesPurchaseTDS(CreateSalesPurchaseTDSDto input);
        Task<string> UpdateFinancialInformationTDSTDS(UpdateSalesPurchaseTDSDto input);
        SalesPurchaseTDSListDto GetSalesPurchaseTDSByApplicationId(int ApplicationId);
    }
}
