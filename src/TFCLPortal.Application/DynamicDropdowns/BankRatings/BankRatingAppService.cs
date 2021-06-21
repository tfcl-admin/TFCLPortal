using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.BankRatings
{
    public class BankRatingAppService : TFCLPortalAppServiceBase, IBankRatingAppService
    {
        private readonly IRepository<BankRating> _BankRatingRepository;

        public BankRatingAppService(IRepository<BankRating> BankRatingRepository)
        {
            _BankRatingRepository = BankRatingRepository;
        }

        public async Task<ListResultDto<BankRatingListDto>> GetAllBankRating()
        {
            try
            {
                var BankRatingList = await _BankRatingRepository.GetAllListAsync();


                return new ListResultDto<BankRatingListDto>(
                    ObjectMapper.Map<List<BankRatingListDto>>(BankRatingList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Bank Rating"));
            }
        }

        public List<BankRatingListDto> GetAllList()
        {
            var BankRatingList = _BankRatingRepository.GetAllList();
            return ObjectMapper.Map<List<BankRatingListDto>>(BankRatingList);
        }
    }
}
