using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.WriteOffs.Dto;

namespace TFCLPortal.WriteOffs
{
   public interface IWriteOffAppService : IApplicationService
    {
        Task<string> Create(CreateWriteOff createWriteOff);
        Task<string> Update(EditWriteOff editWriteOff);
        Task<WriteOffListDto> GetWriteOffById(int Id);
        Task<List<WriteOffListDto>> GetWriteOffByApplicationId(int ApplicationId);
        bool CheckWriteOffByApplicationId(int ApplicationId);
        Task<List<WriteOffListDto>> GetAllWriteOffs();
    }
}
