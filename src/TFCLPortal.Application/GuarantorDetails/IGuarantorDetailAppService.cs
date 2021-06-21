using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.GuarantorDetails.Dto;

namespace TFCLPortal.GuarantorDetails
{
   public interface IGuarantorDetailAppService: IApplicationService
    {

        Task<string> Create(CreateGuarantorDetailInput createGuarantorDetailInput, int applicationId);
        Task<string> Update(UpdateGurantorDtoList editGuarantorDetailinput);
        Task<List<GuarantorDetailListDto>> GetGuarantorDetailById(int Id);
        Task<List<GuarantorDetailListDto>> GetGuarantorDetailByApplicationId(int ApplicationId);
        bool CheckGuarantorDetailByApplicationId(int ApplicationId);
    }
}
