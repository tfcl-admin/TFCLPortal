using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.BccDecisions;
using TFCLPortal.ManagmentCommitteeDecisions.Dto;
using TFCLPortal.McrcDecisions;
using TFCLPortal.Users;

namespace TFCLPortal.ManagmentCommitteeDecisions
{

    public class ManagmentCommitteeDecisionAppService : TFCLPortalAppServiceBase, IManagmentCommitteeDecisionAppService
    {
        private readonly IRepository<ManagmentCommitteeDecision, Int32> _ManagmentCommitteeDecisionRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IRepository<McrcDecision, Int32> _McrcDecisionRepository;
        private readonly IRepository<BccDecision, Int32> _BccDecisionRepository;
        private string bcc = "Managment Committee Decision";
        private readonly IApplicationAppService _applicationAppService;
        private readonly IUserAppService _userAppService;

        public ManagmentCommitteeDecisionAppService(IRepository<BccDecision, Int32> BccDecisionRepository,IRepository<McrcDecision, Int32> McrcDecisionRepository,IUserAppService userAppService,IRepository<Applicationz, Int32> applicationRepository,IRepository<ManagmentCommitteeDecision, Int32> ManagmentCommitteeDecisionRepository, IApplicationAppService applicationAppService)
        {
            _userAppService = userAppService;
            _ManagmentCommitteeDecisionRepository = ManagmentCommitteeDecisionRepository;
            _applicationAppService = applicationAppService;
            _applicationRepository = applicationRepository;
            _BccDecisionRepository = BccDecisionRepository;
            _McrcDecisionRepository = McrcDecisionRepository;
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
                var result= ObjectMapper.Map<List<ManagmentCommitteeDecisionListDto>>(ManagmentCommitteeDecision);
                var applications = _applicationRepository.GetAllList();
                var users = _userAppService.GetAllUsers();
                var mcrcDecisions = _McrcDecisionRepository.GetAllList(x => x.Decision == "Approve");
                var bccDecisions = _BccDecisionRepository.GetAllList(x => x.Decision == "Approve");

                foreach (var mc in result)
                {
                    var application = applications.Where(x => x.Id == mc.ApplicationId).FirstOrDefault();
                    if(application!=null)
                    {
                        mc.ClientID = application.ClientID;
                        mc.ClientName = application.ClientName;
                        mc.SchoolName = application.SchoolName;
                        mc.State = application.ScreenStatus;
                        mc.State = application.ScreenStatus;
                        mc.productType = application.ProductType;

                        var mcrcDecision = mcrcDecisions.Where(x => x.ApplicationId == mc.ApplicationId).ToList();
                        if(mcrcDecision.Count>0)
                        {
                            mc.BccApprovalDate = mcrcDecision.LastOrDefault().LastModificationTime;
                        }
                        else
                        {
                            var bccDecision = bccDecisions.Where(x => x.ApplicationId == mc.ApplicationId).ToList();
                            if (bccDecision.Count > 0)
                            {
                                mc.BccApprovalDate = bccDecision.LastOrDefault().CreationTime;
                            }
                        }

                    }
                    var user = users.Where(x => x.Id == mc.fk_userid).FirstOrDefault();
                    if(user!=null)
                    {
                        mc.Username = user.FullName;
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bcc));
            }
        }
    }
}
