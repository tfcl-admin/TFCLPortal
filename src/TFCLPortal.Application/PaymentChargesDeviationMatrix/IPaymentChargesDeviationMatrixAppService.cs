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
        decimal GetPaymentChargesDeviationMatrixByApplicationId(int ApplicationId);
        Task<List<PaymentChargesDeviationMatrixListDto>> GetAllPaymentChargesDeviationMatrixList();

    }
}
