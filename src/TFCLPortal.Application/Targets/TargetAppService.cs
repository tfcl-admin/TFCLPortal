using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Targets.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.Targets
{
    public class TargetAppService : TFCLPortalAppServiceBase, ITargetAppService
    {
        private readonly IRepository<Target, Int32> _TargetRepository;
        private string Targets = "Target";
        public TargetAppService(IRepository<Target, Int32> TargetRepository)
        {
            _TargetRepository = TargetRepository;
        }

        public async Task<string> CreateTarget(CreateTargetDto input)
        {
            string ResponseString = "";

            try
            {
            
                var Target = ObjectMapper.Map<Target>(input);
                await _TargetRepository.InsertAsync(Target);
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", Targets));
            }
        }

        public  TargetListDto GetTargetById(int Id)
        {
            try
            {
                var Target =  _TargetRepository.Get(Id);

                return ObjectMapper.Map<TargetListDto>(Target);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Targets));
            }
        }

        public async Task<string> UpdateTarget(UpdateTargetDto input)
        {
            string ResponseString = "";
            try
            {
                var Target = _TargetRepository.Get(input.Id);
                if (Target != null && Target.Id > 0)
                {
                    ObjectMapper.Map(input, Target);
                    await _TargetRepository.UpdateAsync(Target);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", Targets));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Targets));
            }
        }

        public List<TargetListDto> GetAllAlocatedTarget()
        {
            try
            {
                var Targets = _TargetRepository.GetAllList();
                return ObjectMapper.Map<List<TargetListDto>>(Targets);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Targets));
            }
        }

    }
}
