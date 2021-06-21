using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Applications;

namespace TFCLPortal.ErrorLogs
{
    public class ErrorLogAppService : TFCLPortalAppServiceBase, IErrorLogAppService
    {
        private readonly IRepository<ErrorLog> _errorLogRepository;

        public ErrorLogAppService(IRepository<ErrorLog> errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public List<ErrorLogDto> GetAllList()
        {
            var errList= _errorLogRepository.GetAllList();

            return ObjectMapper.Map<List<ErrorLogDto>>(errList);
        }

        public void SaveErrorLog(string FunctionName, string ErrorSubject, string ErrorDescription)
        {
            ErrorLog el = new ErrorLog();
            el.CreationTime = DateTime.Now;
            el.FunctionName = FunctionName;
            el.Subject = ErrorSubject;
            el.Description = ErrorDescription;
            _errorLogRepository.InsertAsync(el);
        }
    }
}
