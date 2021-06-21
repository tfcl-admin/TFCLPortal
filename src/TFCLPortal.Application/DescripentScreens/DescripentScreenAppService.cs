using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DescripentScreens.Dto;

namespace TFCLPortal.DescripentScreens
{
    public class DescripentScreenAppService : TFCLPortalAppServiceBase, IDescripentScreenAppService
    {
        private readonly IRepository<DescripentScreen, Int32> _descripentScreenRepository;
        private string DescripentScreens = "Descripent Screen";
        public DescripentScreenAppService(IRepository<DescripentScreen, Int32> descripentScreenRepository)
        {
            _descripentScreenRepository = descripentScreenRepository;
        }

        public async Task CreateDescripentScreen(CreateDescripentScreenDto input)
        {
            try
            {
                var DescripentScreen = ObjectMapper.Map<DescripentScreen>(input);
                await _descripentScreenRepository.InsertAsync(DescripentScreen);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", DescripentScreens));
            }
        }

        public DescripentScreenListDto GetDescripentScreenByApplicationId(int ApplicationId,int Fk_screenId ,string ScreenStatus )
        {
            try
            {
                var DescripentScreen = _descripentScreenRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId&&x.Fk_ScreenId==Fk_screenId&&x.ScreenStatus.Trim().ToLower()==ScreenStatus.Trim().ToLower()).FirstOrDefault();

                return ObjectMapper.Map<DescripentScreenListDto>(DescripentScreen);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", DescripentScreens));
            }
        }



        public DescripentScreenListDto GetDescripentScreenById(int Id)
        {
            try
            {
                var DescripentScreen = _descripentScreenRepository.Get(Id);

                return ObjectMapper.Map<DescripentScreenListDto>(DescripentScreen);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", DescripentScreens));
            }
        }

        public async Task<string> UpdateDescripentScreen(UpdateDescripentScreenDto input)
        {
            string ResponseString = "";
            try
            {
                var DescripentScreen = _descripentScreenRepository.Get(input.Id);
                if (DescripentScreen != null && DescripentScreen.Id > 0)
                {
                    ObjectMapper.Map(input, DescripentScreen);
                    await _descripentScreenRepository.UpdateAsync(DescripentScreen);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", DescripentScreens));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", DescripentScreens));
            }
        }
    }
}
