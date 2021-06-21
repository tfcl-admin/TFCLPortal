using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;

namespace TFCLPortal.IApplicationWiseDeviationVariableAppServices
{

    public interface IApplicationWiseDeviationVariableAppService : IApplicationService
    {
        ApplicationWiseDeviationVariableListDto GetApplicationWiseDeviationVariableById(int Id);
        Task CreateApplicationWiseDeviationVariable(CreateApplicationWiseDeviationVariableDto input);
        Task<string> UpdateApplicationWiseDeviationVariable(UpdateApplicationWiseDeviationVariableDto input);
        ApplicationWiseDeviationVariableListDto GetApplicationWiseDeviationVariableDetailByApplicationId(int ApplicationId);
        Task<ApplicationWiseDeviationVariableListDto> GetApplicationWiseDeviationVariableDetailByApplicationIdAsync(int ApplicationId);

        List<ApplicationWiseDeviationVariableListDto> GetApplicationWiseDeviationVariables();

        Task<string> getMarkup(GetMarkupParameters input);
    }
}
