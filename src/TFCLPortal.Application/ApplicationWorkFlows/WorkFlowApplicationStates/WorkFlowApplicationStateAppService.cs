using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates
{
    public class WorkFlowApplicationStateAppService : TFCLPortalAppServiceBase, IWorkFlowApplicationStateAppService
    {
        private readonly IRepository<WorkFlowApplicationState, Int32> _WorkFlowApplicationState;
        private string WorkFlowApplicationStateDetails = "WorkFlow Application State";
        public WorkFlowApplicationStateAppService(IRepository<WorkFlowApplicationState, Int32> WorkFlowApplicationState)
        {
            _WorkFlowApplicationState = WorkFlowApplicationState;
        }
        public async Task CreateWorkFlowApplicationState(CreateWorkFlowApplicationStateDto input)
        {
            try
            {
                var WorkFlowApplication = ObjectMapper.Map<WorkFlowApplicationState>(input);
                _WorkFlowApplicationState.Insert(WorkFlowApplication);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }

        public async Task<WorkFlowApplicationStateListDto> GetWorkFlowApplicationStateDetailById(int Id)
        {
            try
            {
                var WorkFlowApplication = await _WorkFlowApplicationState.GetAsync(Id);

                return ObjectMapper.Map<WorkFlowApplicationStateListDto>(WorkFlowApplication);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }

        public async Task<WorkFlowApplicationStateListDto> GetWorkFlowApplicationStateListByApplicationId(int ApplicationId)
        {
            try
            {
                var WorkFlowApplication = _WorkFlowApplicationState.GetAllList().Where(x => x.Id == ApplicationId).FirstOrDefault();

                return ObjectMapper.Map<WorkFlowApplicationStateListDto>(WorkFlowApplication);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }


        public WorkFlowApplicationStateListDto GetLastActiveWorkFlow(int ApplicationId)
        {
            try
            {
                var WorkFlowApplication = _WorkFlowApplicationState.GetAllList().Where(x => x.ApplicationId == ApplicationId).LastOrDefault();

                return ObjectMapper.Map<WorkFlowApplicationStateListDto>(WorkFlowApplication);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }

        public WorkFlowApplicationStateListDto GetLastActiveWorkFlowByState(int ApplicationId,string State)
        {
            try
            {
                var WorkFlowApplication = _WorkFlowApplicationState.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.Status==State).LastOrDefault();

                return ObjectMapper.Map<WorkFlowApplicationStateListDto>(WorkFlowApplication);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }

        public async Task<string> UpdateWorkFlowApplicationState(UpdateWorkFlowApplicationStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var WorkFlowApplication = _WorkFlowApplicationState.Get(input.Id);
                if (WorkFlowApplication != null && WorkFlowApplication.Id > 0)
                {
                    ObjectMapper.Map(input, WorkFlowApplication);
                     _WorkFlowApplicationState.Update(WorkFlowApplication);
                     CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", WorkFlowApplicationStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", WorkFlowApplicationStateDetails));
            }
        }
    }
}
