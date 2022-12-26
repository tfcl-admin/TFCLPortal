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
using TFCLPortal.NameChanges.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.NameChanges
{
    public class NameChangeAppService : TFCLPortalAppServiceBase, INameChangeAppService
    {
        private readonly IRepository<NameChange, Int32> _NameChangeRepository;
        private string NameChanges = "NameChange";
        public NameChangeAppService(IRepository<NameChange, Int32> NameChangeRepository)
        {
            _NameChangeRepository = NameChangeRepository;
        }

        public async Task<string> CreateNameChange(CreateNameChangeDto input)
        {
            string ResponseString = "";

            try
            {
            
                var NameChange = ObjectMapper.Map<NameChange>(input);
                await _NameChangeRepository.InsertAsync(NameChange);
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", NameChanges));
            }
        }

        public  NameChangeListDto GetNameChangeById(int Id)
        {
            try
            {
                var NameChange =  _NameChangeRepository.Get(Id);

                return ObjectMapper.Map<NameChangeListDto>(NameChange);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", NameChanges));
            }
        }

        public async Task<string> UpdateNameChange(UpdateNameChangeDto input)
        {
            string ResponseString = "";
            try
            {
                var NameChange = _NameChangeRepository.Get(input.Id);
                if (NameChange != null && NameChange.Id > 0)
                {
                    ObjectMapper.Map(input, NameChange);
                    await _NameChangeRepository.UpdateAsync(NameChange);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", NameChanges));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", NameChanges));
            }
        }

    }
}
