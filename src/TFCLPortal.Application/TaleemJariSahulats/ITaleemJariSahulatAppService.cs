using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemJariSahulats.Dto;

namespace TFCLPortal.TaleemJariSahulats
{
    public interface ITaleemJariSahulatAppService : IApplicationService
    {
        Task<TaleemJariSahulatListDto> GetTaleemJariSahulatById(int Id);
        void CreateTaleemJariSahulat(CreateTaleemJariSahulatDto input);
        int CreateTaleemJariSahulatAndReturnApplicationNumber(CreateTaleemJariSahulatDto input);
        Task<string> UpdateTaleemJariSahulat(UpdateTaleemJariSahulatDto input);
        TaleemJariSahulatListDto GetTaleemJariSahulatByApplicationId(int Id);
    }
}
