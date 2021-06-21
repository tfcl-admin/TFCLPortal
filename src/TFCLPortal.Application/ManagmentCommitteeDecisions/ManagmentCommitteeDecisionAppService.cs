using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ManagmentCommitteeDecisions.Dto;

namespace TFCLPortal.ManagmentCommitteeDecisions
{

    public class ManagmentCommitteeDecisionAppService : TFCLPortalAppServiceBase, IManagmentCommitteeDecisionAppService
    {
        private readonly IRepository<ManagmentCommitteeDecision, Int32> _ManagmentCommitteeDecisionRepository;
        private string bcc = "Managment Committee Decision";
        private readonly IApplicationAppService _applicationAppService;

        public ManagmentCommitteeDecisionAppService(IRepository<ManagmentCommitteeDecision, Int32> ManagmentCommitteeDecisionRepository, IApplicationAppService applicationAppService)
        {
            _ManagmentCommitteeDecisionRepository = ManagmentCommitteeDecisionRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateManagmentCommitteeDecision(CreateManagmentCommitteeDecisionDto input)
        {
            try
            {
                var ManagmentCommitteeDecision = ObjectMapper.Map<ManagmentCommitteeDecision>(input);
                await _ManagmentCommitteeDecisionRepository.InsertAsync(ManagmentCommitteeDecision);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", bcc));
            }
        }

        public ManagmentCommitteeDecisionListDto GetManagmentCommitteeDecisionById(int Id)
        {
            try
            {
                var ManagmentCommitteeDecision = _ManagmentCommitteeDecisionRepository.Get(Id);


                return ObjectMapper.Map<ManagmentCommitteeDecisionListDto>(ManagmentCommitteeDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bcc));
            }
        }

        public async Task<string> UpdateManagmentCommitteeDecision(UpdateManagmentCommitteeDecisionDto input)
        {
            string ResponseString = "";
            try
            {
                var ManagmentCommitteeDecision = _ManagmentCommitteeDecisionRepository.Get(input.Id);
                if (ManagmentCommitteeDecision != null && ManagmentCommitteeDecision.Id > 0)
                {
                    ObjectMapper.Map(input, ManagmentCommitteeDecision);
                    await _ManagmentCommitteeDecisionRepository.UpdateAsync(ManagmentCommitteeDecision);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", bcc));
            }
            return ResponseString;
        }
        public List<ManagmentCommitteeDecisionListDto> GetManagmentCommitteeDecisionList()
        {
            try
            {
                var ManagmentCommitteeDecision = _ManagmentCommitteeDecisionRepository.GetAllList().OrderByDescending(x => x.CreationTime);

                return ObjectMapper.Map<List<ManagmentCommitteeDecisionListDto>>(ManagmentCommitteeDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bcc));
            }
        }
    }
}
