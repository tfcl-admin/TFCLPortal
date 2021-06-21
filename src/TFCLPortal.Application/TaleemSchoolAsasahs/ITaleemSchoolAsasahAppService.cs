using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemSchoolAsasahs.Dto;

namespace TFCLPortal.TaleemSchoolAsasahs
{
    public interface ITaleemSchoolAsasahAppService : IApplicationService
    {
        Task<TaleemSchoolAsasahListDto> GetTaleemSchoolAsasahById(int Id);
        void CreateTaleemSchoolAsasah(CreateTaleemSchoolAsasahDto input);
        int CreateTaleemSchoolAsasahAndReturnApplicationNumber(CreateTaleemSchoolAsasahDto input);
        Task<string> UpdateTaleemSchoolAsasah(UpdateTaleemSchoolAsasahDto input);
        TaleemSchoolAsasahListDto GetTaleemSchoolAsasahByApplicationId(int Id);
    }
}
