using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TdsInventoryDetails.Dto;

namespace TFCLPortal.TdsInventoryDetails
{
    public interface ITdsInventoryDetailAppService : IApplicationService
    {
        Task<string> CreateTdsInventoryDetails(CreateTdsInventoryDetailDto input);
        Task<TdsInventoryDetailListDto> GetTdsInventoryDetailDetailByApplicationId(int Id);
        bool CheckTdsInventoryDetailDetailByApplicationId(int Id);
    }
}
