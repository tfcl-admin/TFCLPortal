using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.Mobilizations;
using TFCLPortal.MobilizationsLogs.Dto;
using TFCLPortal.Users;


namespace TFCLPortal.MobilizationsLogs
{
    public class MobilizationsLogAppService : TFCLPortalAppServiceBase, IMobilizationsLogAppService
    {
        private readonly IRepository<Mobilization, Int32> _mobilizationRepository;
        private readonly IRepository<MobilizationStatus> _mobStatusRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<MobilizationsLog, Int32> _mobilizationsLogRepository;
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;
        private string mobilizationLog = "Mobilizations Log";

        public MobilizationsLogAppService(IRepository<Mobilization> mobilizationRepository,
             IRepository<MobilizationStatus> mobStatusRepository,
             IRepository<ProductType> productTypeRepository,
             IUserAppService userAppService,
             IRepository<MobilizationsLog> mobilizationLogRepository,
             UserManager userManager)
        {
            _mobilizationRepository = mobilizationRepository;
            _mobStatusRepository = mobStatusRepository;
            _productTypeRepository = productTypeRepository;
            _userAppService = userAppService;
            _userManager = userManager;
            _mobilizationsLogRepository = mobilizationLogRepository;
        }

        public MobilizationsLogResponse CreateMobilizationsLog(CreateMobilizationsLogDto input)
        {          

            var objmobilizationsLog = ObjectMapper.Map<MobilizationsLog>(input);
            var mob = _mobilizationsLogRepository.InsertAsync(objmobilizationsLog);
            CurrentUnitOfWork.SaveChanges();

            MobilizationsLogResponse Response = new MobilizationsLogResponse();
            Response.CreatedDateTime = DateTime.Now;
            Response.Message = "Success";

            return Response;
        }
        public List<MobilizationsLogListDto> GetMobilizationsLogList()
        {
                var mobilizationsLogList = _mobilizationsLogRepository.GetAllList();
                return ObjectMapper.Map<List<MobilizationsLogListDto>>(mobilizationsLogList);
        }
    }
}
