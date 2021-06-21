using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates
{
    public class ApplicationDescripantDeclineStateAppService : TFCLPortalAppServiceBase, IApplicationDescripantDeclineStateAppService
    {
        private readonly IRepository<ApplicationDescripantDeclineState, Int32> _applicationDescripantDeclineStateRepository;
        private string ApplicationDescripantDeclineStateDetails = "Application Descripant Decline State Detail";

        public ApplicationDescripantDeclineStateAppService(IRepository<ApplicationDescripantDeclineState, Int32> applicationDescripantDeclineStateRepository)
        {
            _applicationDescripantDeclineStateRepository = applicationDescripantDeclineStateRepository;
        }
        public async Task CreateApplicationDescripantDecline(CreateApplicationDescripantDeclineStateDto input)
        {
            try
            {
                var applicationDescripantDeclineStateDetail = ObjectMapper.Map<ApplicationDescripantDeclineState>(input);
                _applicationDescripantDeclineStateRepository.Insert(applicationDescripantDeclineStateDetail);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", ApplicationDescripantDeclineStateDetails));
            }
        }

        public async Task<ApplicationDescripantDeclineStateListDto> GetApplicationDescripantDeclineApplicationId(int ApplicationId)
        {
            try
            {
                var applicationDescripantDeclineStateDetail = _applicationDescripantDeclineStateRepository.GetAllList().Where(x => x.Id == ApplicationId).FirstOrDefault();

                return ObjectMapper.Map<ApplicationDescripantDeclineStateListDto>(applicationDescripantDeclineStateDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ApplicationDescripantDeclineStateDetails));
            }
        }

        public async Task<ApplicationDescripantDeclineStateListDto> GetApplicationDescripantDeclineById(int Id)
        {
            try
            {
                var applicationDescripantDeclineStateDetail = await _applicationDescripantDeclineStateRepository.GetAsync(Id);

                return ObjectMapper.Map<ApplicationDescripantDeclineStateListDto>(applicationDescripantDeclineStateDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ApplicationDescripantDeclineStateDetails));
            }
        }

        public async Task<string> UpdateApplicationDescripantDecline(UpdateApplicationDescripantDeclineStateDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var applicationDescripantDeclineStateDetail = _applicationDescripantDeclineStateRepository.Get(input.Id);
                if (applicationDescripantDeclineStateDetail != null && applicationDescripantDeclineStateDetail.Id > 0)
                {
                    ObjectMapper.Map(input, applicationDescripantDeclineStateDetail);
                    await _applicationDescripantDeclineStateRepository.UpdateAsync(applicationDescripantDeclineStateDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", ApplicationDescripantDeclineStateDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", ApplicationDescripantDeclineStateDetails));
            }
        }
    }
}
