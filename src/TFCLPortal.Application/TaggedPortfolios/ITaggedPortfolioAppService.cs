using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaggedPortfolios.Dto;

namespace TFCLPortal.TaggedPortfolios
{
    public interface ITaggedPortfolioAppService : IApplicationService
    {
        Task<TaggedPortfolioListDto> GetTaggedPortfolioById(int Id);
        Task<string> CreateTaggedPortfolio(CreateTaggedPortfolioDto input);
        Task<string> UpdateTaggedPortfolio(UpdateTaggedPortfolioDto input);
        Task<TaggedPortfolioListDto> GetTaggedPortfolioByApplicationId(int ApplicationId);
        bool CheckTaggedPortfolioByApplicationId(int ApplicationId);
        List<TaggedPortfolioListDto> GetAllTaggedPortfolio();
    }
}
