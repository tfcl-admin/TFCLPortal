using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TFCLPortal.BusinessIncomeAcademyClasses;
using TFCLPortal.BusinessIncomeSchoolAcademies;
using TFCLPortal.BusinessIncomeSchools;
using TFCLPortal.BusinessIncomes.Dto;
using TFCLPortal.BusinessIncomeSchoolClasses;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.Applications;

namespace TFCLPortal.BusinessIncomes
{
    public class BusinessIncomeAppService : TFCLPortalAppServiceBase, IBusinessIncomeAppService
    {
        private readonly IRepository<BusinessIncome, Int32> _businessIncomeRepository;
        private readonly IRepository<BusinessIncomeSchool, Int32> _businessChildRepository;
        private readonly IRepository<BusinessIncomeSchoolClass, Int32> _businessIncomeSchoolClassRepository;
        private readonly IRepository<BusinessIncomeSchoolAcademy, Int32> _BusinessIncomeSchoolAcademyRepository;
        private readonly IRepository<BusinessIncomeSchoolAcademyClass, Int32> _BusinessIncomeSchoolAcademyClassRepository;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IApplicationAppService _applicationAppService;

        private string businessIncomes = "Business Income";
        public BusinessIncomeAppService(
            IRepository<BusinessIncome, Int32> businessIncomeRepository,
            IRepository<BusinessIncomeSchool, Int32> businessChildRepository,
            IRepository<BusinessIncomeSchoolClass, Int32> businessIncomeSchoolClassRepository,
            IRepository<BusinessIncomeSchoolAcademy, Int32> BusinessIncomeSchoolAcademyRepository,
            IRepository<BusinessIncomeSchoolAcademyClass, Int32> BusinessIncomeSchoolAcademyClassRepository,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IApplicationAppService applicationAppService
            )
        {
            _businessIncomeRepository = businessIncomeRepository;
            _businessChildRepository = businessChildRepository;
            _applicationAppService = applicationAppService;
            _businessIncomeSchoolClassRepository = businessIncomeSchoolClassRepository;
            _BusinessIncomeSchoolAcademyRepository = BusinessIncomeSchoolAcademyRepository;
            _BusinessIncomeSchoolAcademyClassRepository = BusinessIncomeSchoolAcademyClassRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }
        public async Task CreateBusinessIncome(CreateBusinessIncomeDto input)
        {
            try
            {
                var IsbussinessIncomeExist = _businessIncomeRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingBusinessIncome = ObjectMapper.Map<BusinessIncome>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _businessChildRepository.GetAllList().Where(x => x.Fk_BusinessIncome == ExistingBusinessIncome.Id).ToList();

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingBusinessIncomeSchools = ObjectMapper.Map<List<BusinessIncomeSchool>>(IsbussinessIncomeChildExist);
                        foreach (var ExistingBusinessIncomeSchool in ExistingBusinessIncomeSchools)
                        {

                            var IsbussinessIncomeChildSchoolClass = _businessIncomeSchoolClassRepository.GetAllList().Where(x => x.Fk_BusinessIncomeChild == ExistingBusinessIncomeSchool.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingBusinessIncomeSchoolClasses = ObjectMapper.Map<List<BusinessIncomeSchoolClass>>(IsbussinessIncomeChildSchoolClass);
                                foreach (var ExistingBusinessIncomeSchoolClass in ExistingBusinessIncomeSchoolClasses)
                                {
                                    _businessIncomeSchoolClassRepository.Delete(ExistingBusinessIncomeSchoolClass);
                                }
                            }

                            var IsbussinessIncomeChildAcademys = _BusinessIncomeSchoolAcademyRepository.GetAllList().Where(x => x.Fk_BusinessIncomeChild == ExistingBusinessIncomeSchool.Id).ToList();
                            if (IsbussinessIncomeChildAcademys != null)
                            {
                                var ExistingBusinessIncomeSchoolAcademys = ObjectMapper.Map<List<BusinessIncomeSchoolAcademy>>(IsbussinessIncomeChildAcademys);

                                foreach (var ExistingBusinessIncomeSchoolAcademy in ExistingBusinessIncomeSchoolAcademys)
                                {
                                    var IsbussinessIncomeChildAcademyClasses = _BusinessIncomeSchoolAcademyClassRepository.GetAllList().Where(x => x.Fk_BusinessIncomeChildAcademy == ExistingBusinessIncomeSchoolAcademy.Id).ToList();
                                    if (IsbussinessIncomeChildAcademyClasses != null)
                                    {
                                        var ExistingBusinessIncomeSchoolAcademyClasses = ObjectMapper.Map<List<BusinessIncomeSchoolAcademyClass>>(IsbussinessIncomeChildAcademyClasses);
                                        foreach (var ExistingBusinessIncomeSchoolAcademyClass in ExistingBusinessIncomeSchoolAcademyClasses)
                                        {
                                            _BusinessIncomeSchoolAcademyClassRepository.Delete(ExistingBusinessIncomeSchoolAcademyClass);
                                        }
                                    }

                                    _BusinessIncomeSchoolAcademyRepository.Delete(ExistingBusinessIncomeSchoolAcademy);

                                }

                            }

                            _businessChildRepository.Delete(ExistingBusinessIncomeSchool);

                        }
                    }

                    _businessIncomeRepository.Delete(ExistingBusinessIncome);

                }

