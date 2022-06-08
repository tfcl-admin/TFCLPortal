using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Customs;
using TFCLPortal.DynamicDropdowns.AcademicSessions;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.Mobilizations.Dto;
using TFCLPortal.Users;

namespace TFCLPortal.Mobilizations
{
    public class MobilizationAppService : TFCLPortalAppServiceBase, IMobilizationAppService
    {
        private readonly IRepository<Mobilization, Int32> _mobilizationRepository;
        private readonly IRepository<MobilizationStatus> _mobStatusRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<AcademicSession> _academicSessionRepository;
        private readonly IRepository<OtherSourceOfIncome> _otherSourceOfIncomeRepository;
        private readonly IRepository<SchoolCategory> _schoolCategoryRepository;
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;
        private readonly ICustomRepository _customRepository;
        private readonly ICustomAppService _customAppService;
        private string mobilization = "Mobilization";
        public MobilizationAppService(IRepository<Mobilization, Int32> mobilizationRepository,
             IRepository<MobilizationStatus> mobStatusRepository,
             IRepository<ProductType> productTypeRepository,
             IUserAppService userAppService  ,
             ICustomRepository customRepository,
             ICustomAppService customAppService,
             IRepository<AcademicSession> academicSessionRepository,
             IRepository<OtherSourceOfIncome> otherSourceOfIncomeRepository,
             IRepository<SchoolCategory> schoolCategoryRepository,
        UserManager userManager)
        {
            _mobilizationRepository = mobilizationRepository;
            _mobStatusRepository = mobStatusRepository;
            _productTypeRepository = productTypeRepository;
            _userAppService = userAppService;
            _userManager = userManager;
            _customRepository = customRepository;
            _customAppService = customAppService;
            _academicSessionRepository = academicSessionRepository;
            _otherSourceOfIncomeRepository = otherSourceOfIncomeRepository;
            _schoolCategoryRepository = schoolCategoryRepository;
        }

        public async Task<ApplicationResponse> CreateMobilization(CreateMobilizationDto input)
        {
            try
            {
                ApplicationResponse applicationResponse = new ApplicationResponse();
                if (input.MobilizationStatus != 4)
                {
                    //if (input.PrefixLable=="1")
                    //{

                    //}
                    var mobilizations = ObjectMapper.Map<Mobilization>(input);
                    var currentUser = await _userAppService.GetUserById(input.CreatorUserId);
                    mobilizations.Fk_BranchID = currentUser.BranchId;

                    
                    var mobiliz = await _mobilizationRepository.InsertAsync(mobilizations);
                    CurrentUnitOfWork.SaveChanges();

                    applicationResponse.ApplicationId = 0;
                    applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                    return applicationResponse;
                    
                }
                else
                {
                    applicationResponse.ApplicationId = 0;
                    applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                    return applicationResponse;

                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", mobilization));
            }
        }

        public async Task<ApplicationResponse> CreateMobilizationList(List<CreateMobilizationDto> input)
        {
             try
            {
                ApplicationResponse applicationResponse = new ApplicationResponse();
                foreach (var item in input)
                {
                    if (item.MobilizationStatus != 4)
                    {
                        var mobilizations = ObjectMapper.Map<Mobilization>(item);
                        var mobiliz = await _mobilizationRepository.InsertAsync(mobilizations);

                        applicationResponse.ApplicationId = 0;
                        applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                        

                    }
                    else
                    {
                        applicationResponse.ApplicationId = 0;
                        applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                        

                    }
                }
                return applicationResponse;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", mobilization));
            }
        }

        public MobilizationListDto GetMobilizationByApplicationId(int ApplicationId)
        {
            try
            {
                var mobilizations = _mobilizationRepository.GetAllList().Where(x => x.Id == ApplicationId).FirstOrDefault();

                var obj = ObjectMapper.Map<MobilizationListDto>(mobilizations);
                var user = _userManager.FindByIdAsync((obj.CreatorUserId).ToString());
                var initChat = (from mob in _mobilizationRepository.GetAllList()
                                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                                join mobilization in _mobStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id
                                

                                where mob.Id == ApplicationId
                                select new
                                {
                                    mob,
                                    ProductTypeName = product.Name,
                                    MobilizationStatus = mobilization.Name,

                                }).FirstOrDefault();

                if (initChat != null)
                {
                    obj.ProductTypeName = initChat.ProductTypeName; 
                    obj.MobStatusName = initChat.MobilizationStatus;

                }
                return obj;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", mobilization));
            }
        }

        public List<GetMobilizationListDto> GetMobilizationById(int Id)
        {
            try
            {
                var mobilizations = _customRepository.GetMobilizationsByMaxInteractionNumber().Where(x => x.Id == Id); //await _mobilizationRepository.GetAsync(Id);
                //var mobilizations = _mobilizationRepository.getallL(Id);

                var obj = ObjectMapper.Map<List<GetMobilizationListDto>>(mobilizations);
                //var initChat = (from mob in _mobilizationRepository.GetAllList()
                //                join product in _productTypeRepository.GetAllList() on mob.ProductType equals product.Id
                //                join mobilization in _mobStatusRepository.GetAllList() on mob.MobilizationStatus equals mobilization.Id

                //                where mob.Id == Id
                //                select new
                //                {
                //                    mob,
                //                    producttype = product.Name,
                //                    MobilizationStatus = mobilization.Name,

                //                }).FirstOrDefault();

                //if (initChat != null)
                //{
                //    obj.ProductTypeName = initChat.producttype;
                //    obj.MobStatusName = initChat.MobilizationStatus;  

                //}
                return obj;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", mobilization));
            }
        }

        public List<GetMobilizationListDto> GetMobilizationList()
        {
            try
            {

                var mobilizations = _customRepository.GetMobilizationsByMaxInteractionNumber();

                var objmobilizationsList = ObjectMapper.Map<List<GetMobilizationListDto>>(mobilizations);

                var list = objmobilizationsList.OrderByDescending(x => x.CreationTime).ToList();
                return list;

            }
            catch (Exception ex)
            {                
                throw new UserFriendlyException(L("GetMethodError{0}", mobilization+ ex.Message));
            }
        }
        public List<GetMobilizationListDto> GetMobilizationListBySdeId(int SDE_ID)
        {
            try
            {

                var mobilizations = _customRepository.GetMobilizationsByMaxInteractionNumberBySdeId(SDE_ID);
                var objmobilizationsList = ObjectMapper.Map<List<GetMobilizationListDto>>(mobilizations);
                var list = objmobilizationsList.OrderByDescending(x => x.CreationTime).ToList();
                return list;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", mobilization + ex.Message));
            }
        }
        public async Task<ApplicationResponse> UpdateMobilization(UpdateMobilizationDto input)
        {
            string ResponseString = "";
            ApplicationResponse applicationResponse = new ApplicationResponse();
            try
            {
                var mobilizations = _mobilizationRepository.Get(input.Id);
                if (mobilizations != null && mobilizations.Id > 0)
                {
                    ObjectMapper.Map(input, mobilizations);
                    await _mobilizationRepository.UpdateAsync(mobilizations);
                    CurrentUnitOfWork.SaveChanges();
                    applicationResponse.ApplicationId = 0;
                    applicationResponse.CreatedDateTime = DateTime.Now.ToString("yyyy-mm-dd");
                    applicationResponse.Message = "Records Updated Successfully";
                    return applicationResponse;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", mobilization));
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", mobilization));
            }
        }
    }
}
