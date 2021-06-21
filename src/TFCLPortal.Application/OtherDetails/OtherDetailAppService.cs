using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.OtherDetails.Dto;

namespace TFCLPortal.OtherDetails
{
    public class OtherDetailAppService : TFCLPortalAppServiceBase, IOtherDetailAppService
    {
        private readonly IRepository<OtherDetail,Int32> _otherDetailRepository;
        private readonly IRepository<Occupation> _occupationRepository;
        private readonly IRepository<FundSource> _fundsourceRepository;
        private string otherDetail = "Other Detail";
        public OtherDetailAppService(IRepository<OtherDetail> otherDetailRepository,
            IRepository<Occupation> occupationRepository,
            IRepository<FundSource> fundsourceRepository)
        {
            _otherDetailRepository = otherDetailRepository;
            _occupationRepository = occupationRepository;
            _fundsourceRepository = fundsourceRepository;
        }
        public async Task CreateOtherDetail(CreateOtherDetailDto input)
        {
            try
            {
                var otherDetails = ObjectMapper.Map<OtherDetail>(input);
                await _otherDetailRepository.InsertAsync(otherDetails);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", otherDetail));
            }
        }

        public async Task<OtherDetailListDto> GetOtherDetailById(int Id)
        {
            try
            {
                var otherDetails = await _otherDetailRepository.GetAsync(Id);

                return ObjectMapper.Map<OtherDetailListDto>(otherDetails);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", otherDetail));
            }
        }

        public async Task<string> UpdateOtherDetail(UpdateOtherDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var otherDetails = _otherDetailRepository.Get(input.Id);
                if (otherDetails != null && otherDetails.Id > 0)
                {
                    ObjectMapper.Map(input, otherDetails);
                    await _otherDetailRepository.UpdateAsync(otherDetails);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", otherDetail));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", otherDetail));
            }
        }

        public async Task<OtherDetailListDto> GetOtherDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var otherDetails = _otherDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();

                var objDetails= ObjectMapper.Map<OtherDetailListDto>(otherDetails);

                var initChat = (from otherDetail in _otherDetailRepository.GetAllList()
                                join fundSource in _fundsourceRepository.GetAllList() on otherDetail.OtherSourceOfFund equals fundSource.Id
                                join occupation in _occupationRepository.GetAllList() on otherDetail.OtherOccupation equals occupation.Id
                                where otherDetail.ApplicationId == ApplicationId
                                select new
                                {
                                    otherDetail,
                                    fundSourceName = fundSource.Name,
                                    occupationName = occupation.Name
                                }).FirstOrDefault();

                if (initChat != null)
                {
                    objDetails.FundSourceName = initChat.fundSourceName;
                    objDetails.OccupationName = initChat.occupationName;
                }
                return objDetails;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", otherDetail));
            }
        }
    }
}
