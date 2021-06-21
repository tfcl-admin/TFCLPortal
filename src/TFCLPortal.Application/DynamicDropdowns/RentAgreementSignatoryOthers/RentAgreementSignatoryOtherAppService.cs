using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.DynamicDropdowns.RentAgreementSignatoryOthers
{
    public class RentAgreementSignatoryOtherAppService : TFCLPortalAppServiceBase, IRentAgreementSignatoryOtherAppService
    {
        private readonly IRepository<RentAgreementSignatoryOther> _rentAgreementSignatoryOthersRepository;
        public RentAgreementSignatoryOtherAppService(IRepository<RentAgreementSignatoryOther> repository)
        {
            _rentAgreementSignatoryOthersRepository = repository;
        }

        public List<RentAgreementSignatoryOtherListDto> GetAllList()
        {
            var RentAgreementSignatoryOtherList = _rentAgreementSignatoryOthersRepository.GetAllList();
            return ObjectMapper.Map<List<RentAgreementSignatoryOtherListDto>>(RentAgreementSignatoryOtherList);
        }

        public async Task<ListResultDto<RentAgreementSignatoryOtherListDto>> GetAllRentAgreementSignatoryOthers()
        {
            try
            {
                var RentAgreementSignatoryOtherList = await _rentAgreementSignatoryOthersRepository.GetAllListAsync();


                return new ListResultDto<RentAgreementSignatoryOtherListDto>(
                    ObjectMapper.Map<List<RentAgreementSignatoryOtherListDto>>(RentAgreementSignatoryOtherList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Rent Agreement Signatory Others"));
            }
        }
    }
}

