using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using TFCLPortal.DynamicDropdowns.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace TFCLPortal.DynamicDropdowns.ApplicantSources
{
    public class ApplicantSourceAppService : TFCLPortalAppServiceBase, IApplicantSourceAppService
    {
        private readonly IRepository<ApplicantSource> _ApplicantSourceRepository;
        public ApplicantSourceAppService(IRepository<ApplicantSource> repository)
        {
            _ApplicantSourceRepository = repository;
        }

        public List<ApplicantSourceListDto> GetAllList()
        {
            var ApplicantSourceList = _ApplicantSourceRepository.GetAllList();
            return ObjectMapper.Map<List<ApplicantSourceListDto>>(ApplicantSourceList);
        }

        public async Task<ListResultDto<ApplicantSourceListDto>> GetAllApplicantSources()
        {
            try
            {
                var ApplicantSourceList = await _ApplicantSourceRepository.GetAllListAsync();


                return new ListResultDto<ApplicantSourceListDto>(
                    ObjectMapper.Map<List<ApplicantSourceListDto>>(ApplicantSourceList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Applicant Source"));
            }
        }

    }
}
