using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BranchManagerActions.Dto;

namespace TFCLPortal.BranchManagerActions
{
    public class BranchManagerActionAppService : TFCLPortalAppServiceBase, IBranchManagerActionAppService
    {
        private readonly IRepository<BranchManagerAction, Int32> _branchManagerActionRepository;
        private string branch = "Branch Manager Action";

        public BranchManagerActionAppService(IRepository<BranchManagerAction, Int32> branchManagerActionRepository)
        {
            _branchManagerActionRepository = branchManagerActionRepository;
        }
        public async Task CreateBranchManagerAction(CreateBranchManagerActionDto input)
        {
            try
            {
                var branchManagerAction = ObjectMapper.Map<BranchManagerAction>(input);
                await _branchManagerActionRepository.InsertAsync(branchManagerAction);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", branch));
            }
        }

        public string DeleteBranchManagerAction(BranchManagerActionListDto input)
        {
            string ResponseString = "";
            try
            {
                var branchDetail = _branchManagerActionRepository.Get(input.Id);
                if (branchDetail != null && branchDetail.Id > 0)
                {
                    //ObjectMapper.Map(input, branchDetail);
                    //BranchManagerAction bma = new BranchManagerAction();
                    //bma.Id=id
                    _branchManagerActionRepository.Delete(branchDetail);
                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Success";
                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", branch));
            }
            return ResponseString;
        }

        public List<BranchManagerActionListDto> GetBranchManagerActionByApplicationId(int ApplicationId)
        {
            try
            {
                var branchManagerAction = _branchManagerActionRepository.GetAllList(x=>x.ApplicationId==ApplicationId);

                return ObjectMapper.Map<List<BranchManagerActionListDto>>(branchManagerAction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }

        public BranchManagerActionListDto GetBranchManagerActionById(int Id)
        {
            try 
            {
                var branchManagerAction = _branchManagerActionRepository.Get(Id);

                return ObjectMapper.Map<BranchManagerActionListDto>(branchManagerAction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }

        public List<BranchManagerActionListDto> GetBranchManagerActionListDetail()
        {
            try
            {
                var branchManagerAction = _branchManagerActionRepository.GetAllList();

                return ObjectMapper.Map<List<BranchManagerActionListDto>>(branchManagerAction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }

        public List<DiscrepentScreensListDto> getDiscrepentedForms(int ApplicationId)
        {
            try
            {
                List<DiscrepentScreensListDto> returnList = new List<DiscrepentScreensListDto>();
                
                var branchManagerAction = _branchManagerActionRepository.GetAllList(x => x.ApplicationId == ApplicationId && x.ActionType == "Discrepent" && x.isActive == true && x.isReSubmitted == false);
                foreach(var item in branchManagerAction)
                {
                    DiscrepentScreensListDto obj = new DiscrepentScreensListDto();
                    obj.ScreenName = item.ScreenName;
                    obj.Reason = item.Reason;
                    obj.DateOfDiscrepency = item.CreationTime;
                    returnList.Add(obj);
                }

                return returnList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }

        public async Task<string> UpdateBranchManagerAction(UpdateBranchMangerActionDto input)
        {
            string ResponseString = "";
            try
            {
                var branchDetail = _branchManagerActionRepository.Get(input.Id);
                if (branchDetail != null && branchDetail.Id > 0)
                {
                    ObjectMapper.Map(input, branchDetail);
                    await _branchManagerActionRepository.UpdateAsync(branchDetail);
                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Success";
                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", branch));
            }
            return ResponseString;
        }


    }
}
