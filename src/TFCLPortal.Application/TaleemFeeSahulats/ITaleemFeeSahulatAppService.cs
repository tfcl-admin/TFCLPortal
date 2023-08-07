using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemFeeSahulats.Dto;

namespace TFCLPortal.TaleemFeeSahulats
{
    public interface ITaleemFeeSahulatAppService : IApplicationService
    {
        Task<TaleemFeeSahulatListDto> GetTaleemFeeSahulatById(int Id);
        void CreateTaleemFeeSahulat(CreateTaleemFeeSahulatDto input);
        int CreateTaleemFeeSahulatAndReturnApplicationNumber(CreateTaleemFeeSahulatDto input);
        Task<string> UpdateTaleemFeeSahulat(UpdateTaleemFeeSahulatDto input);
        TaleemFeeSahulatListDto GetTaleemFeeSahulatByApplicationId(int Id);
    }
}
