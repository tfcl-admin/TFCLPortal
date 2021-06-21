using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.Customs;

using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BccStates
{
   
    public class BccStateAppService : TFCLPortalAppServiceBase, IBccStateAppService
    {

        private readonly IRepository<BccState, Int32> _bccStateRepository;
        private readonly ICustomAppService _customAppService;
        private string BccStateDetails = "Bcc State Detail";

        public BccStateAppService(IRepository<BccState, Int32> bccStateRepository,
            ICustomAppService customAppService) 
        {
            _bccStateRepository = bccStateRepository;
            _customAppService = customAppService;
        }
        public string CreateBccStateDetail(CreateBccStateDto input)
        {
            try
            {
                var BccStateDetail = ObjectMapper.Map<BccState>(input);
                 _bccStateRepository.Insert(BccStateDetail);
                CurrentUnitOfWork.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
                throw new UserFriendlyException(L("CreateMethodError{0}", BccStateDetails));
            }
            
        }

        public async Task<List<BccStateListDto>> GetBccStateListByApplicationId(int ApplicationId)
        {
            try
            {
                var BccStateDetail = _bccStateRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId);

                return ObjectMapper.Map<List<BccStateListDto>>(BccStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BccStateDetails));
            }
        }

        public async Task<List<BccStateListDto>> GetBccStateListByUserId(int UserId)
        {
            try
            {
                var BccStateDetail = _bccStateRepository.GetAllList().Where(x => x.Fk_UserId == UserId);

                return ObjectMapper.Map<List<BccStateListDto>>(BccStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BccStateDetails));
            }
        }

        public async Task<List<BccStateListDto>> GetBccStateListByBCCId(int id)
        {
            try
            {
                var BccStateDetail = _bccStateRepository.GetAllList().Where(x => x.Fk_BccId == id).FirstOrDefault();

                return ObjectMapper.Map<List<BccStateListDto>>(BccStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BccStateDetails));
            }
        }

        public async Task<BccStateListDto> GetBccStateListDetailById(int Id)
        {
            try
            {
                var BccStateDetail = await _bccStateRepository.GetAsync(Id);

                return ObjectMapper.Map<BccStateListDto>(BccStateDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BccStateDetails));
            }
        }

        public async Task<string> UpdateBccState(UpdateBccStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var BccStateDetail = _bccStateRepository.Get(input.Id);
                if (BccStateDetail != null && BccStateDetail.Id > 0)
                {

                    ObjectMapper.Map(input, BccStateDetail);
                    await _bccStateRepository.UpdateAsync(BccStateDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", BccStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", BccStateDetails));
            }
        }


        public BccState UpdateBccStateBySDE(UpdateBccStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var BccStateDetail = _bccStateRepository.GetAllList(x => x.ApplicationId == input.ApplicationId && x.Fk_UserId == input.Fk_UserId).FirstOrDefault();
                if (BccStateDetail != null && BccStateDetail.Id > 0)
                {

                           BccStateDetail.Status = input.Status;
                     var bcc= _bccStateRepository.Update(BccStateDetail);
                          CurrentUnitOfWork.SaveChanges();
                    return bcc;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", BccStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", BccStateDetails));
            }
        }




    }
}
