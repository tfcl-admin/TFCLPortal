using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.McrcRecords.Dto;

namespace TFCLPortal.McrcRecords
{
   public interface IMcrcRecordAppService : IApplicationService
    {
        McrcRecordListDto GetMcrcRecordListDetailById(int Id);
        int CreateMcrcRecordDetail(CreateMcrcRecordDto input);
        //Task<string> UpdateMcrcRecord(UpdateMcrcRecordDto input);
        McrcRecordListDto GetMcrcRecordListByApplicationId(int ApplicationId);
        List<McrcRecordListDto> GetMcrcRecordList();
        //List<McrcRecordListDto> GetMcrcRecordListSDEUserId(int SDEUserId);
        //Task<List<ApplicationDto>> GetMcrcRecordListByScreenCode(string applicationState, int? branchId, bool showAll = false,bool IsAdmin=false);
    }
}
