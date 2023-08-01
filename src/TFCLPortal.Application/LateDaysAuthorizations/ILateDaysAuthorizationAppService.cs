using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AuthorizeInstallmentPayments.Dto;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.LateDaysAuthorizations.Dto;

namespace TFCLPortal.LateDaysAuthorizations
{
   public interface ILateDaysAuthorizationAppService : IApplicationService
    {
       int CreateLateDaysAuthorization(CreateLateDaysAuthorization createLateDaysAuthorization);
        List<LateDaysAuthorizationListDto> GetLateDaysUnAuthorizedList();
        Task<string> EditLateDaysAuthorization(EditLateDaysAuthorization editLateDaysAuthorization);
        //Task<AuthorizeInstallmentPaymentListDto> GetAuthorizeInstallmentPaymentById(int Id);
        //Task<List<AuthorizeInstallmentPaymentListDto>> GetAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
        //Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
        //Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPayments();

        //Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentsUnAuthorized();

        //Task<string> DeductInstallmentPayment(CreateInstallmentPayment payment);
        //Task<string> DeductInstallmentPaymentRevised(CreateInstallmentPayment payment);
        //bool CheckAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
        //bool InstallmentPayment(CreateAuthorizeInstallmentPayment payment);
    }
}
