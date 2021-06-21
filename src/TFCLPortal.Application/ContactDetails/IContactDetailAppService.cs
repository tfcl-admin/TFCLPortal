using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ContactDetails.Dto;

namespace TFCLPortal.ContactDetails
{
    public interface IContactDetailAppService : IApplicationService
    {
        ContactDetailListDto GetContactDetailById(int Id);
        Task<string> CreateContactDetail(CreateContactDetailDto input);
        Task<string> UpdateContactDetail(UpdateContactDetailDto input);
        Task<ContactDetailListDto> GetContactDetailByApplicationId(int ApplicationId);
        bool CheckContactDetailByApplicationId(int ApplicationId);
    }
}
