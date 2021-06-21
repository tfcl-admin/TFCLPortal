using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LandTypes
{
    public class LandTypeAppService : TFCLPortalAppServiceBase, ILandTypeAppService
    {

        private readonly IRepository<LandType> _landTyperepo;

        public LandTypeAppService(IRepository<LandType> landType)
        {
            _landTyperepo = landType;
        }
        public async Task CreateLandType(CreateLandTypeDto input)
        {
            try
            {
                var landtype = ObjectMapper.Map<LandType>(input);
                await _landTyperepo.InsertAsync(landtype);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "LandType"));
            }
        }

        public async Task<ListResultDto<LandTypeListDto>> GetAllLandType()
        {
            try
            {
                var landtype = await _landTyperepo.GetAllListAsync();


                return new ListResultDto<LandTypeListDto>(
                    ObjectMapper.Map<List<LandTypeListDto>>(landtype)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "LandType"));
            }
        }

        public List<LandTypeListDto> GetAllList()
        {

            var landtypelist = _landTyperepo.GetAllList();
            return ObjectMapper.Map<List<LandTypeListDto>>(landtypelist);
        }
    }
}
