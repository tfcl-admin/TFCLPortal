using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.Genders;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;
using TFCLPortal.DynamicDropdowns.Qualifications;
using TFCLPortal.DynamicDropdowns.SpouseStatuses;
using TFCLPortal.EarlySettlements.Dto;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.PaymentChargesDeviationMatrix.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.PaymentChargesDeviationMatrix
{
    public class PaymentChargesDeviationMatrixAppService : TFCLPortalAppServiceBase, IPaymentChargesDeviationMatrixAppService
    {

        private readonly IRepository<BusinessPlan, Int32> _BusinessPlansRepository;
        private readonly IBusinessPlanAppService _BusinessPlansAppService;
        private readonly IRepository<PaymentChargesDeviationMatric, Int32> _PaymentChargesDeviationMatrixRepository;
        private readonly IRepository<LoanEligibility, Int32> _LoanEligibilityRepository;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IApplicationAppService _applicationAppService;
        private string paymentchargesdeviationmatrix = "Payment Charges Deviation Matrix";
        public PaymentChargesDeviationMatrixAppService(IRepository<PaymentChargesDeviationMatric> PaymentChargesDeviationMatrixRepository,
                                                        IRepository<BusinessPlan> BusinessPlansRepository, IRepository<LoanEligibility> LoanEligibilityRepository,
                                                        ILoanEligibilityAppService loanEligibilityAppService, ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
                                                        IBusinessPlanAppService BusinessPlansAppService,
                                                        IApplicationAppService ApplicationAppService)
        {
            _BusinessPlansRepository = BusinessPlansRepository;
            _BusinessPlansAppService = BusinessPlansAppService;
            _PaymentChargesDeviationMatrixRepository = PaymentChargesDeviationMatrixRepository;
            _LoanEligibilityRepository = LoanEligibilityRepository;
            _loanEligibilityAppService = loanEligibilityAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _applicationAppService = ApplicationAppService;

        }
        public async Task<List<PaymentChargesDeviationMatrixListDto>> GetAllPaymentChargesDeviationMatrixListDto()
        {
            try
            {
                var payment = _PaymentChargesDeviationMatrixRepository.GetAllList().ToList();
                var all_list = ObjectMapper.Map<List<PaymentChargesDeviationMatrixListDto>>(payment);

                 return all_list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public decimal GetPaymentChargesDeviationMatrixByApplicationId(int ApplicationId)
        {
            try
            {

                // application = product type
                // get PaymentChargesDeviationMatrix get all list
                // businessplan = sec/unsec
                // check product id = 1,2,6,7 loaneligibility <-> productid=8,9 tdsloaneligibility ==== Loan Amount
                //  formula
                double LPC =0, FED=0, loanAmount = 0, result;
                decimal val = 0;
          
                var app = _applicationAppService.GetApplicationByApplicationId(ApplicationId);
                var BP = _BusinessPlansAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                if (app.ProductType != 9 || app.ProductType != 8)
                {
                    var product = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                    if (BP.CollateralGiven == "SECURED")
                    {
                        loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",",""));
                        //if to check processing charges are less then 13500
                        LPC = loanAmount * 0.0045;

                        if(LPC>13500)
                        {
                            LPC = 13500;
                        }

                        //FED = LPC * 0.16;

                    }
                    else if (BP.CollateralGiven == "UNSECURED")
                    {
                        loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",", ""));
                        LPC = loanAmount * 0.0077;
                    }
                    
                }

                else if (app.ProductType == 9 || app.ProductType == 8)
                {
                    var tds_product = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId).Result;
                    if (BP.CollateralGiven == "SECURED")
                    {
                        loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));
                        LPC = loanAmount * 0.0045;
                        if (LPC > 13500)
                        {
                            LPC = 13500;
                        }
                        //FED = LPC * 0.16;

                    }
                    else if (BP.CollateralGiven == "UNSECURED")
                    {
                        loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));
                        LPC = loanAmount * 0.0077;
                    }
                }



                return Convert.ToDecimal(LPC);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", paymentchargesdeviationmatrix));
            }
        }


    }
}

