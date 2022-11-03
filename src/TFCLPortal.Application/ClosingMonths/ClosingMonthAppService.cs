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
using TFCLPortal.Branches;
using TFCLPortal.ClosingMonths.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.ClosingMonths
{
    public class ClosingMonthAppService : TFCLPortalAppServiceBase, IClosingMonthAppService
    {
        private readonly IRepository<ClosingMonth, Int32> _ClosingMonthRepository;
        private readonly IRepository<Branch, Int32> _BranchRepository;
        private string ClosingMonths = "Closing Month";
        public ClosingMonthAppService(IRepository<Branch, Int32> BranchRepository,IRepository<ClosingMonth, Int32> ClosingMonthRepository)
        {
            _BranchRepository = BranchRepository;
            _ClosingMonthRepository = ClosingMonthRepository;
        }
        public async Task<string> CreateClosingMonth(CreateClosingMonthDto input)
        {
            string ResponseString = "";

            try
            {
                var IsExist = _ClosingMonthRepository.GetAllList().Where(x => x.BranchId == input.BranchId).FirstOrDefault();

                if (IsExist != null && IsExist.BranchId > 0)
                {
                    var ClosingMonthget = _ClosingMonthRepository.Get(IsExist.Id);
                    await _ClosingMonthRepository.DeleteAsync(ClosingMonthget);
                }

                var ClosingMonth = ObjectMapper.Map<ClosingMonth>(input);
                await _ClosingMonthRepository.InsertAsync(ClosingMonth);

                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", ClosingMonths));
            }
        }

        public ClosingMonthListDto GetClosingMonthByBranchId(int Id)
        {
            try
            {
                var IsExist = _ClosingMonthRepository.GetAllList().Where(x => x.BranchId == Id).FirstOrDefault();
                var ClosingMonth = ObjectMapper.Map<ClosingMonthListDto>(IsExist);

                if(ClosingMonth!=null)
                {
                    var branches = _BranchRepository.GetAllList();
                    var currBranch = branches.Where(x => x.Id == ClosingMonth.BranchId).FirstOrDefault();
                    if (currBranch != null)
                    {
                        ClosingMonth.BranchName = currBranch.BranchName;
                        ClosingMonth.BranchCode = currBranch.BranchCode;
                    }
                    ClosingMonth.MonthName = getMonthName(ClosingMonth.Month);
                }


                return ClosingMonth;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", ClosingMonths));
            }
        }
        public List<ClosingMonthListDto> GetAllClosingMonths()
        {
            try
            {
                var IsExist = _ClosingMonthRepository.GetAllList();
                var ClosingMonth = ObjectMapper.Map<List<ClosingMonthListDto>>(IsExist);
                
                if(ClosingMonth.Count>0)
                {
                    var branches = _BranchRepository.GetAllList();
                    foreach(var branch in ClosingMonth)
                    {
                        var currBranch = branches.Where(x => x.Id == branch.BranchId).FirstOrDefault();
                        if(currBranch!=null)
                        {
                            branch.BranchName = currBranch.BranchName;
                            branch.BranchCode = currBranch.BranchCode;
                        }

                        branch.MonthName = getMonthName(branch.Month);
                       
                    }
                }

                return ClosingMonth;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", ClosingMonths));
            }
        }

        public string getMonthName(int num)
        {
            switch (num)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10:  return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "Error";
            }
        }

        public string updateClosingMonth(int Id, int BranchId)
        {
            try
            {
                var IsExist = _ClosingMonthRepository.GetAllList().Where(x => x.BranchId == BranchId).FirstOrDefault();
                if (IsExist != null)
                {
                    IsExist.Month++;
                    if(IsExist.Month>12)
                    {
                        IsExist.Month = 1;
                        IsExist.Year++;
                    }

                    _ClosingMonthRepository.Update(IsExist);
                }

                return "Done";
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", ClosingMonths));
            }
        }

        public bool checkIfOpen(int BranchId, int CurrMonth, int CurrYear)
        {
            var closingMonth = _ClosingMonthRepository.GetAllList(x => x.BranchId == BranchId).FirstOrDefault();
            if(closingMonth.Year==CurrYear)
            {
                if(closingMonth.Month>=CurrMonth)
                {
                        return true;
                }
                else
                {
                    return false;
                }
            }
            else if(closingMonth.Year > CurrYear) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