                var businessIncome = ObjectMapper.Map<BusinessIncome>(input);
                var result = _businessIncomeRepository.Insert(businessIncome);
                CurrentUnitOfWork.SaveChanges();
                if (input.businessChildLists.Count > 0) // schools Count
                {
                    List<CreateBusinessIncomeSchoolDto> BusinessIncomeSchoolDtos = input.businessChildLists;
                    foreach (var BusinessIncomeSchoolDto in BusinessIncomeSchoolDtos)
                    {
                        BusinessIncomeSchoolDto.Fk_BusinessIncome = result.Id;
                        var exposureDetailchild = ObjectMapper.Map<BusinessIncomeSchool>(BusinessIncomeSchoolDto);
                        var businessChildresult = _businessChildRepository.Insert(exposureDetailchild);
                        CurrentUnitOfWork.SaveChanges();

                        if (BusinessIncomeSchoolDto.BusinessIncomeSchoolClasses.Count > 0)// schools Classes Count
                        {
                            List<CreateBusinessIncomeSchoolClassesDto> businessIncomeSchoolClasses = BusinessIncomeSchoolDto.BusinessIncomeSchoolClasses;
                            foreach (var businessIncomeSchoolClass in businessIncomeSchoolClasses)
                            {
                                businessIncomeSchoolClass.Fk_BusinessIncomeChild = businessChildresult.Id;
                                var businessIncomeSchoolClassesInsert = ObjectMapper.Map<BusinessIncomeSchoolClass>(businessIncomeSchoolClass);
                                _businessIncomeSchoolClassRepository.Insert(businessIncomeSchoolClassesInsert);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }

                        if (BusinessIncomeSchoolDto.BusinessIncomeSchoolAcademies.Count > 0)// Academies Count
                        {
                            List<CreateBusinessIncomeSchoolAcademyDto> BusinessIncomeSchoolAcademies = BusinessIncomeSchoolDto.BusinessIncomeSchoolAcademies;
                            foreach (var BusinessIncomeSchoolAcademy in BusinessIncomeSchoolAcademies)
                            {
                                BusinessIncomeSchoolAcademy.Fk_BusinessIncomeChild = businessChildresult.Id;
                                var BusinessIncomeSchoolAcademiesInsert = ObjectMapper.Map<BusinessIncomeSchoolAcademy>(BusinessIncomeSchoolAcademy);
                                var insertedAcademy = _BusinessIncomeSchoolAcademyRepository.Insert(BusinessIncomeSchoolAcademiesInsert);
                                CurrentUnitOfWork.SaveChanges();

                                if (BusinessIncomeSchoolAcademy.BusinessIncomeSchoolAcademyClasses.Count > 0)
                                {
                                    List<CreateBusinessIncomeSchoolAcademyClassesDto> BusinessIncomeSchoolAcademyClasses = BusinessIncomeSchoolAcademy.BusinessIncomeSchoolAcademyClasses;
                                    foreach (var BusinessIncomeSchoolAcademyClass in BusinessIncomeSchoolAcademyClasses)
                                    {
                                        BusinessIncomeSchoolAcademyClass.Fk_BusinessIncomeChildAcademy = insertedAcademy.Id;
                                        var businessIncomeAcademyClassesInsert = ObjectMapper.Map<BusinessIncomeSchoolAcademyClass>(BusinessIncomeSchoolAcademyClass);
                                        _BusinessIncomeSchoolAcademyClassRepository.Insert(businessIncomeAcademyClassesInsert);
                                        CurrentUnitOfWork.SaveChanges();
                                    }

                                }

                            }
                        }

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Business Income", input.ApplicationId);

            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", businessIncomes));
            }
        }
        public async Task<BusinessIncomeListDto> GetBusinessIncomeById(int Id)
        {
            try
            {
                var businessIncome = await _businessIncomeRepository.GetAsync(Id);
                var result = ObjectMapper.Map<BusinessIncomeListDto>(businessIncome);
                //if (result != null)
                //{
                //    var ExposureChild = _businessChildRepository.GetAllList(i => i.Fk_BusinessIncome == Id);
                //    var MapexposureDetailAddDto = ObjectMapper.Map<List<BusinessChlidListDto>>(ExposureChild);
                //    result.businessChlid = MapexposureDetailAddDto;
                //}
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", businessIncomes));
            }
        }
        public async Task<string> UpdateBusinessIncome(UpdateBusinessIncomeDto input)
        {
            string ResponseString = "";
            try
            {
                var businessIncome = _businessIncomeRepository.Get(input.Id);
                if (businessIncome != null && businessIncome.Id > 0)
                {
                    ObjectMapper.Map(input, businessIncome);
                    await _businessIncomeRepository.UpdateAsync(businessIncome);
                    CurrentUnitOfWork.SaveChanges();

                    if (input.updatebusinesschild.Count > 0)
                    {
                        foreach (var child in input.updatebusinesschild)
                        {
                            var detailChild = _businessChildRepository.Get(child.Id);
                            ObjectMapper.Map(child, detailChild);
                            await _businessChildRepository.UpdateAsync(detailChild);
                            CurrentUnitOfWork.SaveChanges();

                        }
                    }
                    ResponseString = "Records Updated Successfully";

                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", businessIncomes));
            }
            return ResponseString;
        }
        public BusinessIncomeListDto GetBusinessIncomeByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _businessIncomeRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingBusinessIncome = ObjectMapper.Map<BusinessIncomeListDto>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _businessChildRepository.GetAllList(x => x.Fk_BusinessIncome == ExistingBusinessIncome.Id);

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingBusinessIncomeSchools = ObjectMapper.Map<List<BusinessIncomeSchoolListDto>>(IsbussinessIncomeChildExist);

                        foreach (var ExistingBusinessIncomeSchool in ExistingBusinessIncomeSchools)
                        {
                            var IsbussinessIncomeChildSchoolClass = _businessIncomeSchoolClassRepository.GetAllList(x => x.Fk_BusinessIncomeChild == ExistingBusinessIncomeSchool.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingBusinessIncomeSchoolClasses = ObjectMapper.Map<List<BusinessIncomeSchoolClassesListDto>>(IsbussinessIncomeChildSchoolClass);
                                ExistingBusinessIncomeSchool.BusinessIncomeSchoolClasses = ExistingBusinessIncomeSchoolClasses;
                            }

                            var IsbussinessIncomeChildAcademys = _BusinessIncomeSchoolAcademyRepository.GetAllList(x => x.Fk_BusinessIncomeChild == ExistingBusinessIncomeSchool.Id).ToList();
                            if (IsbussinessIncomeChildAcademys != null)
                            {
                                var ExistingBusinessIncomeSchoolAcademys = ObjectMapper.Map<List<BusinessIncomeSchoolAcademiesListDto>>(IsbussinessIncomeChildAcademys);

                                foreach (var ExistingBusinessIncomeSchoolAcademy in ExistingBusinessIncomeSchoolAcademys)
                                {
                                    var IsbussinessIncomeChildAcademyClasses = _BusinessIncomeSchoolAcademyClassRepository.GetAllList(x => x.Fk_BusinessIncomeChildAcademy == ExistingBusinessIncomeSchoolAcademy.Id).ToList();
                                    if (IsbussinessIncomeChildAcademyClasses != null)
                                    {
                                        var ExistingBusinessIncomeSchoolAcademyClasses = ObjectMapper.Map<List<BusinessIncomeSchoolAcademyClassesListDto>>(IsbussinessIncomeChildAcademyClasses);
                                        ExistingBusinessIncomeSchoolAcademy.BusinessIncomeSchoolAcademyClasses = ExistingBusinessIncomeSchoolAcademyClasses;
                                    }
                                    ExistingBusinessIncomeSchool.BusinessIncomeSchoolAcademies = ExistingBusinessIncomeSchoolAcademys;

                                }
                            }
                            ExistingBusinessIncome.businessChildLists = ExistingBusinessIncomeSchools;

                        }

                        var deviation = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(ApplicationId);
                        if (deviation != null)
                        {
                            ExistingBusinessIncome.AllowedMinStudents = deviation.MinStudentEnrolled;
                        }

                        return ExistingBusinessIncome;


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
                throw new UserFriendlyException(L("GetMethodError{0}", businessIncomes));
            }
        }

        public bool CheckBusinessIncomeByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _businessIncomeRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
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
                throw new UserFriendlyException(L("GetMethodError{0}", businessIncomes));
            }
        }
    }
}


