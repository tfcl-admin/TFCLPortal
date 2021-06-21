using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulatProduct.CreateWrapperAllScreensOFTDS.Dto;

namespace TFCLPortal.TaleemDostSahulatProduct.CreateWrapperAllScreensOFTDS
{
    public interface ICreateWrapperAllScreenOfTDSAppService : IApplicationService
    {
        Task<string> CreateWrapperAllScreen(CreateAllScreenForTDSDto createAllScreen);
    }
}
