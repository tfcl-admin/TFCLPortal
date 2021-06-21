using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeceasedSettlements.Dto;

namespace TFCLPortal.DeceasedSettlements
{
   public interface IDeceasedSettlementAppService : IApplicationService
    {
        Task<string> Create(CreateDeceasedSettlement createDeceasedSettlement);
        Task<string> Update(EditDeceasedSettlement editDeceasedSettlement);
        Task<DeceasedSettlementListDto> GetDeceasedSettlementById(int Id);
        Task<List<DeceasedSettlementListDto>> GetDeceasedSettlementByApplicationId(int ApplicationId);
        bool CheckDeceasedSettlementByApplicationId(int ApplicationId);
        Task<List<DeceasedSettlementListDto>> GetAllDeceasedSettlements();
    }
}
