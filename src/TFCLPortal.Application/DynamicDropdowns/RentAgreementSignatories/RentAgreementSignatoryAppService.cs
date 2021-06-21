using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.DynamicDropdowns.RentAgreementSignatories
{
    public class RentAgreementSignatoryAppService : TFCLPortalAppServiceBase, IRentAgreementSignatoryAppService
    {
        private readonly IRepository<RentAgreementSignatory> _rentAgreementSignatoryRepository;
        public RentAgreementSignatoryAppService(IRepository<RentAgreementSignatory> repository)
        {
            _rentAgreementSignatoryRepository = repository;
        }
        public List<RentAgreementSignatoryListDto> GetAllList()
        {
            var RentAgreementSignatoryList = _rentAgreementSignatoryRepository.GetAllList();
            return ObjectMapper.Map<List<RentAgreementSignatoryListDto>>(RentAgreementSignatoryList);
        }

        public async Task<ListResultDto<RentAgreementSignatoryListDto>> GetAllRentAgreementSignatories()
        {
            try
            {
                var RentAgreementSignatoryList = await _rentAgreementSignatoryRepository.GetAllListAsync();


                return new ListResultDto<RentAgreementSignatoryListDto>(
                    ObjectMapper.Map<List<RentAgreementSignatoryListDto>>(RentAgreementSignatoryList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Rent Agreement Signatory"));
            }
        }
    }
}
