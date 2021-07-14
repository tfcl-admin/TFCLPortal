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
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.ProductMarkupRates;
using TFCLPortal.ProductMarkupRates.Dto;

namespace TFCLPortal.ApplicationWiseDeviationVariables
{
    public class ApplicationWiseDeviationVariableAppService : TFCLPortalAppServiceBase, IApplicationWiseDeviationVariableAppService
    {
        private readonly IRepository<ApplicationWiseDeviationVariable, Int32> _applicationWiseDeviationVariableRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IRepository<Applicationz> _applicationRepository;
        private readonly IRepository<BusinessPlan> _businessPlanRepository;
        private string ApplicationWiseDeviationVariable = "Application Wise Deviation Variable";
        private readonly IApiCallLogAppService _apiCallLogAppService;
        public ApplicationWiseDeviationVariableAppService(IRepository<Applicationz> applicationRepository, IRepository<BusinessPlan> businessPlanRepository, IApiCallLogAppService apiCallLogAppService, IRepository<ProductDetail> productDetailRepository,IRepository<ApplicationWiseDeviationVariable, Int32> applicationWiseDeviationVariableRepository, IRepository<ProductType> productTypeRepository)
        {
            _applicationWiseDeviationVariableRepository = applicationWiseDeviationVariableRepository;
            _productTypeRepository = productTypeRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _productDetailRepository = productDetailRepository; 
            _applicationRepository = applicationRepository;
            _businessPlanRepository = businessPlanRepository;
        }
        public async Task CreateApplicationWiseDeviationVariable(CreateApplicationWiseDeviationVariableDto input)
        {
            try
            {
                var deviationMatrixResult = _applicationWiseDeviationVariableRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
                if (deviationMatrixResult != null)
                {
                    var deviationMatrixMapped = ObjectMapper.Map<ApplicationWiseDeviationVariable>(deviationMatrixResult);
                    _applicationWiseDeviationVariableRepository.Delete(deviationMatrixMapped);
                }

                var applicationWiseDeviationVariable = ObjectMapper.Map<ApplicationWiseDeviationVariable>(input);
                await _applicationWiseDeviationVariableRepository.InsertAsync(applicationWiseDeviationVariable);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", ApplicationWiseDeviationVariable));
            }
        }

