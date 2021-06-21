using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.McrcDecisions.Dto;

namespace TFCLPortal.McrcDecisions
{

    public class McrcDecisionAppService : TFCLPortalAppServiceBase, IMcrcDecisionAppService
    {
        private readonly IRepository<McrcDecision, Int32> _McrcDecisionRepository;
        private string Mcrc = "Mcrc Decision";
        private readonly IApplicationAppService _applicationAppService;

        public McrcDecisionAppService(IRepository<McrcDecision, Int32> McrcDecisionRepository, IApplicationAppService applicationAppService)
        {
            _McrcDecisionRepository = McrcDecisionRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateMcrcDecision(CreateMcrcDecisionDto input)
        {
            try
            {
                var McrcDecision = ObjectMapper.Map<McrcDecision>(input);
                await _McrcDecisionRepository.InsertAsync(McrcDecision);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", Mcrc));
            }
        }

        public McrcDecisionListDto GetMcrcDecisionById(int Id)
        {
            try
            {
                var McrcDecision = _McrcDecisionRepository.Get(Id);


                return ObjectMapper.Map<McrcDecisionListDto>(McrcDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Mcrc));
            }
        }

        public async Task<string> UpdateMcrcDecision(UpdateMcrcDecisionDto input)
        {
            string ResponseString = "";
            try
            {
                var McrcDecision = _McrcDecisionRepository.Get(input.Id);
                if (McrcDecision != null && McrcDecision.Id > 0)
                {
                    ObjectMapper.Map(input, McrcDecision);
                    await _McrcDecisionRepository.UpdateAsync(McrcDecision);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Mcrc));
            }
            return ResponseString;
        }
        public List<McrcDecisionListDto> GetMcrcDecisionList()
        {
            try
            {
                var McrcDecision = _McrcDecisionRepository.GetAllList().OrderByDescending(x => x.CreationTime);

                return ObjectMapper.Map<List<McrcDecisionListDto>>(McrcDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Mcrc));
            }
        }
    }
}
