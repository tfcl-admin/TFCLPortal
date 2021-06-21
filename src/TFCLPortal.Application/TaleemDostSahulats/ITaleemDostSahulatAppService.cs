using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulats.Dto;

namespace TFCLPortal.TaleemDostSahulats
{
    public interface ITaleemDostSahulatAppService : IApplicationService
    {
        Task<TaleemDostSahulatListDto> GetTaleemDostSahulatById(int Id);
        void CreateTaleemDostSahulat(CreateTaleemDostSahulatDto input);
        int CreateTaleemDostSahulatAndReturnApplicationNumber(CreateTaleemDostSahulatDto input);
        Task<string> UpdateTaleemDostSahulat(UpdateTaleemDostSahulatDto input);
        TaleemDostSahulatListDto GetTaleemDostSahulatByApplicationId(int Id);
    }
}
