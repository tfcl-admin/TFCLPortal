using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.EarlySettlements.Dto;

namespace TFCLPortal.EarlySettlements
{
   public interface IEarlySettlementAppService : IApplicationService
    {
        Task<string> Create(CreateEarlySettlement createEarlySettlement);
        Task<string> Update(EditEarlySettlement editEarlySettlement);
        Task<EarlySettlementListDto> GetEarlySettlementById(int Id);
        Task<List<EarlySettlementListDto>> GetEarlySettlementByApplicationId(int ApplicationId);
        bool CheckEarlySettlementByApplicationId(int ApplicationId);
        Task<List<EarlySettlementListDto>> GetAllEarlySettlements();
    }
}
