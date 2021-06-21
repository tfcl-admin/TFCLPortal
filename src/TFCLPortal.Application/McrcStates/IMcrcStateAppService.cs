using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.McrcStates.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.McrcStates
{
  public  interface IMcrcStateAppService : IApplicationService
    {
        Task<McrcStateListDto> GetMcrcStateListDetailById(int Id);
        void CreateMcrcStateDetail(CreateMcrcStateDto input);
        Task<string> UpdateMcrcState(UpdateMcrcStateDto input);
        Task<List<McrcStateListDto>> GetMcrcStateListByUserId(int UserId);
        Task<List<McrcStateListDto>> GetMcrcStateListByApplicationId(int ApplicationId);
        McrcState UpdateMcrcStateBySDE(UpdateMcrcStateDto input);
        Task<List<McrcStateListDto>> GetMcrcStateListByMcrcId(int id);
    }
}
