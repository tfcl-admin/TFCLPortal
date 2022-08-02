using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Reversals.Dto;

namespace TFCLPortal.Reversals
{
    public interface IReversalAppService : IApplicationService
    {
        ReversalListDto GetReversalById(int Id);
        Task<string> CreateReversal(CreateReversalDto input);
        List<ReversalListDto> GetReversals();
        ReversalListDto GetReversalDetailsById(int id);
        bool ReversalAuthorization(int Id, string Decision, string Reason);

    }
}
