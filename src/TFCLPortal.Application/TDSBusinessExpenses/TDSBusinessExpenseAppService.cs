using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.TDSBusinessExpenses.Dto;
using TFCLPortal.DynamicDropdowns.Designations;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.TDSBusinessExpenses
{
    public class TDSBusinessExpenseAppService : TFCLPortalAppServiceBase, ITDSBusinessExpenseAppService
    {
        private readonly IRepository<Gender, Int32> _genderRepository;
        private readonly IRepository<Designation, Int32> _designationRepository;
        private readonly IRepository<TDSBusinessExpense, Int32> _TDSBusinessExpenseRepository;
        private readonly IRepository<TDSBusinessExpenseChild, Int32> _TDSBusinessExpenseChildRepository;
        private readonly IRepository<TDSBusinessExpenseGrandChild, Int32> _TDSBusinessExpenseGrandChildRepository;
        private readonly IApplicationAppService _applicationAppService;
        private string TDSBusinessExpenses = "TDSBusinessExpense";
        public TDSBusinessExpenseAppService(IRepository<TDSBusinessExpense, Int32> TDSBusinessExpenseRepository,
            IRepository<TDSBusinessExpenseChild, Int32> TDSBusinessExpenseChildRepository,
            IRepository<Gender, Int32> genderRepository,
            IRepository<Designation, Int32> designationRepository,
            IRepository<TDSBusinessExpenseGrandChild, Int32> TDSBusinessExpenseGrandChildRepository,
            IApplicationAppService applicationAppService
            )
        {
            _TDSBusinessExpenseRepository = TDSBusinessExpenseRepository;
            _TDSBusinessExpenseChildRepository = TDSBusinessExpenseChildRepository;
            _TDSBusinessExpenseGrandChildRepository = TDSBusinessExpenseGrandChildRepository;
            _genderRepository = genderRepository;
            _designationRepository = designationRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateTDSBusinessExpense(CreateTDSBusinessExpenseDto input)
        {
            try
            {
                var IsTDSBusinessExpenseExist = _TDSBusinessExpenseRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsTDSBusinessExpenseExist != null)
                {
                    var ExistingTDSBusinessExpense = ObjectMapper.Map<TDSBusinessExpense>(IsTDSBusinessExpenseExist);
                    var IsTDSBusinessExpenseChildExist = _TDSBusinessExpenseChildRepository.GetAllList().Where(x => x.Fk_TDSBusinessExpenseid == ExistingTDSBusinessExpense.Id).ToList();

                    if (IsTDSBusinessExpenseChildExist != null)
                    {
                        var ExistingTDSBusinessExpenseChilds = ObjectMapper.Map<List<TDSBusinessExpenseChild>>(IsTDSBusinessExpenseChildExist);
                        foreach (var ExistingTDSBusinessExpenseChild in ExistingTDSBusinessExpenseChilds)
                        {

                            var IsTDSBusinessExpenseChildSchoolClass = _TDSBusinessExpenseGrandChildRepository.GetAllList().Where(x => x.Fk_TDSBusinessExpenseChildid == ExistingTDSBusinessExpenseChild.Id).ToList();

                            if (IsTDSBusinessExpenseChildSchoolClass != null)
                            {
                                var ExistingTDSBusinessExpenseGrandChildes = ObjectMapper.Map<List<TDSBusinessExpenseGrandChild>>(IsTDSBusinessExpenseChildSchoolClass);
                                foreach (var ExistingTDSBusinessExpenseGrandChild in ExistingTDSBusinessExpenseGrandChildes)
                                {
                                    _TDSBusinessExpenseGrandChildRepository.Delete(ExistingTDSBusinessExpenseGrandChild);
                                }
                            }
                             

                            _TDSBusinessExpenseChildRepository.Delete(ExistingTDSBusinessExpenseChild);

                        }
                    }

                    _TDSBusinessExpenseRepository.Delete(ExistingTDSBusinessExpense);

                }

                var TDSBusinessExpense = ObjectMapper.Map<TDSBusinessExpense>(input);
                var result = _TDSBusinessExpenseRepository.Insert(TDSBusinessExpense);
                CurrentUnitOfWork.SaveChanges();
                if (input.TDSBusinessExpenseChild.Count > 0) // schools Count
                {
                    List<CreateTDSBusinessExpenseChildDto> TDSBusinessExpenseChildDtos = input.TDSBusinessExpenseChild;
                    foreach (var TDSBusinessExpenseChildDto in TDSBusinessExpenseChildDtos)
                    {
                        TDSBusinessExpenseChildDto.Fk_TDSBusinessExpenseid = result.Id;
                        var exposureDetailchild = ObjectMapper.Map<TDSBusinessExpenseChild>(TDSBusinessExpenseChildDto);
                        var businessChildresult = _TDSBusinessExpenseChildRepository.Insert(exposureDetailchild);
                        CurrentUnitOfWork.SaveChanges();

                        if (TDSBusinessExpenseChildDto.TDSBusinessExpenseGrandChilds.Count > 0)// schools Classes Count
                        {
                            List<CreateTDSBusinessExpenseGrandChildDto> TDSBusinessExpenseGrandChildes = TDSBusinessExpenseChildDto.TDSBusinessExpenseGrandChilds;
                            foreach (var TDSBusinessExpenseGrandChild in TDSBusinessExpenseGrandChildes)
                            {
                                TDSBusinessExpenseGrandChild.Fk_TDSBusinessExpenseChildid = businessChildresult.Id;
                                var TDSBusinessExpenseGrandChildesInsert = ObjectMapper.Map<TDSBusinessExpenseGrandChild>(TDSBusinessExpenseGrandChild);
                                _TDSBusinessExpenseGrandChildRepository.Insert(TDSBusinessExpenseGrandChildesInsert);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }
                         

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Business Expense", input.ApplicationId);

            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", TDSBusinessExpenses));
            }
        }

        public async Task<TDSBusinessExpenseListDto> GetTDSBusinessExpenseById(int Id)
        {
            try
            {
                var TDSBusinessExpense = await _TDSBusinessExpenseRepository.GetAsync(Id);

                return ObjectMapper.Map<TDSBusinessExpenseListDto>(TDSBusinessExpense);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TDSBusinessExpenses));
            }
        }

        public async Task<string> UpdateTDSBusinessExpense(UpdateTDSBusinessExpenseDto input)
        {
            string ResponseString = "";
            try
            {
                var TDSBusinessExpense = _TDSBusinessExpenseRepository.Get(input.Id);
                if (TDSBusinessExpense != null && TDSBusinessExpense.Id > 0)
                {
                    ObjectMapper.Map(input, TDSBusinessExpense);
                    await _TDSBusinessExpenseRepository.UpdateAsync(TDSBusinessExpense);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", TDSBusinessExpenses));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", TDSBusinessExpenses));
            }
        }

        public async Task<TDSBusinessExpenseListDto> GetTDSBusinessExpenseByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _TDSBusinessExpenseRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                if (IsbussinessIncomeExist != null)
                {
                    var ExistingTDSBusinessExpense = ObjectMapper.Map<TDSBusinessExpenseListDto>(IsbussinessIncomeExist);
                    var IsbussinessIncomeChildExist = _TDSBusinessExpenseChildRepository.GetAllList().Where(x => x.Fk_TDSBusinessExpenseid == ExistingTDSBusinessExpense.Id);

                    if (IsbussinessIncomeChildExist != null)
                    {
                        var ExistingTDSBusinessExpenseChilds = ObjectMapper.Map<List<TDSBusinessExpenseChildListDto>>(IsbussinessIncomeChildExist);

                        foreach (var ExistingTDSBusinessExpenseChild in ExistingTDSBusinessExpenseChilds)
                        {
                            var IsbussinessIncomeChildSchoolClass = _TDSBusinessExpenseGrandChildRepository.GetAllList().Where(x => x.Fk_TDSBusinessExpenseChildid == ExistingTDSBusinessExpenseChild.Id).ToList();

                            if (IsbussinessIncomeChildSchoolClass != null)
                            {
                                var ExistingTDSBusinessExpenseGrandChildes = ObjectMapper.Map<List<TDSBusinessExpenseGrandChildListDto>>(IsbussinessIncomeChildSchoolClass);
 

                                ExistingTDSBusinessExpenseChild.TDSBusinessExpenseGrandChilds = ExistingTDSBusinessExpenseGrandChildes;
                            }
                             
                            ExistingTDSBusinessExpense.TDSBusinessExpenseChild = ExistingTDSBusinessExpenseChilds;

                        }
                        return ExistingTDSBusinessExpense;


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
                throw new UserFriendlyException(L("GetMethodError{0}", TDSBusinessExpenses));
            }
        }

        public bool CheckTDSBusinessExpenseByApplicationId(int ApplicationId)
        {
            try
            {
                var IsbussinessIncomeExist = _TDSBusinessExpenseRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
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
                throw new UserFriendlyException(L("GetMethodError{0}", TDSBusinessExpenses));
            }
        }
    }
}
