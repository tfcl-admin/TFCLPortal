using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BccStates
{
  public  interface IBccStateAppService : IApplicationService
    {
        Task<BccStateListDto> GetBccStateListDetailById(int Id);
        string CreateBccStateDetail(CreateBccStateDto input);
        Task<string> UpdateBccState(UpdateBccStateDto input);
        Task<List<BccStateListDto>> GetBccStateListByUserId(int UserId);
        Task<List<BccStateListDto>> GetBccStateListByApplicationId(int ApplicationId);
        BccState UpdateBccStateBySDE(UpdateBccStateDto input);
        Task<List<BccStateListDto>> GetBccStateListByBCCId(int id);
    }
}
