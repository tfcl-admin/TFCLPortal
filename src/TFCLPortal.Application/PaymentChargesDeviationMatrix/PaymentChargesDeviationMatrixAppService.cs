﻿using Abp.Application.Services;
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
using TFCLPortal.Schedules;
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
        private readonly IScheduleAppService _scheduleappservice;
        private string paymentchargesdeviationmatrix = "Payment Charges Deviation Matrix";
        public PaymentChargesDeviationMatrixAppService(IRepository<PaymentChargesDeviationMatric> PaymentChargesDeviationMatrixRepository,
                                                        IRepository<BusinessPlan> BusinessPlansRepository, IRepository<LoanEligibility> LoanEligibilityRepository,
                                                        ILoanEligibilityAppService loanEligibilityAppService, ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
                                                        IScheduleAppService scheduleappservice,
                                                        IBusinessPlanAppService BusinessPlansAppService,
                                                        IApplicationAppService ApplicationAppService)
        {
            _BusinessPlansRepository = BusinessPlansRepository;
            _BusinessPlansAppService = BusinessPlansAppService;
            _PaymentChargesDeviationMatrixRepository = PaymentChargesDeviationMatrixRepository;
            _LoanEligibilityRepository = LoanEligibilityRepository;
            _scheduleappservice = scheduleappservice;
            _loanEligibilityAppService = loanEligibilityAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _applicationAppService = ApplicationAppService;

        }
        public async Task<List<PaymentChargesDeviationMatrixListDto>> GetAllPaymentChargesDeviationMatrixList()
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
                double LPC = 0, FED = 0, loanAmount = 0, result;
                decimal val = 0;

                ApplicationListDto app = _applicationAppService.GetApplicationByApplicationId(ApplicationId);
                var BP = _BusinessPlansAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                var paymentCharges = GetAllPaymentChargesDeviationMatrixList().Result;

                if (paymentCharges != null)
                {
                    if (app.ProductType != 9 || app.ProductType != 8)
                    {
                        var product = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                        if (BP.CollateralGiven == "SECURED")
                        {
                            var securedPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "SECURED").FirstOrDefault();

                            loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",", ""));

                            //if to check processing charges are less then 13500

                            LPC = loanAmount * (Convert.ToDouble(securedPaymentCharges.Percentage) / 100);

                            if (LPC > Convert.ToDouble(securedPaymentCharges.MaxAmount) && Convert.ToDouble(securedPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                            }

                            if (app.isEnhancementApplication == true)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", "").Replace("", "0"));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(securedPaymentCharges.MaxAmount))
                                    {
                                        LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }
                                }
                            }

                            //FED = LPC * 0.16;

                        }
                        else if (BP.CollateralGiven == "UNSECURED")
                        {
                            var unSecuredPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "UNSECURED").FirstOrDefault();

                            loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",", ""));
                            LPC = loanAmount * (Convert.ToDouble(unSecuredPaymentCharges.Percentage) / 100);
                            if (LPC > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) && Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                            }

                            if (app.isEnhancementApplication == true)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", "").Replace("", "0"));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount)&& Convert.ToDouble(unSecuredPaymentCharges.MaxAmount)!=0)
                                    {
                                        LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }
                                }
                            }

                        }

                    }

                    else if (app.ProductType == 9 || app.ProductType == 8)
                    {
                        var tds_product = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId).Result;
                        if (BP.CollateralGiven == "SECURED")
                        {
                            var securedPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "SECURED").FirstOrDefault();
                            loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));

                            LPC = loanAmount * (Convert.ToDouble(securedPaymentCharges.Percentage) / 100);

                            if (LPC > Convert.ToDouble(securedPaymentCharges.MaxAmount) && Convert.ToDouble(securedPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                            }
                            //FED = LPC * 0.16;
                            if (app.isEnhancementApplication == true)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", "").Replace("", "0"));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(securedPaymentCharges.MaxAmount))
                                    {
                                        LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }
                                }
                            }

                        }
                        else if (BP.CollateralGiven == "UNSECURED")
                        {
                            var unSecuredPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "UNSECURED").FirstOrDefault();
                            loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));
                            LPC = loanAmount * (Convert.ToDouble(unSecuredPaymentCharges.Percentage) / 100);

                            if (app.isEnhancementApplication == true)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", "").Replace("", "0"));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) && Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) != 0)
                                    {
                                        LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }
                                }
                            }
                        }

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
