using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.PostDisbursementForms.Dto;

namespace TFCLPortal.PostDisbursementForms
{
    public interface IPostDisbursementFormAppService : IApplicationService
    {
        Task<PostDisbursementFormListDto> GetPostDisbursementFormById(int Id);
        Task<string> CreatePostDisbursementForm(CreatePostDisbursementFormDto input);
        Task<string> UpdatePostDisbursementForm(UpdatePostDisbursementFormDto input);
        Task<PostDisbursementFormListDto> GetPostDisbursementFormByApplicationId(int ApplicationId);
        bool CheckPostDisbursementFormByApplicationId(int ApplicationId);
    }
}
