using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlows.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlows
{
    public class WorkFlowAppService : TFCLPortalAppServiceBase, IWorkFlowAppService
    {
        private readonly IRepository<WorkFlow, Int32> _workFlowDetailRepository;
        private string WorkFlowDetails = "Work Flow";

        public WorkFlowAppService(IRepository<WorkFlow, Int32> workFlowDetailRepository)
        {
            _workFlowDetailRepository = workFlowDetailRepository;
        }

        public async Task CreateWorkFlow(CreateWorkFlowDto input)
        {
            try
            {
                var workFlowDetail = ObjectMapper.Map<WorkFlow>(input);
                await _workFlowDetailRepository.InsertAsync(workFlowDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", WorkFlowDetails));
            }
        }

        public WorkFlowListDto GetWorkFlowByName(string name)
        {
            try
            {
                var workFlowDetail =  _workFlowDetailRepository.GetAllList().Where(x => x.Name == name).FirstOrDefault();

                return ObjectMapper.Map<WorkFlowListDto>(workFlowDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowDetails));
            }
        }

        public async Task<WorkFlowListDto> GetWorkFlowById(int Id)
        {
            try
            {
                var workFlowDetail = await _workFlowDetailRepository.GetAsync(Id);

                return ObjectMapper.Map<WorkFlowListDto>(workFlowDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", WorkFlowDetails));
            }
        }

        public async Task<string> UpdateWorkFlow(UpdateWorkFlowDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var workFlowDetail = _workFlowDetailRepository.Get(input.Id);
                if (workFlowDetail != null && workFlowDetail.Id > 0)
                {
                    ObjectMapper.Map(input, workFlowDetail);
                    await _workFlowDetailRepository.UpdateAsync(workFlowDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", WorkFlowDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", WorkFlowDetails));
            }
        }
    }
}
