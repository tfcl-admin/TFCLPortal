using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FcmTokens.Dto;

namespace TFCLPortal.FcmTokens
{

    public interface IFcmTokenAppService : IApplicationService
    {
        FcmTokenListDto GetFcmTokenById(int Id);
        Task CreateFcmToken(CreateFcmTokenDto input);
        Task<string> UpdateFcmToken(int UserId, string UpdatedToken);
        Task<string> getFcmTokenByUserId(int UserId);
        List<FcmTokenListDto> GetFcmTokenList();
    }
}
