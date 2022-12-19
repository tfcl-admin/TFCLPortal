using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.NameChanges.Dto;

namespace TFCLPortal.NameChanges
{
    public interface INameChangeAppService : IApplicationService
    {
        NameChangeListDto GetNameChangeById(int Id);
        Task<string> CreateNameChange(CreateNameChangeDto input);
        Task<string> UpdateNameChange(UpdateNameChangeDto input);
    }
}
