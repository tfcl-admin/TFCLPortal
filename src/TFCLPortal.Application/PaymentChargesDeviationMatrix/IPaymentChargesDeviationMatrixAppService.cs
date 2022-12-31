using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.PaymentChargesDeviationMatrix.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.PaymentChargesDeviationMatrix
{
    public interface IPaymentChargesDeviationMatrixAppService : IApplicationService
    {
        PaymentChargesValues GetPaymentChargesDeviationMatrixByApplicationId(int ApplicationId, bool isOldRequired, bool isLoanAmountGiven, double loanamountgiven);
        Task<List<PaymentChargesDeviationMatrixListDto>> GetAllPaymentChargesDeviationMatrixList();

    }
}
