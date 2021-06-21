using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ForSDES.Dto;

namespace TFCLPortal.ForSDES
{
   public interface IForSDEAppService : IApplicationService
    {
        Task<string> Create(CreateForSDEInput createForSDEInput);
        Task<string> Update(EditForSDEInput editForSDEInput);
        Task<ForSDEListDto> GetForSDEById(int Id);
        Task<ForSDEListDto> GetForSDEByApplicationId(int ApplicationId);
        bool CheckForSDEByApplicationId(int ApplicationId);
    }
}
