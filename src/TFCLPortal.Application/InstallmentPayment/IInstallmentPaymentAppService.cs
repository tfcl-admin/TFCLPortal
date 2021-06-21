using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.InstallmentPayments.Dto;

namespace TFCLPortal.InstallmentPayments
{
   public interface IInstallmentPaymentAppService : IApplicationService
    {
        Task<string> Create(CreateInstallmentPayment createInstallmentPayment);
        Task<string> Update(EditInstallmentPayment editInstallmentPayment);
        Task<InstallmentPaymentListDto> GetInstallmentPaymentById(int Id);
        Task<List<InstallmentPaymentListDto>> GetInstallmentPaymentByApplicationId(int ApplicationId);
        Task<List<InstallmentPaymentListDto>> GetAllInstallmentPaymentByApplicationId(int ApplicationId);
        Task<List<InstallmentPaymentListDto>> GetAllInstallmentPayments();
        bool CheckInstallmentPaymentByApplicationId(int ApplicationId);
    }
}
