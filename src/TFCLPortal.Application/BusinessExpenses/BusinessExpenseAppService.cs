using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.BusinessExpenses.Dto;
using TFCLPortal.BusinessExpenseSchoolAcademies;
using TFCLPortal.BusinessExpenseSchoolAcademyClasses;
using TFCLPortal.BusinessExpenseSchoolClasses;
using TFCLPortal.BusinessExpenseSchools;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.BusinessExpenses
{
    public class BusinessExpenseAppService : TFCLPortalAppServiceBase, IBusinessExpenseAppService
    {
        private readonly IRepository<Gender, Int32> _genderRepository;
        private readonly IRepository<Designation, Int32> _designationRepository;
        private readonly IRepository<BusinessExpense, Int32> _businessExpenseRepository;
        private readonly IRepository<BusinessExpenseSchool, Int32> _businessExpenseSchoolRepository;
        private readonly IRepository<BusinessExpenseSchoolClass, Int32> _businessExpenseSchoolClassRepository;
        private readonly IRepository<BusinessExpenseSchoolAcademy, Int32> _businessExpenseSchoolAcademyRepository;
        private readonly IRepository<BusinessExpenseSchoolAcademyClass, Int32> _businessExpenseSchoolAcademyClassRepository;
        private readonly IApplicationAppService _applicationAppService;
        private string BusinessExpenses = "BusinessExpense";
        public BusinessExpenseAppService(IRepository<BusinessExpense, Int32> businessExpenseRepository,
            IRepository<BusinessExpenseSchool, Int32> businessExpenseSchoolRepository,
            IRepository<Gender, Int32> genderRepository,
            IRepository<Designation, Int32> designationRepository,
            IRepository<BusinessExpenseSchoolClass, Int32> businessExpenseSchoolClassRepository,
            IRepository<BusinessExpenseSchoolAcademy, Int32> businessExpenseSchoolAcademyRepository,
            IRepository<BusinessExpenseSchoolAcademyClass, Int32> businessExpenseSchoolAcademyClassRepository,
            IApplicationAppService applicationAppService
            )
        {
            _businessExpenseRepository = businessExpenseRepository;
            _businessExpenseSchoolRepository = businessExpenseSchoolRepository;
            _businessExpenseSchoolClassRepository = businessExpenseSchoolClassRepository;
            _businessExpenseSchoolAcademyRepository = businessExpenseSchoolAcademyRepository;
            _businessExpenseSchoolAcademyClassRepository = businessExpenseSchoolAcademyClassRepository;
            _genderRepository = genderRepository;
            _designationRepository = designationRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateBusinessExpense(CreateBusinessExpenseDto input)
        {
            try
            {
                var IsbusinessExpenseExist = _businessExpenseRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsbusinessExpenseExist != null)
                {
                    var ExistingbusinessExpense = ObjectMapper.Map<BusinessExpense>(IsbusinessExpenseExist);
                    var IsbusinessExpenseChildExist = _businessExpenseSchoolRepository.GetAllList().Where(x => x.Fk_BusinessExpense == ExistingbusinessExpense.Id).ToList();

                    if (IsbusinessExpenseChildExist != null)
                    {
                        var ExistingbusinessExpenseSchools = ObjectMapper.Map<List<BusinessExpenseSchool>>(IsbusinessExpenseChildExist);
                        foreach (var ExistingbusinessExpenseSchool in ExistingbusinessExpenseSchools)
                        {

                            var IsbusinessExpenseChildSchoolClass = _businessExpenseSchoolClassRepository.GetAllList().Where(x => x.Fk_BusinessExpenseSchool == ExistingbusinessExpenseSchool.Id).ToList();

                            if (IsbusinessExpenseChildSchoolClass != null)
                            {
                                var ExistingbusinessExpenseSchoolClasses = ObjectMapper.Map<List<BusinessExpenseSchoolClass>>(IsbusinessExpenseChildSchoolClass);
                                foreach (var ExistingbusinessExpenseSchoolClass in ExistingbusinessExpenseSchoolClasses)
                                {
                                    _businessExpenseSchoolClassRepository.Delete(ExistingbusinessExpenseSchoolClass);
                                }
                            }

                            var IsbusinessExpenseChildAcademys = _businessExpenseSchoolAcademyRepository.GetAllList().Where(x => x.Fk_BusinessExpenseSchool == ExistingbusinessExpenseSchool.Id).ToList();
                            if (IsbusinessExpenseChildAcademys != null)
                            {
                                var ExistingbusinessExpenseSchoolAcademys = ObjectMapper.Map<List<BusinessExpenseSchoolAcademy>>(IsbusinessExpenseChildAcademys);

                                foreach (var ExistingbusinessExpenseSchoolAcademy in ExistingbusinessExpenseSchoolAcademys)
                                {
                                    var IsbusinessExpenseChildAcademyClasses = _businessExpenseSchoolAcademyClassRepository.GetAllList().Where(x => x.Fk_BusinessExpenseSchoolAcademy == ExistingbusinessExpenseSchoolAcademy.Id).ToList();
                                    if (IsbusinessExpenseChildAcademyClasses != null)
                                    {
                                        var ExistingbusinessExpenseSchoolAcademyClasses = ObjectMapper.Map<List<BusinessExpenseSchoolAcademyClass>>(IsbusinessExpenseChildAcademyClasses);
                                        foreach (var ExistingbusinessExpenseSchoolAcademyClass in ExistingbusinessExpenseSchoolAcademyClasses)
                                        {
                                            _businessExpenseSchoolAcademyClassRepository.Delete(ExistingbusinessExpenseSchoolAcademyClass);
                                        }
                                    }

                                    _businessExpenseSchoolAcademyRepository.Delete(ExistingbusinessExpenseSchoolAcademy);

                                }

                            }

                            _businessExpenseSchoolRepository.Delete(ExistingbusinessExpenseSchool);

                        }
                    }

                    _businessExpenseRepository.Delete(ExistingbusinessExpense);

                }

                var businessExpense = ObjectMapper.Map<BusinessExpense>(input);
                var result = _businessExpenseRepository.Insert(businessExpense);
                CurrentUnitOfWork.SaveChanges();
                if (input.businessExpenseSchool.Count > 0) // schools Count
                {
                    List<CreateBusinessExpenseSchoolDto> businessExpenseSchoolDtos = input.businessExpenseSchool;
                    foreach (var businessExpenseSchoolDto in businessExpenseSchoolDtos)
                    {
                        businessExpenseSchoolDto.Fk_BusinessExpense = result.Id;
                        var exposureDetailchild = ObjectMapper.Map<BusinessExpenseSchool>(businessExpenseSchoolDto);
                        var businessChildresult = _businessExpenseSchoolRepository.Insert(exposureDetailchild);
                        CurrentUnitOfWork.SaveChanges();

                        if (businessExpenseSchoolDto.businessExpenseSchoolClasses.Count > 0)// schools Classes Count
                        {
                            List<CreateBusinessExpenseSchoolClassesDto> businessExpenseSchoolClasses = businessExpenseSchoolDto.businessExpenseSchoolClasses;
                            foreach (var businessExpenseSchoolClass in businessExpenseSchoolClasses)
                            {
                                businessExpenseSchoolClass.Fk_BusinessExpenseSchool = businessChildresult.Id;
                                var businessExpenseSchoolClassesInsert = ObjectMapper.Map<BusinessExpenseSchoolClass>(businessExpenseSchoolClass);
                                _businessExpenseSchoolClassRepository.Insert(businessExpenseSchoolClassesInsert);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }

                        if (businessExpenseSchoolDto.businessExpenseSchoolAcademies.Count > 0)// Academies Count
                        {
                            List<CreateBusinessExpenseSchoolAcademiesDto> businessExpenseSchoolAcademies = businessExpenseSchoolDto.businessExpenseSchoolAcademies;
                            foreach (var businessExpenseSchoolAcademy in businessExpenseSchoolAcademies)
                            {
                                businessExpenseSchoolAcademy.Fk_BusinessExpenseSchool = businessChildresult.Id;
                                var businessExpenseSchoolAcademiesInsert = ObjectMapper.Map<BusinessExpenseSchoolAcademy>(businessExpenseSchoolAcademy);
                                var insertedAcademy = _businessExpenseSchoolAcademyRepository.Insert(businessExpenseSchoolAcademiesInsert);
                                CurrentUnitOfWork.SaveChanges();

                                if (businessExpenseSchoolAcademy.businessExpenseSchoolAcademyClasses.Count > 0)
                                {
                                    List<CreateBusinessExpenseSchoolAcademyClassesDto> businessExpenseSchoolAcademyClasses = businessExpenseSchoolAcademy.businessExpenseSchoolAcademyClasses;
                                    foreach (var businessExpenseSchoolAcademyClass in businessExpenseSchoolAcademyClasses)
                                    {
                                        businessExpenseSchoolAcademyClass.Fk_BusinessExpenseSchoolAcademy = insertedAcademy.Id;
                                        var businessExpenseAcademyClassesInsert = ObjectMapper.Map<BusinessExpenseSchoolAcademyClass>(businessExpenseSchoolAcademyClass);
                                        _businessExpenseSchoolAcademyClassRepository.Insert(businessExpenseAcademyClassesInsert);
                                        CurrentUnitOfWork.SaveChanges();
                                    }

                                }

                            }
                        }

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Business Expense", input.ApplicationId);

            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", BusinessExpenses));
            }
        }

        public async Task<BusinessExpenseListDto> GetBusinessExpenseById(int Id)
        {
            try
            {
                var businessExpense = await _businessExpenseRepository.GetAsync(Id);

                return ObjectMapper.Map<BusinessExpenseListDto>(businessExpense);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BusinessExpenses));
            }
        }

        public async Task<string> UpdateBusinessExpense(UpdateBusinessExpenseDto input)
        {
            string ResponseString = "";
            try
            {
                var businessExpense = _businessExpenseRepository.Get(input.Id);
                if (businessExpense != null && businessExpense.Id > 0)
                {
                    ObjectMapper.Map(input, businessExpense);
                    await _businessExpenseRepository.UpdateAsync(businessExpense);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", BusinessExpenses));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", BusinessExpenses));
            }
        }

        public async Task<BusinessExpenseListDto> GetBusinessExpenseByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _businessExpenseRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingBusinessExpense = ObjectMapper.Map<BusinessExpenseListDto>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _businessExpenseSchoolRepository.GetAllList(x => x.Fk_BusinessExpense == ExistingBusinessExpense.Id);

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingBusinessExpenseSchools = ObjectMapper.Map<List<BusinessExpenseSchoolListDto>>(IsbussinessIncomeChildExist);

                        foreach (var ExistingBusinessExpenseSchool in ExistingBusinessExpenseSchools)
                        {
                            var IsbussinessIncomeChildSchoolClass = _businessExpenseSchoolClassRepository.GetAllList(x => x.Fk_BusinessExpenseSchool == ExistingBusinessExpenseSchool.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingBusinessExpenseSchoolClasses = ObjectMapper.Map<List<BusinessExpenseSchoolClassesListDto>>(IsbussinessIncomeChildSchoolClass);

                                foreach(var ExistingBusinessExpenseSchoolClass in ExistingBusinessExpenseSchoolClasses)
                                {
                                    if (ExistingBusinessExpenseSchoolClass.Designation != null && ExistingBusinessExpenseSchoolClass.Designation!=0)
                                    {
                                        var designation = _designationRepository.Get((int)ExistingBusinessExpenseSchoolClass.Designation);
                                        ExistingBusinessExpenseSchoolClass.DesignationName = designation.Name;
                                    }
                                    if (ExistingBusinessExpenseSchoolClass.Gender != null && ExistingBusinessExpenseSchoolClass.Gender != 0)
                                    {
                                        var Gender = _genderRepository.Get((int)ExistingBusinessExpenseSchoolClass.Gender);
                                        ExistingBusinessExpenseSchoolClass.GenderName = Gender.Name;
                                    }

                                }

                                ExistingBusinessExpenseSchool.businessExpenseSchoolClasses = ExistingBusinessExpenseSchoolClasses;
                            }

                            var IsbussinessIncomeChildAcademys = _businessExpenseSchoolAcademyRepository.GetAllList(x => x.Fk_BusinessExpenseSchool == ExistingBusinessExpenseSchool.Id).ToList();
                            if (IsbussinessIncomeChildAcademys != null)
                            {
                                var ExistingBusinessExpenseSchoolAcademys = ObjectMapper.Map<List<BusinessExpenseSchoolAcademiesListDto>>(IsbussinessIncomeChildAcademys);

                                foreach (var ExistingBusinessExpenseSchoolAcademy in ExistingBusinessExpenseSchoolAcademys)
                                {
                                    var IsbussinessIncomeChildAcademyClasses = _businessExpenseSchoolAcademyClassRepository.GetAllList(x => x.Fk_BusinessExpenseSchoolAcademy == ExistingBusinessExpenseSchoolAcademy.Id).ToList();
                                    if (IsbussinessIncomeChildAcademyClasses != null)
                                    {
                                        var ExistingBusinessExpenseSchoolAcademyClasses = ObjectMapper.Map<List<BusinessExpenseSchoolAcademyClassesListDto>>(IsbussinessIncomeChildAcademyClasses);

                                        foreach (var ExistingBusinessExpenseSchoolAcademyClass in ExistingBusinessExpenseSchoolAcademyClasses)
                                        {
                                            if (ExistingBusinessExpenseSchoolAcademyClass.Designation != null && ExistingBusinessExpenseSchoolAcademyClass.Designation != 0)
                                            {
                                                var designation = _designationRepository.Get((int)ExistingBusinessExpenseSchoolAcademyClass.Designation);
                                                ExistingBusinessExpenseSchoolAcademyClass.DesignationName = designation.Name;
                                            }
                                            if (ExistingBusinessExpenseSchoolAcademyClass.Gender != null && ExistingBusinessExpenseSchoolAcademyClass.Gender != 0)
                                            {
                                                var Gender = _genderRepository.Get((int)ExistingBusinessExpenseSchoolAcademyClass.Gender);
                                                ExistingBusinessExpenseSchoolAcademyClass.GenderName = Gender.Name;
                                            }

                                        }

                                        ExistingBusinessExpenseSchoolAcademy.businessExpenseSchoolAcademyClasses = ExistingBusinessExpenseSchoolAcademyClasses;
                                    }
                                    ExistingBusinessExpenseSchool.businessExpenseSchoolAcademies= ExistingBusinessExpenseSchoolAcademys;

                                }
                            }
                            ExistingBusinessExpense.businessExpenseSchool = ExistingBusinessExpenseSchools;

                        }
                        return ExistingBusinessExpense;


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
                throw new UserFriendlyException(L("GetMethodError{0}", BusinessExpenses));
            }
        }

        public bool CheckBusinessExpenseByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _businessExpenseRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
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
                throw new UserFriendlyException(L("GetMethodError{0}", BusinessExpenses));
            }
        }
    }
}
