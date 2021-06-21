using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.Qualifications;

namespace TFCLPortal.DynamicDropdowns.Qualifications
{
   public class QualificationAppService:TFCLPortalAppServiceBase,IQualificationAppService
    {
        private readonly IRepository<Qualification> _qualificationRepository;

        public QualificationAppService(IRepository<Qualification> qualificationRepository)
        {
            _qualificationRepository = qualificationRepository;
        }

        public async Task<ListResultDto<QualificationListDto>> GetAllQualification()
        {
            try
            {
                var qualifications = await _qualificationRepository.GetAllListAsync();

                

                return new ListResultDto<QualificationListDto>(
                    ObjectMapper.Map<List<QualificationListDto>>(qualifications)
                );
                
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Qualification"));
            }
        }


        public async Task CreateQualification(CreateQualificationDto input)
        {
            try
            {
                var qualification = ObjectMapper.Map<Qualification>(input);
                await _qualificationRepository.InsertAsync(qualification);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Qualification"));
            }

        }

        public List<QualificationListDto> GetAllList()
        {

            var qualifications = _qualificationRepository.GetAllList();
            return ObjectMapper.Map<List<QualificationListDto>>(qualifications);
        }
    }
}
