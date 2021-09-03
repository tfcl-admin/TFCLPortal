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
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaggedPortfolios.Dto;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.TaggedPortfolios
{
    public class TaggedPortfolioAppService : TFCLPortalAppServiceBase, ITaggedPortfolioAppService
    {
        private readonly IRepository<TaggedPortfolio, Int32> _TaggedPortfolioRepository;
      
        private string TaggedPortfolio = "Tagged Portfolio";
        public TaggedPortfolioAppService(IRepository<TaggedPortfolio, Int32> TaggedPortfolioRepository)
        {
            _TaggedPortfolioRepository = TaggedPortfolioRepository;
        }

        public async Task<string> CreateTaggedPortfolio(CreateTaggedPortfolioDto input)
        {
            string ResponseString = "";
            try
            {

                var bp = _TaggedPortfolioRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (bp != null)
                {
                    var tp = _TaggedPortfolioRepository.Get(bp.Id);
                    await _TaggedPortfolioRepository.DeleteAsync(tp);
                    var TaggedPortfolios = ObjectMapper.Map<TaggedPortfolio>(input);
                    _TaggedPortfolioRepository.Insert(TaggedPortfolios);
                }
                else
                {
                    var TaggedPortfolios = ObjectMapper.Map<TaggedPortfolio>(input);
                    _TaggedPortfolioRepository.Insert(TaggedPortfolios);
                }

                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", TaggedPortfolio));

            }
        }

        public async Task<TaggedPortfolioListDto> GetTaggedPortfolioById(int Id)
        {
            try
            {
                var TaggedPortfolios = await _TaggedPortfolioRepository.GetAsync(Id);

                return ObjectMapper.Map<TaggedPortfolioListDto>(TaggedPortfolios);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TaggedPortfolio));
            }
        }

        public async Task<string> UpdateTaggedPortfolio(UpdateTaggedPortfolioDto input)
        {
            string ResponseString = "";
            try
            {
                var TaggedPortfolios = _TaggedPortfolioRepository.Get(input.Id);
                if (TaggedPortfolios != null && TaggedPortfolios.Id > 0)
                {
                    ObjectMapper.Map(input, TaggedPortfolios);
                    await _TaggedPortfolioRepository.UpdateAsync(TaggedPortfolios);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", TaggedPortfolio));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", TaggedPortfolio));
            }
        }

        public async Task<TaggedPortfolioListDto> GetTaggedPortfolioByApplicationId(int ApplicationId)
        {
            try
            {
                var TaggedPortfolios = _TaggedPortfolioRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var TaggedPortfolioz = ObjectMapper.Map<TaggedPortfolioListDto>(TaggedPortfolios);
                return TaggedPortfolioz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TaggedPortfolio));
            }
        }

        public List<TaggedPortfolioListDto> GetAllTaggedPortfolio()
        {
            try
            {
                var TaggedPortfolios = _TaggedPortfolioRepository.GetAllList();
                var TaggedPortfolioz = ObjectMapper.Map<List<TaggedPortfolioListDto>>(TaggedPortfolios);
                return TaggedPortfolioz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TaggedPortfolio));
            }
        }


        public bool CheckTaggedPortfolioByApplicationId(int ApplicationId)
        {
            try
            {
                var TaggedPortfolios = _TaggedPortfolioRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if(TaggedPortfolios!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", TaggedPortfolio));
            }

        }
    }
}
