using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.SalesDetails.Dto;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.SalesDetails
{
    public class SalesDetailAppService : TFCLPortalAppServiceBase, ISalesDetailAppService
    {
        private readonly IRepository<Gender, Int32> _genderRepository;
        private readonly IRepository<Designation, Int32> _designationRepository;
        private readonly IRepository<SalesDetail, Int32> _SalesDetailRepository;
        private readonly IRepository<SalesDetailChild, Int32> _SalesDetailChildRepository;
        private readonly IRepository<SalesDetailGrandChild, Int32> _SalesDetailGrandChildRepository;
        private readonly IApplicationAppService _applicationAppService;
        private string SalesDetails = "Sales Detail";
        public SalesDetailAppService(IRepository<SalesDetail, Int32> SalesDetailRepository,
            IRepository<SalesDetailChild, Int32> SalesDetailChildRepository,
            IRepository<Gender, Int32> genderRepository,
            IRepository<Designation, Int32> designationRepository,
            IRepository<SalesDetailGrandChild, Int32> SalesDetailGrandChildRepository,
            IApplicationAppService applicationAppService
            )
        {
            _SalesDetailRepository = SalesDetailRepository;
            _SalesDetailChildRepository = SalesDetailChildRepository;
            _SalesDetailGrandChildRepository = SalesDetailGrandChildRepository;
            _genderRepository = genderRepository;
            _designationRepository = designationRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateSalesDetail(CreateSalesDetailDto input)
        {
            try
            {
                var IsSalesDetailExist = _SalesDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsSalesDetailExist != null)
                {
                    var ExistingSalesDetail = ObjectMapper.Map<SalesDetail>(IsSalesDetailExist);
                    var IsSalesDetailChildExist = _SalesDetailChildRepository.GetAllList().Where(x => x.Fk_SalesDetailId == ExistingSalesDetail.Id).ToList();

                    if (IsSalesDetailChildExist != null)
                    {
                        var ExistingSalesDetailChilds = ObjectMapper.Map<List<SalesDetailChild>>(IsSalesDetailChildExist);
                        foreach (var ExistingSalesDetailChild in ExistingSalesDetailChilds)
                        {

                            var IsSalesDetailChildSchoolClass = _SalesDetailGrandChildRepository.GetAllList().Where(x => x.Fk_SalesDetailChildId == ExistingSalesDetailChild.Id).ToList();

                            if (IsSalesDetailChildSchoolClass != null)
                            {
                                var ExistingSalesDetailGrandChildes = ObjectMapper.Map<List<SalesDetailGrandChild>>(IsSalesDetailChildSchoolClass);
                                foreach (var ExistingSalesDetailGrandChild in ExistingSalesDetailGrandChildes)
                                {
                                    _SalesDetailGrandChildRepository.Delete(ExistingSalesDetailGrandChild);
                                }
                            }

                            _SalesDetailChildRepository.Delete(ExistingSalesDetailChild);

                        }
                    }

                    _SalesDetailRepository.Delete(ExistingSalesDetail);

                }

                var SalesDetail = ObjectMapper.Map<SalesDetail>(input);
                var result = _SalesDetailRepository.Insert(SalesDetail);
                CurrentUnitOfWork.SaveChanges();
                if (input.SalesDetailChild.Count > 0) // schools Count
                {
                    List<CreateSalesDetailChildDto> SalesDetailChildDtos = input.SalesDetailChild;
                    foreach (var SalesDetailChildDto in SalesDetailChildDtos)
                    {
                        SalesDetailChildDto.Fk_SalesDetailId = result.Id;
                        var exposureDetailchild = ObjectMapper.Map<SalesDetailChild>(SalesDetailChildDto);
                        var businessChildresult = _SalesDetailChildRepository.Insert(exposureDetailchild);
                        CurrentUnitOfWork.SaveChanges();

                        if (SalesDetailChildDto.SalesDetailGrandChild.Count > 0)// schools Classes Count
                        {
                            List<CreateSalesDetailGrandChildDto> SalesDetailGrandChildes = SalesDetailChildDto.SalesDetailGrandChild;
                            foreach (var SalesDetailGrandChild in SalesDetailGrandChildes)
                            {
                                SalesDetailGrandChild.Fk_SalesDetailChildId = businessChildresult.Id;
                                var SalesDetailGrandChildesInsert = ObjectMapper.Map<SalesDetailGrandChild>(SalesDetailGrandChild);
                                _SalesDetailGrandChildRepository.Insert(SalesDetailGrandChildesInsert);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }


                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Sales Details", input.ApplicationId);

            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", SalesDetails));
            }
        }

        public async Task<SalesDetailListDto> GetSalesDetailById(int Id)
        {
            try
            {
                var SalesDetail = await _SalesDetailRepository.GetAsync(Id);

                return ObjectMapper.Map<SalesDetailListDto>(SalesDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", SalesDetails));
            }
        }

        public async Task<string> UpdateSalesDetail(UpdateSalesDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var SalesDetail = _SalesDetailRepository.Get(input.Id);
                if (SalesDetail != null && SalesDetail.Id > 0)
                {
                    ObjectMapper.Map(input, SalesDetail);
                    await _SalesDetailRepository.UpdateAsync(SalesDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", SalesDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", SalesDetails));
            }
        }

        public async Task<SalesDetailListDto> GetSalesDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _SalesDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingSalesDetail = ObjectMapper.Map<SalesDetailListDto>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _SalesDetailChildRepository.GetAllList().Where(x => x.Fk_SalesDetailId == ExistingSalesDetail.Id);

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingSalesDetailChilds = ObjectMapper.Map<List<SalesDetailChildListDto>>(IsbussinessIncomeChildExist);

                        foreach (var ExistingSalesDetailChild in ExistingSalesDetailChilds)
                        {
                            var IsbussinessIncomeChildSchoolClass = _SalesDetailGrandChildRepository.GetAllList().Where(x => x.Fk_SalesDetailChildId == ExistingSalesDetailChild.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingSalesDetailGrandChildes = ObjectMapper.Map<List<SalesDetailGrandChildListDto>>(IsbussinessIncomeChildSchoolClass);
                                ExistingSalesDetailChild.SalesDetailGrandChild = ExistingSalesDetailGrandChildes;
                            }

                            ExistingSalesDetail.SalesDetailChild = ExistingSalesDetailChilds;

                        }
                        return ExistingSalesDetail;


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
                throw new UserFriendlyException(L("GetMethodError{0}", SalesDetails));
            }
        }

        public bool CheckSalesDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _SalesDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
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
                throw new UserFriendlyException(L("GetMethodError{0}", SalesDetails));
            }
        }
    }
}
