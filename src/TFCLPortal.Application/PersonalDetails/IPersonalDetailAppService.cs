using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.PersonalDetails
{
    public interface IPersonalDetailAppService :IApplicationService
    {
        // Task<ListResultDto<QualificationListDto>> GetAllQualification();
        PersonalDetailDto GetPersonalDetailById(int Id);
        Task<string> CreatePersonalDetail(CreatePersonalDetailDto input);
        Task<string> UpdatePersonalDetail(UpdatePersonalDetailDto input);
        bool CheckPersonalDetailByApplicationId(int ApplicationId);

        Task<PersonalDetailDto> GetPersonalDetailByApplicationId(int ApplicationId);

    }
}
