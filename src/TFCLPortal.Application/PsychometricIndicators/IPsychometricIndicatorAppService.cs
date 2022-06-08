using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.PsychometricIndicators.Dto;

namespace TFCLPortal.PsychometricIndicators
{
    public interface IPsychometricIndicatorAppService : IApplicationService
    {
        Task<string> CreatePsychometricIndicator (CreatePsychometricIndicatorDto Input);
        Task<PsychometricIndicatorListDto> GetPsychometricIndicatorByApplicationId(int ApplicationId);
        bool CheckPsychometricIndicatorByApplicationId(int ApplicationId);
    }
}
