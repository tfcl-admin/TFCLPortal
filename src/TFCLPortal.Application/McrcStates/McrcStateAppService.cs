using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.McrcStates.Dto;
using TFCLPortal.Customs;

namespace TFCLPortal.McrcStates
{
   
    public class McrcStateAppService : TFCLPortalAppServiceBase, IMcrcStateAppService
    {

        private readonly IRepository<McrcState, Int32> _McrcStateRepository;
        private readonly ICustomAppService _customAppService;
        private string McrcStateDetails = "Mcrc State Detail";

        public McrcStateAppService(IRepository<McrcState, Int32> McrcStateRepository,
            ICustomAppService customAppService) 
        {
            _McrcStateRepository = McrcStateRepository;
            _customAppService = customAppService;
        }
        public void CreateMcrcStateDetail(CreateMcrcStateDto input)
        {
            try
            {
                var McrcStateDetail = ObjectMapper.Map<McrcState>(input);
                 _McrcStateRepository.Insert(McrcStateDetail);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", McrcStateDetails));
            }
        }

        public async Task<List<McrcStateListDto>> GetMcrcStateListByApplicationId(int ApplicationId)
        {
            try
            {
                var McrcStateDetail = _McrcStateRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId);

                return ObjectMapper.Map<List<McrcStateListDto>>(McrcStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcStateDetails));
            }
        }

        public async Task<List<McrcStateListDto>> GetMcrcStateListByUserId(int UserId)
        {
            try
            {
                var McrcStateDetail = _McrcStateRepository.GetAllList().Where(x => x.ApplicationId == UserId);

                return ObjectMapper.Map<List<McrcStateListDto>>(McrcStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcStateDetails));
            }
        }

        public async Task<List<McrcStateListDto>> GetMcrcStateListByMcrcId(int id)
        {
            try
            {
                var McrcStateDetail = _McrcStateRepository.GetAllList().Where(x => x.Fk_McrcId == id).FirstOrDefault();

                return ObjectMapper.Map<List<McrcStateListDto>>(McrcStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcStateDetails));
            }
        }

        public async Task<McrcStateListDto> GetMcrcStateListDetailById(int Id)
        {
            try
            {
                var McrcStateDetail = await _McrcStateRepository.GetAsync(Id);

                return ObjectMapper.Map<McrcStateListDto>(McrcStateDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcStateDetails));
            }
        }

        public async Task<string> UpdateMcrcState(UpdateMcrcStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var McrcStateDetail = _McrcStateRepository.Get(input.Id);
                if (McrcStateDetail != null && McrcStateDetail.Id > 0)
                {

                    ObjectMapper.Map(input, McrcStateDetail);
                    await _McrcStateRepository.UpdateAsync(McrcStateDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", McrcStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", McrcStateDetails));
            }
        }


        public McrcState UpdateMcrcStateBySDE(UpdateMcrcStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var McrcStateDetail = _McrcStateRepository.GetAllList(x => x.ApplicationId == input.ApplicationId && x.Fk_UserId == input.Fk_UserId).FirstOrDefault();
                if (McrcStateDetail != null && McrcStateDetail.Id > 0)
                {

                           McrcStateDetail.Status = input.Status;
                     var Mcrc= _McrcStateRepository.Update(McrcStateDetail);
                          CurrentUnitOfWork.SaveChanges();
                    return Mcrc;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", McrcStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", McrcStateDetails));
            }
        }




    }
}
