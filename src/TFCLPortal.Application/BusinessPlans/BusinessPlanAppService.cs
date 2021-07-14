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
using TFCLPortal.BusinessPlans.Dto;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.BusinessPlans
{
    public class BusinessPlanAppService : TFCLPortalAppServiceBase, IBusinessPlanAppService
    {
        private readonly IRepository<BusinessPlan, Int32> _businessPlanRepository;
        private readonly IRepository<PaymentFrequency> _paymentFrequencyRepository;
        private readonly IRepository<LoanPurpose> _loanPurposeRepository;
        private readonly IRepository<CreditBureauCheck> _CreditBureauCheckRepository;
        private readonly IRepository<ClientStatus> _clientStatusRepository;
        private readonly IRepository<LoanTenureRequired> _loanTenurerepository;
        private readonly IRepository<LoanPurposeClassification> _LoanPurposeClassificationRepository;
        private readonly IRepository<Applicationz> _applicationsRepository;
        private readonly IRepository<ReasonOfDecline> _reasonOfDeclineRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private string businessPlan = "Business Plan";
        public BusinessPlanAppService(IRepository<BusinessPlan, Int32> businessPlanRepository,
            IRepository<PaymentFrequency> paymentFrequencyRepository,
            IRepository<LoanPurpose> loanPurposeRepository,
            IRepository<LoanTenureRequired> loanTenurerepository,
            IRepository<ClientStatus> clientStatusRepository,
            IRepository<CreditBureauCheck> creditBureauCheckRepository,
            IRepository<Applicationz> applicationsRepository,
            IRepository<ReasonOfDecline> reasonOfDeclineRepository,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<LoanPurposeClassification> LoanPurposeClassificationRepository,
            IApplicationAppService applicationAppService)
        {
            _businessPlanRepository = businessPlanRepository;
            _paymentFrequencyRepository = paymentFrequencyRepository;
            _loanPurposeRepository = loanPurposeRepository;
            _loanTenurerepository = loanTenurerepository;
            _applicationAppService = applicationAppService;
            _clientStatusRepository = clientStatusRepository;
            _reasonOfDeclineRepository = reasonOfDeclineRepository;
            _applicationsRepository = applicationsRepository;
            _CreditBureauCheckRepository = creditBureauCheckRepository;
            _LoanPurposeClassificationRepository = LoanPurposeClassificationRepository;
            _apiCallLogAppService = apiCallLogAppService;
        }

        public async Task<string> CreateBusinessPlan(CreateBusinessPlanDto input)
        {
            string ResponseString = "";
            try
            {

                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateBusinessPlan";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var bp = _businessPlanRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (bp != null)
                {
                    var businessPlans = _businessPlanRepository.Get(bp.Id);
                    businessPlans.ApplicationId = input.ApplicationId;
                    businessPlans.BranchCode = input.BranchCode;
                    businessPlans.ApplicationNo = input.ApplicationNo;
                    businessPlans.ApplicationDate = input.ApplicationDate;
                    businessPlans.Purpose = input.Purpose;
                    businessPlans.PEPs = input.PEPs;
                    businessPlans.ClientExistInCelBel = input.ClientExistInCelBel;
                    businessPlans.PurposeOfLoanUtilization = input.PurposeOfLoanUtilization;
                    businessPlans.TotalInvestmentRequired = input.TotalInvestmentRequired;
                    businessPlans.AmountWorkingCapital = input.AmountWorkingCapital;
                    businessPlans.AmountCapitalExpenditure = input.AmountCapitalExpenditure;
                    businessPlans.ClientShare = input.ClientShare;
                    businessPlans.LoanAmountRecommended = input.LoanAmountRecommended;
                    businessPlans.RequiredLoanAmount = input.RequiredLoanAmount;
                    businessPlans.LoanTenureRequested = input.LoanTenureRequested;
                    businessPlans.CollateralGiven = input.CollateralGiven;
                    businessPlans.PaymentFrequency = input.PaymentFrequency;
                    businessPlans.ScreenStatus = input.ScreenStatus;
                    businessPlans.Comments = input.Comments;
                    businessPlans.clientID = input.clientID;
                    businessPlans.clientStatus = input.clientStatus;
                    businessPlans.ReasonOfDecline = input.ReasonOfDecline;
                    businessPlans.ReasonOfDecineOthers = input.ReasonOfDecineOthers;
                    businessPlans.CreditBureauCheck = input.CreditBureauCheck;
                    businessPlans.OverDues = input.OverDues;
                    businessPlans.ApprovalTaken = input.ApprovalTaken;
                    businessPlans.AmlCftCheck = input.AmlCftCheck;
                    businessPlans.AmlCftClearance = input.AmlCftClearance;
                    businessPlans.ClientInCell = input.ClientInCell;
                    businessPlans.ClientInBell = input.ClientInBell;
                    businessPlans.PurposeOfLoanUtilizationDetails = input.PurposeOfLoanUtilizationDetails;
                    businessPlans.LoanPurposeClassification = input.LoanPurposeClassification;
                    businessPlans.LoanPurposeClassificationOthers = input.LoanPurposeClassificationOthers;


                    await _businessPlanRepository.UpdateAsync(businessPlans);
                }
                else
                {
                    var businessPlans = ObjectMapper.Map<BusinessPlan>(input);
                    _businessPlanRepository.Insert(businessPlans);
                    _applicationAppService.UpdateApplicationLastScreen("LOAN REQUISITION DETAILS", input.ApplicationId);

                }

                var app = _applicationsRepository.GetAllList(x => x.Id == input.ApplicationId).FirstOrDefault();
                app.SchoolName = input.SchoolName;
                _applicationsRepository.Update(app);
                CurrentUnitOfWork.SaveChanges();

                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", businessPlan));

            }
        }

        public async Task<BusinessPlanListDto> GetBusinessPlanById(int Id)
        {
            try
            {
                var businessPlans = await _businessPlanRepository.GetAsync(Id);

                return ObjectMapper.Map<BusinessPlanListDto>(businessPlans);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", businessPlan));
            }
        }

        public async Task<string> UpdateBusinessPlan(UpdateBusinessPlanDto input)
        {
            string ResponseString = "";
            try
            {
                var businessPlans = _businessPlanRepository.Get(input.Id);
                if (businessPlans != null && businessPlans.Id > 0)
                {
                    ObjectMapper.Map(input, businessPlans);
                    await _businessPlanRepository.UpdateAsync(businessPlans);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", businessPlan));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", businessPlan));
            }
        }

        public async Task<BusinessPlanListDto> GetBusinessPlanByApplicationId(int ApplicationId)
        {
            try
            {
                var businessPlans = _businessPlanRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var businessPlanz = ObjectMapper.Map<BusinessPlanListDto>(businessPlans);

                if (businessPlanz != null && businessPlanz.ApplicationId > 0)
                {

                    if (businessPlans.PaymentFrequency != 0)
                    {
                        var paymentFrequency = _paymentFrequencyRepository.Get(businessPlans.PaymentFrequency);
                        businessPlanz.PaymentName = paymentFrequency.Name;
                    }

                    if (businessPlans.Purpose != 0)
                    {
                        var LoanPurpose = _loanPurposeRepository.Get(businessPlans.Purpose);
                        businessPlanz.LoanpurposeName = LoanPurpose.Name;
                    }

                    if (businessPlans.clientStatus != 0 && businessPlans.clientStatus != null)
                    {
                        var clientStatus = _clientStatusRepository.Get((int)businessPlans.clientStatus);
                        businessPlanz.clientStatusName = clientStatus.Name;
                    }

                    if (businessPlans.ReasonOfDecline != 0 && businessPlans.ReasonOfDecline != null)
                    {
                        var ReasonOfDecline = _reasonOfDeclineRepository.Get((int)businessPlans.ReasonOfDecline);
                        businessPlanz.ReasonOfDeclineName = ReasonOfDecline.Name;
                    }

                    if (businessPlans.CreditBureauCheck != 0 && businessPlans.CreditBureauCheck != null)
                    {
                        var CreditBureauCheck = _CreditBureauCheckRepository.Get((int)businessPlans.CreditBureauCheck);
                        businessPlanz.CreditBureauCheckName = CreditBureauCheck.Name;
                    }

                    if (businessPlans.LoanPurposeClassification != 0 && businessPlans.LoanPurposeClassification != null)
                    {
                        var LoanPurposeClassification = _LoanPurposeClassificationRepository.Get((int)businessPlans.LoanPurposeClassification);
                        businessPlanz.LoanPurposeClassificationName = LoanPurposeClassification.Name;
                    }

                    if (businessPlans.LoanTenureRequested != 0)
                    {
                        var LoanTenureRequested = _loanTenurerepository.Get(businessPlans.LoanTenureRequested);
                        businessPlanz.LoanTenureRequestedName = LoanTenureRequested.Name;
                    }

                }
                //var initChat = (from objBusiness in _businessPlanRepository.GetAllList()
                //                join clientStatus in _clientStatusRepository.GetAllList() on objBusiness.clientStatus equals clientStatus.Id
                //                join ReasonOfDecline in _reasonOfDeclineRepository.GetAllList() on objBusiness.ReasonOfDecline equals ReasonOfDecline.Id
                //                join CreditBureauCheck in _CreditBureauCheckRepository.GetAllList() on objBusiness.CreditBureauCheck equals CreditBureauCheck.Id
                //                join LoanPurposeClassification in _LoanPurposeClassificationRepository.GetAllList() on objBusiness.LoanPurposeClassification equals LoanPurposeClassification.Id
                //                //join applications in _applicationsRepository.GetAllList() on objBusiness.ApplicationId equals applications.Id
                //                where objBusiness.ApplicationId == ApplicationId
                //                select new
                //                {
                //                    objBusiness,
                //                    clientStatus = clientStatus.Name,
                //                    ReasonOfDecline = ReasonOfDecline.Name,
                //                    LoanPurposeClassification = LoanPurposeClassification.Name,
                //                    CreditBureauCheck = CreditBureauCheck.Name,
                //                    //ApplicantName = applications.ClientName,
                //                    //ApplicationSchoolName = applications.SchoolName
                //                }).FirstOrDefault();

                //if (initChat != null)
                //{
                //    businessPlanz.clientStatus = initChat.clientStatus;
                //    businessPlanz.ReasonOfDecline = initChat.ReasonOfDecline;
                //    businessPlanz.LoanPurposeClassification = initChat.LoanPurposeClassification;
                //    businessPlanz.CreditBureauCheck = initChat.CreditBureauCheck;
                //    //businessPlanz.ApplicantName = initChat.ApplicantName;
                //    //businessPlanz.SchoolName = initChat.ApplicationSchoolName;
                //}                  
                return businessPlanz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", businessPlan));
            }
        }

       
        public bool CheckBusinessPlanByApplicationId(int ApplicationId)
        {
            try
            {
                var businessPlans = _businessPlanRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if(businessPlans!=null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", businessPlan));
            }

        }
    }
}
