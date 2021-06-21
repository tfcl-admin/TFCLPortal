using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.BccDecisions.Dto;

namespace TFCLPortal.BccDecisions
{

    public class BccDecisionAppService : TFCLPortalAppServiceBase, IBccDecisionAppService
    {
        private readonly IRepository<BccDecision, Int32> _BccDecisionRepository;
        private string bcc = "Bcc Decision";
        private readonly IApplicationAppService _applicationAppService;

        public BccDecisionAppService(IRepository<BccDecision, Int32> bccDecisionRepository, IApplicationAppService applicationAppService)
        {
            _BccDecisionRepository = bccDecisionRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateBccDecision(CreateBccDecisionDto input)
        {
            try
            {
                var BccDecision = ObjectMapper.Map<BccDecision>(input);
                await _BccDecisionRepository.InsertAsync(BccDecision);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", bcc));
            }
        }

        public BccDecisionListDto GetBccDecisionById(int Id)
        {
            try
            {
                var BccDecision = _BccDecisionRepository.Get(Id);


                return ObjectMapper.Map<BccDecisionListDto>(BccDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bcc));
            }
        }

        public async Task<string> UpdateBccDecision(UpdateBccDecisionDto input)
        {
            string ResponseString = "";
            try
            {
                var BccDecision = _BccDecisionRepository.Get(input.Id);
                if (BccDecision != null && BccDecision.Id > 0)
                {
                    ObjectMapper.Map(input, BccDecision);
                    await _BccDecisionRepository.UpdateAsync(BccDecision);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", bcc));
            }
            return ResponseString;
        }
        public List<BccDecisionListDto> GetBccDecisionList()
        {
            try
            {
                var BccDecision = _BccDecisionRepository.GetAllList().OrderByDescending(x => x.CreationTime);

                return ObjectMapper.Map<List<BccDecisionListDto>>(BccDecision);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bcc));
            }
        }
    }
}
