using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.Mobilizations;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.Customs
{
     public  interface ICustomAppService :IAsyncCrudAppService<BccStateListDto, Int32, PagedResultRequestDto, CreateBccStateDto, BccStateListDto>
    {
        Task<bool> GetBccApplicationApprovedStaus(int applicationId);
        Task<double> GetIrr(int nper, double pmt, double pv, double fv, bool type);
        Task<List<GetMobilizationListDto>> getMobilizationListBySP();
    }
}
