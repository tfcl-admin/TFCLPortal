using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.AcademicSessions
{
    public class AcademicSessionAppService : TFCLPortalAppServiceBase, IAcademicSessionAppService
    {
        private readonly IRepository<AcademicSession> _AcademicSessionRepository;
        public AcademicSessionAppService(IRepository<AcademicSession> repository)
        {
            _AcademicSessionRepository = repository;
        }

        public List<AcademicSessionListDto> GetAllList()
        {
            var AcademicSessionList = _AcademicSessionRepository.GetAllList();
            return ObjectMapper.Map<List<AcademicSessionListDto>>(AcademicSessionList);
        }

        public async Task<ListResultDto<AcademicSessionListDto>> GetAllApplicantSources()
        {
            try
            {
                var AcademicSessionList = await _AcademicSessionRepository.GetAllListAsync();


                return new ListResultDto<AcademicSessionListDto>(
                    ObjectMapper.Map<List<AcademicSessionListDto>>(AcademicSessionList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Respondant Designation"));
            }
        }

    }
}
