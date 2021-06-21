using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.PurchaseDetails.Dto;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.PurchaseDetails
{
    public class PurchaseDetailAppService : TFCLPortalAppServiceBase, IPurchaseDetailAppService
    {
        private readonly IRepository<Gender, Int32> _genderRepository;
        private readonly IRepository<Designation, Int32> _designationRepository;
        private readonly IRepository<PurchaseDetail, Int32> _PurchaseDetailRepository;
        private readonly IRepository<PurchaseDetailChild, Int32> _PurchaseDetailChildRepository;
        private readonly IRepository<PurchaseDetailGrandChild, Int32> _PurchaseDetailGrandChildRepository;
        private readonly IApplicationAppService _applicationAppService;
        private string PurchaseDetails = "Purchase Detail";
        public PurchaseDetailAppService(IRepository<PurchaseDetail, Int32> PurchaseDetailRepository,
            IRepository<PurchaseDetailChild, Int32> PurchaseDetailChildRepository,
            IRepository<Gender, Int32> genderRepository,
            IRepository<Designation, Int32> designationRepository,
            IRepository<PurchaseDetailGrandChild, Int32> PurchaseDetailGrandChildRepository,
            IApplicationAppService applicationAppService
            )
        {
            _PurchaseDetailRepository = PurchaseDetailRepository;
            _PurchaseDetailChildRepository = PurchaseDetailChildRepository;
            _PurchaseDetailGrandChildRepository = PurchaseDetailGrandChildRepository;
            _genderRepository = genderRepository;
            _designationRepository = designationRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreatePurchaseDetail(CreatePurchaseDetailDto input)
        {
            try
            {
                var IsPurchaseDetailExist = _PurchaseDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsPurchaseDetailExist != null)
                {
                    var ExistingPurchaseDetail = ObjectMapper.Map<PurchaseDetail>(IsPurchaseDetailExist);
                    var IsPurchaseDetailChildExist = _PurchaseDetailChildRepository.GetAllList().Where(x => x.Fk_PurchaseDetailId == ExistingPurchaseDetail.Id).ToList();

                    if (IsPurchaseDetailChildExist != null)
                    {
                        var ExistingPurchaseDetailChilds = ObjectMapper.Map<List<PurchaseDetailChild>>(IsPurchaseDetailChildExist);
                        foreach (var ExistingPurchaseDetailChild in ExistingPurchaseDetailChilds)
                        {

                            var IsPurchaseDetailChildSchoolClass = _PurchaseDetailGrandChildRepository.GetAllList().Where(x => x.Fk_PurchaseDetailChildId == ExistingPurchaseDetailChild.Id).ToList();

                            if (IsPurchaseDetailChildSchoolClass != null)
                            {
                                var ExistingPurchaseDetailGrandChildes = ObjectMapper.Map<List<PurchaseDetailGrandChild>>(IsPurchaseDetailChildSchoolClass);
                                foreach (var ExistingPurchaseDetailGrandChild in ExistingPurchaseDetailGrandChildes)
                                {
                                    _PurchaseDetailGrandChildRepository.Delete(ExistingPurchaseDetailGrandChild);
                                }
                            }

                            _PurchaseDetailChildRepository.Delete(ExistingPurchaseDetailChild);

                        }
                    }

                    _PurchaseDetailRepository.Delete(ExistingPurchaseDetail);

                }

                var PurchaseDetail = ObjectMapper.Map<PurchaseDetail>(input);
                var result = _PurchaseDetailRepository.Insert(PurchaseDetail);
                CurrentUnitOfWork.SaveChanges();
                if (input.PurchaseDetailChild.Count > 0) // schools Count
                {
                    List<CreatePurchaseDetailChildDto> PurchaseDetailChildDtos = input.PurchaseDetailChild;
                    foreach (var PurchaseDetailChildDto in PurchaseDetailChildDtos)
                    {
                        PurchaseDetailChildDto.Fk_PurchaseDetailId = result.Id;
                        var exposureDetailchild = ObjectMapper.Map<PurchaseDetailChild>(PurchaseDetailChildDto);
                        var businessChildresult = _PurchaseDetailChildRepository.Insert(exposureDetailchild);
                        CurrentUnitOfWork.SaveChanges();

                        if (PurchaseDetailChildDto.PurchaseDetailGrandChild.Count > 0)// schools Classes Count
                        {
                            List<CreatePurchaseDetailGrandChildDto> PurchaseDetailGrandChildes = PurchaseDetailChildDto.PurchaseDetailGrandChild;
                            foreach (var PurchaseDetailGrandChild in PurchaseDetailGrandChildes)
                            {
                                PurchaseDetailGrandChild.Fk_PurchaseDetailChildId = businessChildresult.Id;
                                var PurchaseDetailGrandChildesInsert = ObjectMapper.Map<PurchaseDetailGrandChild>(PurchaseDetailGrandChild);
                                _PurchaseDetailGrandChildRepository.Insert(PurchaseDetailGrandChildesInsert);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }


                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Purchase Details", input.ApplicationId);

            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", PurchaseDetails));
            }
        }

        public async Task<PurchaseDetailListDto> GetPurchaseDetailById(int Id)
        {
            try
            {
                var PurchaseDetail = await _PurchaseDetailRepository.GetAsync(Id);

                return ObjectMapper.Map<PurchaseDetailListDto>(PurchaseDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", PurchaseDetails));
            }
        }

        public async Task<string> UpdatePurchaseDetail(UpdatePurchaseDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var PurchaseDetail = _PurchaseDetailRepository.Get(input.Id);
                if (PurchaseDetail != null && PurchaseDetail.Id > 0)
                {
                    ObjectMapper.Map(input, PurchaseDetail);
                    await _PurchaseDetailRepository.UpdateAsync(PurchaseDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", PurchaseDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", PurchaseDetails));
            }
        }

        public async Task<PurchaseDetailListDto> GetPurchaseDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _PurchaseDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingPurchaseDetail = ObjectMapper.Map<PurchaseDetailListDto>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _PurchaseDetailChildRepository.GetAllList().Where(x => x.Fk_PurchaseDetailId == ExistingPurchaseDetail.Id);

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingPurchaseDetailChilds = ObjectMapper.Map<List<PurchaseDetailChildListDto>>(IsbussinessIncomeChildExist);

                        foreach (var ExistingPurchaseDetailChild in ExistingPurchaseDetailChilds)
                        {
                            var IsbussinessIncomeChildSchoolClass = _PurchaseDetailGrandChildRepository.GetAllList().Where(x => x.Fk_PurchaseDetailChildId == ExistingPurchaseDetailChild.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingPurchaseDetailGrandChildes = ObjectMapper.Map<List<PurchaseDetailGrandChildListDto>>(IsbussinessIncomeChildSchoolClass);
                                ExistingPurchaseDetailChild.PurchaseDetailGrandChild = ExistingPurchaseDetailGrandChildes;
                            }

                            ExistingPurchaseDetail.PurchaseDetailChild = ExistingPurchaseDetailChilds;

                        }
                        return ExistingPurchaseDetail;


                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", PurchaseDetails));
            }
        }

        public bool CheckPurchaseDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _PurchaseDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (IsbussinessIncomeExist != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", PurchaseDetails));
            }
        }
    }
}
