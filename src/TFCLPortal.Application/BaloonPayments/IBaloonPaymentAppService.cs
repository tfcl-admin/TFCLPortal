using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BaloonPayments.Dto;

namespace TFCLPortal.BaloonPayments
{
    public interface IBaloonPaymentAppService : IApplicationService
    {
        Task<BaloonPaymentListDto> GetBaloonPaymentById(int Id);
        Task<string> CreateBaloonPayment(CreateBaloonPaymentDto input);
        Task<string> UpdateBaloonPayment(UpdateBaloonPaymentDto input);
        Task<List<BaloonPaymentListDto>> GetBaloonPaymentByApplicationId(int ApplicationId);
        Task<BaloonPaymentListDto> GetBaloonPaymentByApplicationIdFirst(int ApplicationId);
        bool CheckBaloonPaymentByApplicationId(int ApplicationId);
    }
}
