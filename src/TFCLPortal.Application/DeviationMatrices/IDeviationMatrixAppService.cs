using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeviationMatrices.Dto;

namespace TFCLPortal.DeviationMatrices
{
    public interface IDeviationMatrixAppService : IApplicationService
    {
        Task<string> CreateDeviationMatrix(CreateDeviationMatrixDto input);
        Task<string> UpdateDeviationMatrix(CreateDeviationMatrixDto input);
        DeviationMatrixListDto GetDeviationMatrixById(int Id);
        List<DeviationMatrixListDto> GetDeviationMatrices();
        Task<DeviationMatrixListDto> GetDeviationMatrixByProductId(int ProductId);
    }
}