        public ApplicationWiseDeviationVariableListDto GetApplicationWiseDeviationVariableById(int Id)
        {
            try
            {
                var applicationWiseDeviationVariable = _applicationWiseDeviationVariableRepository.Get(Id);

                return ObjectMapper.Map<ApplicationWiseDeviationVariableListDto>(applicationWiseDeviationVariable);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ApplicationWiseDeviationVariable));
            }
        }

        public ApplicationWiseDeviationVariableListDto GetApplicationWiseDeviationVariableDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var ApplicationWiseDeviationVariable = _applicationWiseDeviationVariableRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                var ApplicationWiseDeviation = ObjectMapper.Map<ApplicationWiseDeviationVariableListDto>(ApplicationWiseDeviationVariable);

                if (ApplicationWiseDeviation != null)
                {

                    if (ApplicationWiseDeviation.fk_ProductId != 0)
                    {
                        var Product = _productTypeRepository.GetAllList().Where(x => x.Id == ApplicationWiseDeviation.fk_ProductId).FirstOrDefault();
                        ApplicationWiseDeviation.ProductName = Product.Name;
                    }
                    if (ApplicationWiseDeviation.ApplicationId != 0)
                    {
                        var application = _applicationRepository.GetAllList(x => x.Id == ApplicationWiseDeviation.ApplicationId).FirstOrDefault();
                        ApplicationWiseDeviation.ClientID = application.ClientID;
                        ApplicationWiseDeviation.ClientName = application.ClientName;
                        ApplicationWiseDeviation.SchoolName = application.SchoolName;
                    }

                }
                return ApplicationWiseDeviation;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Application Wise Deviation Matrix"));
            }
        }

        public async Task<ApplicationWiseDeviationVariableListDto> GetApplicationWiseDeviationVariableDetailByApplicationIdAsync(int ApplicationId)
        {
            try
            {
                var ApplicationWiseDeviationVariable = _applicationWiseDeviationVariableRepository.FirstOrDefaultAsync(x => x.ApplicationId == ApplicationId).Result;

                var ApplicationWiseDeviation = ObjectMapper.Map<ApplicationWiseDeviationVariableListDto>(ApplicationWiseDeviationVariable);

                if (ApplicationWiseDeviation != null)
                {

                    if (ApplicationWiseDeviation.fk_ProductId != 0)
                    {
                        var Product = await _productTypeRepository.GetAsync(ApplicationWiseDeviation.fk_ProductId);
                        ApplicationWiseDeviation.ProductName = Product.Name;
                    }
                    if (ApplicationWiseDeviation.ApplicationId != 0)
                    {
                        var application = await _applicationRepository.GetAsync(ApplicationWiseDeviation.ApplicationId);
                        ApplicationWiseDeviation.ClientID = application.ClientID;
                        ApplicationWiseDeviation.ClientName = application.ClientName;
                        ApplicationWiseDeviation.SchoolName = application.SchoolName;
                    }

                }
                return ApplicationWiseDeviation;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Application Wise Deviation Matrix"));
            }
        }

        public async Task<string> UpdateApplicationWiseDeviationVariable(UpdateApplicationWiseDeviationVariableDto input)
        {
            string ResponseString = "";
            try
            {
                var applicationWiseDeviationVariable = _applicationWiseDeviationVariableRepository.Get(input.Id);
                if (applicationWiseDeviationVariable != null && applicationWiseDeviationVariable.Id > 0)
                {
                    ObjectMapper.Map(input, applicationWiseDeviationVariable);
                    await _applicationWiseDeviationVariableRepository.UpdateAsync(applicationWiseDeviationVariable);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", ApplicationWiseDeviationVariable));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", ApplicationWiseDeviationVariable));
            }
        }




        public async Task<string> getMarkup(GetMarkupParameters input)
        {
            string ResponseString = "";
            string Markup;

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "getMarkup";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

              

                var applicationWiseVariables = GetApplicationWiseDeviationVariableDetailByApplicationId(input.ApplicationId);

                if(applicationWiseVariables!=null)
                {
                    if (input.LoanAmount==applicationWiseVariables.LoanAmount && input.LoanTenure==applicationWiseVariables.LoanTenure && input.NoOfInstallments == applicationWiseVariables.NoOfInstallments && input.Security == applicationWiseVariables.Security)
                    {
                        Markup = applicationWiseVariables.Markup;
                    }
                    else
                    {
                        if (input.ProductId == "1" || input.ProductId == "7")//TSS
                        {
                            input.ProductId = "7";
                        }
                        else if (input.ProductId == "2" || input.ProductId == "6") //TSA
                        {
                            input.ProductId = "6";
                        }
                        int loanAmount = Convert.ToInt32(input.LoanAmount);
                        var productDetails = _productDetailRepository.GetAllList().Where(x => x.Fk_ProductId == int.Parse(input.ProductId) && loanAmount >= x.SlabMin && loanAmount <= x.SlabMax && x.Tenure.Contains(input.LoanTenure)).FirstOrDefault();

                        //Check for fresh or repeat client
                        bool isFresh;
                        var checkApplications = _applicationRepository.GetAllList().Where(x => x.Id == input.ApplicationId).FirstOrDefault();
                        if (checkApplications != null)
                        {
                            var checkCNICs = _applicationRepository.GetAllList().Where(x => x.CNICNo == checkApplications.CNICNo && x.ScreenStatus != ApplicationState.Decline).ToList();
                            if (checkCNICs.Count > 1)
                            {
                                isFresh = false;
                            }
                            else
                            {
                                isFresh = true;
                            }
                        }
                        else
                        {
                            isFresh = true;
                        }


                        //Check for Secured or Un-Secured
                        bool isSecured;
                        var checkBusinessPlans = _businessPlanRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
                       
                        if (checkBusinessPlans.CollateralGiven.Contains("UNSECURED"))
                        {
                            isSecured = false;
                        }
                        else if (checkBusinessPlans.CollateralGiven.Contains("SECURED"))
                        {
                            isSecured = true;
                        }
                        else
                        {
                            isSecured = false;
                        }


                        //Get Markup on basis of Secure and Fresh

                        if (isSecured && isFresh)
                        {
                            Markup = productDetails.FreshClientSecureMarkupRate.ToString();
                        }
                        else if (!isSecured && isFresh)
                        {
                            Markup = productDetails.FreshClientUnSecureMarkupRate.ToString();
                        }
                        else if (isSecured && !isFresh)
                        {
                            Markup = productDetails.RepeatClientSecureMarkupRate.ToString();
                        }
                        else if (!isSecured && !isFresh)
                        {
                            Markup = productDetails.RepeatClientUnSecureMarkupRate.ToString();
                        }
                        else
                        {
                            Markup = "Error!";
                        }


                        // Updates Markup
                        //save markup
                        UpdateApplicationWiseDeviationVariableDto updateObj = new UpdateApplicationWiseDeviationVariableDto();
                        updateObj.Id = applicationWiseVariables.Id;
                        updateObj.ApplicationId = applicationWiseVariables.ApplicationId;
                        updateObj.fk_ProductId = applicationWiseVariables.fk_ProductId;
                        updateObj.MinLimitForUnsecuredLoan = applicationWiseVariables.MinLimitForUnsecuredLoan;
                        updateObj.MaxLimitForUnsecuredLoan = applicationWiseVariables.MaxLimitForUnsecuredLoan;
                        updateObj.ApplicantMinAge = applicationWiseVariables.ApplicantMinAge;
                        updateObj.ApplicantMaxAge = applicationWiseVariables.ApplicantMaxAge;
                        updateObj.BusinessAgeYears = applicationWiseVariables.BusinessAgeYears;
                        updateObj.BusinessAgeAtCurrentPlaceYears = applicationWiseVariables.BusinessAgeAtCurrentPlaceYears;
                        updateObj.MinPercentageOfSAexpAgainstSAincome = applicationWiseVariables.MinPercentageOfSAexpAgainstSAincome;
                        updateObj.MaxPercentageOfNAItotalSchoolRevenue = applicationWiseVariables.MaxPercentageOfNAItotalSchoolRevenue;
                        updateObj.MinPercentageOfHHEtotalSchoolRevenue = applicationWiseVariables.MinPercentageOfHHEtotalSchoolRevenue;
                        updateObj.MaxLimitForInstallmentRatio = applicationWiseVariables.MaxLimitForInstallmentRatio;
                        updateObj.GuarantorMinAge = applicationWiseVariables.GuarantorMinAge;
                        updateObj.GuarantorMaxAge = applicationWiseVariables.GuarantorMaxAge;
                        updateObj.LTVForResidentialBuilding = applicationWiseVariables.LTVForResidentialBuilding;
                        updateObj.LTVForResidentialLand = applicationWiseVariables.LTVForResidentialLand;
                        updateObj.LTVForCommercialBuilding = applicationWiseVariables.LTVForCommercialBuilding;
                        updateObj.LTVForCommercialLand = applicationWiseVariables.LTVForCommercialLand;
                        updateObj.LTVForAgriculturalLand = applicationWiseVariables.LTVForAgriculturalLand;
                        updateObj.LTVForVehicleLessThanOneYear = applicationWiseVariables.LTVForVehicleLessThanOneYear;
                        updateObj.LTVForVehicleLessThanFiveYear = applicationWiseVariables.LTVForVehicleLessThanFiveYear;
                        updateObj.LTVForVehicleMoreThanFiveYear = applicationWiseVariables.LTVForVehicleMoreThanFiveYear;
                        updateObj.LTVForTDRratedA = applicationWiseVariables.LTVForTDRratedA;
                        updateObj.LTVForTDRratedB = applicationWiseVariables.LTVForTDRratedB;
                        updateObj.LTVForFranchiseAgreement = applicationWiseVariables.LTVForFranchiseAgreement;
                        updateObj.LTVForGold = applicationWiseVariables.LTVForGold;
                        updateObj.MinStudentEnrolled = applicationWiseVariables.MinStudentEnrolled;
                        updateObj.LoanAmount = input.LoanAmount;
                        updateObj.NoOfInstallments = input.NoOfInstallments;
                        updateObj.LoanTenure = input.LoanTenure;
                        updateObj.Markup = Markup;
                        updateObj.Security = input.Security;


                        await UpdateApplicationWiseDeviationVariable(updateObj);
                    }
                }
                else
                {
                    Markup = "Error!";
                }

                





                return ResponseString = Markup;
            }
            catch (Exception ex)
            {
                return ResponseString = ex.ToString();
                //throw new UserFriendlyException(L("UpdateMethodError{0}", ApplicationWiseDeviationVariable));
            }
        }

        public List<ApplicationWiseDeviationVariableListDto> GetApplicationWiseDeviationVariables()
        {
            try
            {
                var deviationMatrix = _applicationWiseDeviationVariableRepository.GetAllList();

                var Deviations = ObjectMapper.Map<List<ApplicationWiseDeviationVariableListDto>>(deviationMatrix);

                if (Deviations != null)
                {
                    foreach (var Deviation in Deviations)
                    {
                        if (Deviation.fk_ProductId != 0)
                        {
                            var Product = _productTypeRepository.GetAllList().Where(x => x.Id == Deviation.fk_ProductId).FirstOrDefault();
                            Deviation.ProductName = Product.Name;
                        }
                        if(Deviation.ApplicationId!=0)
                        {
                            var application = _applicationRepository.GetAllList(x => x.Id == Deviation.ApplicationId).FirstOrDefault();
                            Deviation.ClientID = application.ClientID;
                            Deviation.ClientName = application.ClientName;
                            Deviation.SchoolName = application.SchoolName;
                        }
                    }
                }
                return Deviations.OrderByDescending(x => x.ApplicationId).ToList();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Application Wise Deviation Variables"));
            }
        }
    }
}
