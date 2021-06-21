using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FcmTokens.Dto;

namespace TFCLPortal.FcmTokens
{

    public class FcmTokenAppService : TFCLPortalAppServiceBase, IFcmTokenAppService
    {
        private readonly IRepository<FcmToken, Int32> _FcmTokenRepository;
        private string FcmToken = "Fcm Token";

        public FcmTokenAppService(IRepository<FcmToken, Int32> FcmTokenRepository)
        {
            _FcmTokenRepository = FcmTokenRepository;
        }


        public FcmTokenListDto GetFcmTokenById(int Id)
        {
            try
            {
                var FcmTokenvar = _FcmTokenRepository.Get(Id);

                return ObjectMapper.Map<FcmTokenListDto>(FcmTokenvar);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", FcmToken));
            }
        }

        public async Task CreateFcmToken(CreateFcmTokenDto input)
        {
            try
            {
                var FcmTokens = _FcmTokenRepository.GetAllList(x => x.FK_UserId == input.FK_UserId);
                if(FcmTokens!=null)
                {
                    foreach (var FcmToken in FcmTokens)
                    {
                        await _FcmTokenRepository.DeleteAsync(FcmToken);
                        CurrentUnitOfWork.SaveChanges();
                    }
                }

                var FcmTokenvar = ObjectMapper.Map<FcmToken>(input);
                await _FcmTokenRepository.InsertAsync(FcmTokenvar);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", FcmToken));
            }
        }

        public async Task<string> UpdateFcmToken(int UserId,string UpdatedToken)
        {
            string ResponseString = "";
            try
            {
                var FcmTokens = _FcmTokenRepository.GetAllList(x => x.FK_UserId == UserId);
                if (FcmTokens != null)
                {
                    foreach(var FcmToken in FcmTokens)
                    {
                        FcmToken.Token = UpdatedToken;
                        await _FcmTokenRepository.UpdateAsync(FcmToken);
                        CurrentUnitOfWork.SaveChanges();
                    }
                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", FcmToken));
            }
            return ResponseString;
        }

        public async Task<string> getFcmTokenByUserId(int UserId)
        {
            string ResponseString = "";
            try
            {
                var FcmTokens = _FcmTokenRepository.GetAllList(x => x.FK_UserId == UserId);
                if (FcmTokens != null)
                {
                    foreach (var FcmToken in FcmTokens)
                    {
                        ResponseString = FcmToken.Token;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", FcmToken));
            }

            return ResponseString;
        }

        public List<FcmTokenListDto> GetFcmTokenList()
        {
            try
            {
                var FcmTokenvar = _FcmTokenRepository.GetAllList();

                return ObjectMapper.Map<List<FcmTokenListDto>>(FcmTokenvar);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", FcmToken));
            }
        }
    }
}
