using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemSchoolSarmayas.Dto;

namespace TFCLPortal.TaleemSchoolSarmayas
{
    public interface ITaleemSchoolSarmayaAppService : IApplicationService
    {
        Task<TaleemSchoolSarmayasListDto> GetTaleemSchoolSarmayaById(int Id);
        Task CreateTaleemSchoolSarmaya(CreateTaleemSchoolSarmayaDto input);
        int CreateTaleemSchoolSarmayaAndReturnApplicationNumber(CreateTaleemSchoolSarmayaDto input);
        Task<string> UpdateTaleemSchoolSarmaya(UpdateTaleemSchoolSarmayaDto input);
        TaleemSchoolSarmayasListDto GetTaleemSchoolSarmayaByApplicationId(int Id);
    }
}
