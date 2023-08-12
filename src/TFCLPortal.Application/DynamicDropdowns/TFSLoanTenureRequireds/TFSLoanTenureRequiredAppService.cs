using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.TFSLoanTenureRequireds
{
    public class TFSLoanTenureRequiredAppService : TFCLPortalAppServiceBase, ITFSLoanTenureRequiredAppService
    {
        private readonly IRepository<TFSLoanTenureRequired> _TFSloanTenureRequiredRepository;

        public TFSLoanTenureRequiredAppService(IRepository<TFSLoanTenureRequired> TFSloanTenureRequiredRepository)
        {
            _TFSloanTenureRequiredRepository = TFSloanTenureRequiredRepository;
        }
        public async Task CreateTFSLoanTenureRequired(CreateTFSLoanTenureRequiredDto input)
        {
            try
            {
                var TFSLoanTenureRequired = ObjectMapper.Map<TFSLoanTenureRequired>(input);
                await _TFSloanTenureRequiredRepository.InsertAsync(TFSLoanTenureRequired);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "TFSLoanTenureRequired"));
            }
        }

        public List<TFSLoanTenureRequiredListDto> GetAllList()
        {
            var TFSLoanTenureRequired = _TFSloanTenureRequiredRepository.GetAllList();
            return ObjectMapper.Map<List<TFSLoanTenureRequiredListDto>>(TFSLoanTenureRequired);
        }

        public async Task<ListResultDto<TFSLoanTenureRequiredListDto>> GetAllTFSLoanTenureRequired()
        {
            try
            {
                var TFSLoanTenureRequired = await _TFSloanTenureRequiredRepository.GetAllListAsync();


                return new ListResultDto<TFSLoanTenureRequiredListDto>(
                    ObjectMapper.Map<List<TFSLoanTenureRequiredListDto>>(TFSLoanTenureRequired)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "TFSLoanTenureRequired"));
            }
        }
    }
}
