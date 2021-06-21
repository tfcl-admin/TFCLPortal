using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.FundSources
{
    public class FundSourceAppService : TFCLPortalAppServiceBase, IFundSourceAppService
    {
        private readonly IRepository<FundSource> _fundsourceRepository;
        public FundSourceAppService(IRepository<FundSource> fundsourceRepository)
        {
            _fundsourceRepository = fundsourceRepository;
        }
        public async Task CreateFundSource(CreateFundSourceDto input)
        {
            try
            {
                var fundsource = ObjectMapper.Map<FundSource>(input);
                await _fundsourceRepository.InsertAsync(fundsource);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "FundSource"));
            }
        }

        public async  Task<ListResultDto<FundSourceListDto>> GetAllFundSource()
        {
           try
            {
                var fundsource = await _fundsourceRepository.GetAllListAsync();


                return new ListResultDto<FundSourceListDto>(
                    ObjectMapper.Map<List<FundSourceListDto>>(fundsource)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "FundSource"));
            }
        }

        public List<FundSourceListDto> GetAllList()
        {

            var fundsourcelist = _fundsourceRepository.GetAllList();
            return ObjectMapper.Map<List<FundSourceListDto>>(fundsourcelist);
        }
    }
}
