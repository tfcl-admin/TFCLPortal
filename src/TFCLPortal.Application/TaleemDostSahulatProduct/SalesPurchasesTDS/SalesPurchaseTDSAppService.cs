using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS.Dto;

namespace TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS
{
    public class SalesPurchaseTDSAppService : TFCLPortalAppServiceBase, ISalesPurchaseTDSAppService
    {
        private readonly IRepository<SalesPurchaseTDS, Int32> _salesPurchaseTDSRepository;

        public SalesPurchaseTDSAppService(IRepository<SalesPurchaseTDS, Int32> salesPurchaseTDSRepository)
        {
            _salesPurchaseTDSRepository = salesPurchaseTDSRepository;
        }

        public async Task CreateSalesPurchaseTDS(CreateSalesPurchaseTDSDto input)
        {
            try
            {
                var salepurchase = ObjectMapper.Map<SalesPurchaseTDS>(input);
                var result = await _salesPurchaseTDSRepository.InsertAsync(salepurchase);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sale Purchase"));
            }
        }

        public SalesPurchaseTDSListDto GetSalesPurchaseTDSByApplicationId(int ApplicationId)
        {
            try
            {
                var salepurchase = _salesPurchaseTDSRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var result = ObjectMapper.Map<SalesPurchaseTDSListDto>(salepurchase);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Sale Purchase"));
            }
        }

        public async Task<SalesPurchaseTDSListDto> GetSalesPurchaseTDSById(int Id)
        {
            try
            {
                var salepurchase = await _salesPurchaseTDSRepository.GetAsync(Id);
                var result = ObjectMapper.Map<SalesPurchaseTDSListDto>(salepurchase);
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Sale Purchase"));
            }
        }

        public async Task<string> UpdateFinancialInformationTDSTDS(UpdateSalesPurchaseTDSDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var salepurchase = _salesPurchaseTDSRepository.Get(input.Id);
                if (salepurchase != null && salepurchase.Id > 0)
                {
                    ObjectMapper.Map(input, salepurchase);

                    await _salesPurchaseTDSRepository.UpdateAsync(salepurchase);
                    CurrentUnitOfWork.SaveChanges();
                }
                return ResponseString;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Sale Purchase"));
            }
        }
    }
}
