using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ApplicantTypes
{
    public class ApplicantTypeAppService : TFCLPortalAppServiceBase, IApplicantTypeAppService
    {
        private readonly IRepository<ApplicantType> _ApplicantTypeRepository;
        public ApplicantTypeAppService(IRepository<ApplicantType> repository)
        {
            _ApplicantTypeRepository = repository;
        }
        public async Task<ListResultDto<ApplicantTypeListDto>> GetAllApplicantTypees()
        {
            try
            {
                var ApplicantTypeList = await _ApplicantTypeRepository.GetAllListAsync();


                return new ListResultDto<ApplicantTypeListDto>(
                    ObjectMapper.Map<List<ApplicantTypeListDto>>(ApplicantTypeList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Contact Source"));
            }
        }

        public List<ApplicantTypeListDto> GetAllList()
        {
            var ApplicantTypeList = _ApplicantTypeRepository.GetAllList();
            return ObjectMapper.Map<List<ApplicantTypeListDto>>(ApplicantTypeList);
        }
    }
}
