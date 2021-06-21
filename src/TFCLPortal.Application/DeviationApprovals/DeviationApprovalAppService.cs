using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeviationApprovals.Dto;
using TFCLPortal.DeviationMatrices;
using TFCLPortal.DeviationMatrices.Dto;

namespace TFCLPortal.DeviationApprovals
{
    public class DeviationApprovalAppService : TFCLPortalAppServiceBase, IDeviationApprovalAppService
    {
        private readonly IRepository<DeviationApproval> _deviationApprovalRepository;

        public DeviationApprovalAppService(IRepository<DeviationApproval> deviationApprovalRepository)
        {
            _deviationApprovalRepository = deviationApprovalRepository;
        }
        public async Task<string> CreateDeviationApproval(CreateDeviationApprovalDto input)
        {
            try
            {
                var deviationApproval = ObjectMapper.Map<DeviationApproval>(input);
                await _deviationApprovalRepository.InsertAsync(deviationApproval);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<List<DeviationApprovalListDto>> GetDeviationApprovalByApplicationId(int ApplicationId)
        {

            try
            {
                var deviationApproval = _deviationApprovalRepository.GetAllList();

                var Deviations = ObjectMapper.Map<List<DeviationApprovalListDto>>(deviationApproval);

                return Deviations;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Deviation Approval"));
            }
        }

        public DeviationApprovalListDto GetDeviationApprovalById(int Id)
        {
            try
            {
                var deviationApproval = _deviationApprovalRepository.Get(Id);

                return ObjectMapper.Map<DeviationApprovalListDto>(deviationApproval);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Deviation Approval"));
            }
        }

        public async Task<string> UpdateDeviationApproval(UpdateDeviationApprovalDto input)
        {
            string ResponseString = "";
            try
            {
                var deviationApproval = _deviationApprovalRepository.Get(input.Id);
                if (deviationApproval != null && deviationApproval.Id > 0)
                {
                    ObjectMapper.Map(input, deviationApproval);
                    await _deviationApprovalRepository.UpdateAsync(deviationApproval);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "Deviation Approval"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Deviation Approval"));
            }
        }
    }
}
