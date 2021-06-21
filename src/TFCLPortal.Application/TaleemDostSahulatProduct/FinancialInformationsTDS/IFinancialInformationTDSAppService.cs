using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS.Dto;

namespace TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS
{
    public interface IFinancialInformationTDSAppService : IApplicationService
    {
        Task<FinancialInformationTDSListDto> GetFinancialInformationTDSById(int Id);
        Task CreateFinancialInformationTDSTDS(CreateFinancialInformationTDSDto input);
        Task<string> UpdateFinancialInformationTDSTDS(UpdateFinancialInformationTDSDto input);
        FinancialInformationTDSListDto GeFinancialInformationTDSByApplicationId(int ApplicationId);
    }
}
