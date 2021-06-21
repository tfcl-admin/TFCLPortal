using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.Mobilizations;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.Customs
{
    public class CustomAppService : AsyncCrudAppService<BccState, BccStateListDto,Int32, PagedResultRequestDto, CreateBccStateDto, BccStateListDto>, ICustomAppService
    {
        private static IRepository<BccState, int> repository;
        private readonly ICustomRepository _customRepository;

        public CustomAppService(ICustomRepository customRepository) : base(repository)
        {

            _customRepository = customRepository;
        }


        public async Task<bool> GetBccApplicationApprovedStaus(int applicationId)
        {
            return await _customRepository.GetBccApplicationApprovedStaus(applicationId);
        }

        public async Task<double> GetIrr(int nper, double pmt, double pv, double fv, bool type)
        {
            return await _customRepository.GetIRR(nper, pmt, pv, fv, type);
        }

        public async Task<List<GetMobilizationListDto>> getMobilizationListBySP()
        {
            return _customRepository.GetMobilizationsByMaxInteractionNumber();
        }
    }
}
