using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.StudentsGender
{
    public class StudentGenderAppService : TFCLPortalAppServiceBase, IStudentGenderAppService
    {
        private readonly IRepository<StudentGender> _studentgenderRepository;

        public StudentGenderAppService(IRepository<StudentGender> studentgenderRepository)
        {
            _studentgenderRepository = studentgenderRepository;
        }
        public async Task CreateStudentGender(CreateStudentGenderDto input)
        {
            try
            {
                var studentgenders = ObjectMapper.Map<StudentGender>(input);
                await _studentgenderRepository.InsertAsync(studentgenders);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Student"));
            }
        }

        public async Task<ListResultDto<StudentGenderListDto>> GetAllStudentGender()
        {

            try
            {
                var studentgenders = await _studentgenderRepository.GetAllListAsync();



                return new ListResultDto<StudentGenderListDto>(
                    ObjectMapper.Map<List<StudentGenderListDto>>(studentgenders)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Student"));
            }
        }

        public List<StudentGenderListDto> GetAllList()
        {

            var studentgenderslist = _studentgenderRepository.GetAllList();
            return ObjectMapper.Map<List<StudentGenderListDto>>(studentgenderslist);
        }
    }
}
