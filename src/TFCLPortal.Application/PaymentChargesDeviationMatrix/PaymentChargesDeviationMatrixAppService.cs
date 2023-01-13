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
using TFCLPortal.ProductMarkupRates;
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
        public PaymentChargesValues GetPaymentChargesDeviationMatrixByApplicationId(int ApplicationId, bool isOldRequired,bool isLoanAmountGiven,double loanamountgiven)
        {
            try
            {

                double LPC = 0, FED = 0, loanAmount = 0, result;
                decimal val = 0;

                ApplicationListDto app = _applicationAppService.GetApplicationByApplicationId(ApplicationId);
                var BP = _BusinessPlansAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                var paymentCharges = GetAllPaymentChargesDeviationMatrixList().Result;

                //Result
                PaymentChargesValues rtnObject = new PaymentChargesValues();

                if (paymentCharges != null)
                {
                    if (app.ProductType != 9 && app.ProductType != 8)
                    {
                        var product = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                        if (BP.CollateralGiven == "SECURED")
                        {
                            var securedPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "SECURED").FirstOrDefault();

                            if(isLoanAmountGiven)
                            {
                                loanAmount = loanamountgiven;
                            }
                            else
                            {
                                loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",", ""));
                            }

                            //if to check processing charges are less then 13500

                            LPC = loanAmount * (Convert.ToDouble(securedPaymentCharges.Percentage) / 100);

                            if (LPC > Convert.ToDouble(securedPaymentCharges.MaxAmount) && Convert.ToDouble(securedPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                            }

                            rtnObject.ProcessingCharges = LPC;
                            rtnObject.FEDonPC = LPC * 0.16;
                            rtnObject.NetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;


                            if (isOldRequired)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", ""));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(securedPaymentCharges.MaxAmount))
                                    {
                                        LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }
                                    rtnObject.EarlierProcessingCharges = schedule.ProcessingCharges == null ? 0 : Convert.ToDouble(schedule.ProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierFEDonPC = schedule.FEDonProcessingCharges == null ? 0 : Convert.ToDouble(schedule.FEDonProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierNetDisbursement = schedule.NetDisbursmentAmount == null ? 0 : Convert.ToDouble(schedule.NetDisbursmentAmount.Replace(",", ""));


                                    rtnObject.ProcessingCharges = LPC - pc;
                                    rtnObject.TotalFEDonPC = (LPC - pc) * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                                    rtnObject.TotalProcessingCharges = LPC;
                                    rtnObject.TotalFEDonPC = LPC * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.TotalProcessingCharges - rtnObject.TotalFEDonPC;


                                }
                            }

                            //FED = LPC * 0.16;

                        }
                        else if (BP.CollateralGiven == "UNSECURED")
                        {
                            var unSecuredPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "UNSECURED").FirstOrDefault();

                            if (isLoanAmountGiven)
                            {
                                loanAmount = loanamountgiven;
                            }
                            else
                            {
                                loanAmount = Convert.ToDouble(product.LoanAmountRequried.Replace(",", ""));
                            }

                            LPC = loanAmount * (Convert.ToDouble(unSecuredPaymentCharges.Percentage) / 100);
                            if (LPC > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) && Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                            }
                            rtnObject.ProcessingCharges = LPC;
                            rtnObject.FEDonPC = LPC * 0.16;
                            rtnObject.NetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                            if (isOldRequired)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", ""));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) && Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) != 0)
                                    {
                                        LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }

                                    rtnObject.EarlierProcessingCharges = schedule.ProcessingCharges == null ? 0 : Convert.ToDouble(schedule.ProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierFEDonPC = schedule.FEDonProcessingCharges == null ? 0 : Convert.ToDouble(schedule.FEDonProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierNetDisbursement = schedule.NetDisbursmentAmount == null ? 0 : Convert.ToDouble(schedule.NetDisbursmentAmount.Replace(",", ""));


                                    rtnObject.ProcessingCharges = LPC - pc;
                                    rtnObject.TotalFEDonPC = (LPC - pc) * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                                    rtnObject.TotalProcessingCharges = LPC;
                                    rtnObject.TotalFEDonPC = LPC * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.TotalProcessingCharges - rtnObject.TotalFEDonPC;

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
                            if (isLoanAmountGiven)
                            {
                                loanAmount = loanamountgiven;
                            }
                            else
                            {
                                loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));
                            }
                            LPC = loanAmount * (Convert.ToDouble(securedPaymentCharges.Percentage) / 100);

                            if (LPC > Convert.ToDouble(securedPaymentCharges.MaxAmount) && Convert.ToDouble(securedPaymentCharges.MaxAmount) != 0)
                            {
                                LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                            }
                            rtnObject.ProcessingCharges = LPC;
                            rtnObject.FEDonPC = LPC * 0.16;
                            rtnObject.NetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                            //FED = LPC * 0.16;
                            if (isOldRequired)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", ""));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(securedPaymentCharges.MaxAmount))
                                    {
                                        LPC = Convert.ToDouble(securedPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }

                                    rtnObject.EarlierProcessingCharges = schedule.ProcessingCharges == null ? 0 : Convert.ToDouble(schedule.ProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierFEDonPC = schedule.FEDonProcessingCharges == null ? 0 : Convert.ToDouble(schedule.FEDonProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierNetDisbursement = schedule.NetDisbursmentAmount == null ? 0 : Convert.ToDouble(schedule.NetDisbursmentAmount.Replace(",", ""));


                                    rtnObject.ProcessingCharges = LPC - pc;
                                    rtnObject.TotalFEDonPC = (LPC - pc) * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                                    rtnObject.TotalProcessingCharges = LPC;
                                    rtnObject.TotalFEDonPC = LPC * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.TotalProcessingCharges - rtnObject.TotalFEDonPC;

                                }
                            }

                        }
                        else if (BP.CollateralGiven == "UNSECURED")
                        {
                            var unSecuredPaymentCharges = paymentCharges.Where(x => x.Type.ToUpper() == "UNSECURED").FirstOrDefault();
                            if (isLoanAmountGiven)
                            {
                                loanAmount = loanamountgiven;
                            }
                            else
                            {
                                loanAmount = Convert.ToDouble(tds_product.LoanAmountRequried.Replace(",", ""));
                            }
                            LPC = loanAmount * (Convert.ToDouble(unSecuredPaymentCharges.Percentage) / 100);

                            rtnObject.ProcessingCharges = LPC;
                            rtnObject.FEDonPC = LPC * 0.16;
                            rtnObject.NetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                            if (isOldRequired)
                            {
                                var schedule = _scheduleappservice.GetScheduleByApplicationId(app.PrevApplicationId).Result;
                                if (schedule != null)
                                {
                                    double pc = 0;
                                    if (schedule.ProcessingCharges != null)
                                    {
                                        pc = double.Parse(schedule.ProcessingCharges.Replace(",", ""));
                                    }

                                    if ((LPC + pc) > Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) && Convert.ToDouble(unSecuredPaymentCharges.MaxAmount) != 0)
                                    {
                                        LPC = Convert.ToDouble(unSecuredPaymentCharges.MaxAmount);
                                    }
                                    else
                                    {
                                        LPC += pc;
                                    }

                                    rtnObject.EarlierProcessingCharges = schedule.ProcessingCharges == null ? 0 : Convert.ToDouble(schedule.ProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierFEDonPC = schedule.FEDonProcessingCharges == null ? 0 : Convert.ToDouble(schedule.FEDonProcessingCharges.Replace(",", ""));
                                    rtnObject.EarlierNetDisbursement = schedule.NetDisbursmentAmount == null ? 0 : Convert.ToDouble(schedule.NetDisbursmentAmount.Replace(",", ""));



                                    rtnObject.ProcessingCharges = LPC - pc;
                                    rtnObject.TotalFEDonPC = (LPC - pc) * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.ProcessingCharges - rtnObject.FEDonPC;

                                    rtnObject.TotalProcessingCharges = LPC;
                                    rtnObject.TotalFEDonPC = LPC * 0.16;
                                    rtnObject.TotalNetDisbursement = loanAmount - rtnObject.TotalProcessingCharges - rtnObject.TotalFEDonPC;

                                }
                            }
                        }

                    }
                }

                return rtnObject;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", paymentchargesdeviationmatrix));
            }
        }


    }
}

