using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS.Dto;

namespace TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS
{
    public class FinancialInformationTDSAppService : TFCLPortalAppServiceBase, IFinancialInformationTDSAppService
    {
        private readonly IRepository<FinancialInformationTDS, Int32> _financialInformationTDSRepository;

        public FinancialInformationTDSAppService(IRepository<FinancialInformationTDS, Int32> financialInformationTDSRepository)
        {
            _financialInformationTDSRepository = financialInformationTDSRepository;
        }

        public async Task CreateFinancialInformationTDSTDS(CreateFinancialInformationTDSDto input)
        {
            try
            {
                var financialInformaton = ObjectMapper.Map<FinancialInformationTDS>(input);
                var result = await _financialInformationTDSRepository.InsertAsync(financialInformaton);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Financial Information"));
            }
        }

        public  FinancialInformationTDSListDto GeFinancialInformationTDSByApplicationId(int ApplicationId)
        {
            try
            {
                var financialInformation = _financialInformationTDSRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var result = ObjectMapper.Map<FinancialInformationTDSListDto>(financialInformation);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Financial Information"));
            }
        }

        public async Task<FinancialInformationTDSListDto> GetFinancialInformationTDSById(int Id)
        {
            try
            {
                var financialInformation = await _financialInformationTDSRepository.GetAsync(Id);
                var result = ObjectMapper.Map<FinancialInformationTDSListDto>(financialInformation);
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Financial Information"));
            }
        }

        public async Task<string> UpdateFinancialInformationTDSTDS(UpdateFinancialInformationTDSDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var financialInformation = _financialInformationTDSRepository.Get(input.Id);
                if (financialInformation != null && financialInformation.Id > 0)
                {
                    ObjectMapper.Map(input, financialInformation);

                    await _financialInformationTDSRepository.UpdateAsync(financialInformation);
                    CurrentUnitOfWork.SaveChanges();
                }
                return ResponseString;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Financial Information"));
            }
        }
    }
}
