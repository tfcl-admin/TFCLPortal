using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.BaloonPayments.Dto;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.BaloonPayments
{
    public class BaloonPaymentAppService : TFCLPortalAppServiceBase, IBaloonPaymentAppService
    {
        private readonly IRepository<BaloonPayment, Int32> _BaloonPaymentRepository;
        private string BaloonPayment = "Business Plan";
        public BaloonPaymentAppService(IRepository<BaloonPayment, Int32> BaloonPaymentRepository)
        {
            _BaloonPaymentRepository = BaloonPaymentRepository;
         
        }

        public async Task<string> CreateBaloonPayment(CreateBaloonPaymentDto input)
        {
            string ResponseString = "";
            try
            {
                var BaloonPayments = ObjectMapper.Map<BaloonPayment>(input);
                _BaloonPaymentRepository.Insert(BaloonPayments);
                CurrentUnitOfWork.SaveChanges();

                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", BaloonPayment));

            }
        }

        public async Task<BaloonPaymentListDto> GetBaloonPaymentById(int Id)
        {
            try
            {
                var BaloonPayments = await _BaloonPaymentRepository.GetAsync(Id);

                return ObjectMapper.Map<BaloonPaymentListDto>(BaloonPayments);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BaloonPayment));
            }
        }

        public async Task<string> UpdateBaloonPayment(UpdateBaloonPaymentDto input)
        {
            string ResponseString = "";
            try
            {
                var BaloonPayments = _BaloonPaymentRepository.Get(input.Id);
                if (BaloonPayments != null && BaloonPayments.Id > 0)
                {
                    ObjectMapper.Map(input, BaloonPayments);
                    await _BaloonPaymentRepository.UpdateAsync(BaloonPayments);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", BaloonPayment));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", BaloonPayment));
            }
        }

        public async Task<List<BaloonPaymentListDto>> GetBaloonPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var BaloonPayments = _BaloonPaymentRepository.GetAllList(x => x.ApplicationId == ApplicationId);
                var BaloonPaymentz = ObjectMapper.Map<List<BaloonPaymentListDto>>(BaloonPayments);
              
                return BaloonPaymentz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BaloonPayment));
            }
        }
        public async Task<BaloonPaymentListDto> GetBaloonPaymentByApplicationIdFirst(int ApplicationId)
        {
            try
            {
                var BaloonPayments = _BaloonPaymentRepository.GetAllList(x => x.ApplicationId == ApplicationId && x.isPaid==false).FirstOrDefault();
                var BaloonPaymentz = ObjectMapper.Map<BaloonPaymentListDto>(BaloonPayments);

                return BaloonPaymentz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BaloonPayment));
            }
        }

        public bool CheckBaloonPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var BaloonPayments = _BaloonPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (BaloonPayments != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BaloonPayment));
            }

        }
    }
}
