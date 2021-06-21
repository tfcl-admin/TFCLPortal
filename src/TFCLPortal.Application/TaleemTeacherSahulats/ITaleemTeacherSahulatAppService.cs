using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemTeacherSahulats.Dto;

namespace TFCLPortal.TaleemTeacherSahulats
{
    public interface ITaleemTeacherSahulatAppService : IApplicationService
    {
        Task<TaleemTeacherSahulatListDto> GetTaleemTeacherSahulatById(int Id);
        void CreateTaleemTeacherSahulat(CreateTaleemTeacherSahulatDto input);
        int CreateTaleemTeacherSahulatAndReturnApplicationNumber(CreateTaleemTeacherSahulatDto input);
        Task<string> UpdateTaleemTeacherSahulat(UpdateTaleemTeacherSahulatDto input);
        TaleemTeacherSahulatListDto GetTaleemTeacherSahulatByApplicationId(int Id);
    }
}
