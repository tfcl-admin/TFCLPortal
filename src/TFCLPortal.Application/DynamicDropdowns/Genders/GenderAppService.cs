using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Genders
{
    public class GenderAppService : TFCLPortalAppServiceBase, IGenderAppService
    {

        private readonly IRepository<Gender> _genderrepo;
        public GenderAppService(IRepository<Gender> gender)
        {
            _genderrepo = gender;
        }

        public async Task CreateGender(CreateGenderDto input)
        {
            try
            {
                var gender = ObjectMapper.Map<Gender>(input);
                await _genderrepo.InsertAsync(gender);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Gender"));
            }
        }

        public async Task<ListResultDto<GenderListDto>> GetAllGender()
        {
            try
            {
                var gender = await _genderrepo.GetAllListAsync();


                return new ListResultDto<GenderListDto>(
                    ObjectMapper.Map<List<GenderListDto>>(gender)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Gender"));
            }
        }

        public List<GenderListDto> GetAllList()
        {

            var genderlist = _genderrepo.GetAllList();
            return ObjectMapper.Map<List<GenderListDto>>(genderlist);
        }
    }
}
