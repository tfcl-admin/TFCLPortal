using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AuthorizeInstallmentPayments.Dto;

namespace TFCLPortal.AuthorizeInstallmentPayments
{
   public interface IAuthorizeInstallmentPaymentAppService : IApplicationService
    {
        Task<string> Create(CreateAuthorizeInstallmentPayment createAuthorizeInstallmentPayment);
        Task<string> Update(EditAuthorizeInstallmentPayment editAuthorizeInstallmentPayment);
        Task<AuthorizeInstallmentPaymentListDto> GetAuthorizeInstallmentPaymentById(int Id);
        Task<List<AuthorizeInstallmentPaymentListDto>> GetAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
        Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
        Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPayments();
        bool CheckAuthorizeInstallmentPaymentByApplicationId(int ApplicationId);
    }
}
