using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FinalWorkflows.Dto;

namespace TFCLPortal.FinalWorkflows
{
    public class FinalWorkflowAppService : TFCLPortalAppServiceBase, IFinalWorkflowAppService
    {
        private readonly IRepository<FinalWorkflow, int> _FinalWorkflowRepository;

        public FinalWorkflowAppService(IRepository<FinalWorkflow, int> FinalWorkflowRepository)
        {
            _FinalWorkflowRepository = FinalWorkflowRepository;
        }
        public async Task<string> CreateFinalWorkflow(CreateFinalWorkflowDto Input)
        {
            try
            {
                var existingFinalWorkflows = _FinalWorkflowRepository.GetAllList(x => x.ApplicationId == Input.ApplicationId);
                if (existingFinalWorkflows != null)
                {
                    var existingFinalWorkflowsList = ObjectMapper.Map<List<FinalWorkflow>>(existingFinalWorkflows);

                    foreach (var existingFinalWorkflow in existingFinalWorkflowsList)
                    {
                        existingFinalWorkflow.isActive = false;
                        _FinalWorkflowRepository.Update(existingFinalWorkflow);
                    }
                }

                var WorkFlow = ObjectMapper.Map<FinalWorkflow>(Input);
                await _FinalWorkflowRepository.InsertAsync(WorkFlow);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        //public string CreateFinalWorkflow(CreateFinalWorkflowDto Input, bool test)
        //{
        //    try
        //    {
        //        var existingFinalWorkflows = _FinalWorkflowRepository.GetAllList(x => x.ApplicationId == Input.ApplicationId);
        //        if (existingFinalWorkflows != null)
        //        {
        //            var existingFinalWorkflowsList = ObjectMapper.Map<List<FinalWorkflow>>(existingFinalWorkflows);

        //            foreach (var existingFinalWorkflow in existingFinalWorkflowsList)
        //            {
        //                existingFinalWorkflow.isActive = false;
        //                _FinalWorkflowRepository.Update(existingFinalWorkflow);
        //            }
        //        }

        //        var WorkFlow = ObjectMapper.Map<FinalWorkflow>(Input);
        //        _FinalWorkflowRepository.Insert(WorkFlow);

        //    }
        //    catch (Exception ex)
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}

        public List<FinalWorkflowListDto> GetAllList()
        {
            try
            {
                var fileTypeList = _FinalWorkflowRepository.GetAllList();
                return ObjectMapper.Map<List<FinalWorkflowListDto>>(fileTypeList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Final Workflow"));
            }
        }

        public List<FinalWorkflowListDto> GetFinalWorkflowByApplicationId(int ApplicationId)
        {
            try
            {
                var fileTypeList = _FinalWorkflowRepository.GetAllList(x => x.ApplicationId == ApplicationId);
                return ObjectMapper.Map<List<FinalWorkflowListDto>>(fileTypeList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Final Workflow"));
            }
        }

        public FinalWorkflowListDto GetLastFinalWorkflowByApplicationId(int ApplicationId)
        {
            try
            {
                var fileTypeList = _FinalWorkflowRepository.GetAllList(x=>x.isActive==true && x.ApplicationId==ApplicationId);
                return ObjectMapper.Map<FinalWorkflowListDto>(fileTypeList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Final Workflow"));
            }
        }
    }
}
