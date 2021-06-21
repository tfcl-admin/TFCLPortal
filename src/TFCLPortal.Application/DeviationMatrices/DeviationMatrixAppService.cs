using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeviationMatrices.Dto;
using TFCLPortal.DynamicDropdowns.ProductTypes;

namespace TFCLPortal.DeviationMatrices
{
    public class DeviationMatrixAppService : TFCLPortalAppServiceBase, IDeviationMatrixAppService
    {
        private readonly IRepository<DeviationMatrix> _deviationMatrixRepository;
        private readonly IRepository<ProductType> _productTypeRepository;

        public DeviationMatrixAppService(IRepository<DeviationMatrix> deviationMatrixRepository, IRepository<ProductType> productTypeRepository)
        {
            _deviationMatrixRepository = deviationMatrixRepository;
            _productTypeRepository = productTypeRepository;
        }
        public async Task<string> CreateDeviationMatrix(CreateDeviationMatrixDto input)
        {
            try
            {
                var deviationMatrixResult = _deviationMatrixRepository.GetAllList().Where(x => x.fk_ProductId == input.fk_ProductId).FirstOrDefault();
                if (deviationMatrixResult != null)
                {
                    var deviationMatrixMapped = ObjectMapper.Map<DeviationMatrix>(deviationMatrixResult);
                    _deviationMatrixRepository.Delete(deviationMatrixMapped);
                }

                var deviationMatrix = ObjectMapper.Map<DeviationMatrix>(input);
                await _deviationMatrixRepository.InsertAsync(deviationMatrix);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public List<DeviationMatrixListDto> GetDeviationMatrices()
        {

            try
            {
                var deviationMatrix = _deviationMatrixRepository.GetAllList();
                
                var Deviations = ObjectMapper.Map<List<DeviationMatrixListDto>>(deviationMatrix);

                if (Deviations != null)
                {
                    foreach(var Deviation in Deviations)
                    {
                        if (Deviation.fk_ProductId != 0)
                        {
                            var Product = _productTypeRepository.GetAllList().Where(x => x.Id == Deviation.fk_ProductId).FirstOrDefault();
                            Deviation.ProductName = Product.Name;
                        }
                    }                 
                }
                return Deviations.OrderBy(x=>x.ProductName).ToList();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Deviation Matrix"));
            }
        }


        public async Task<DeviationMatrixListDto> GetDeviationMatrixByProductId(int ProductId)
        {

            try
            {
                var deviationMatrix = _deviationMatrixRepository.GetAllList().Where(x=>x.fk_ProductId==ProductId).SingleOrDefault();

                var Deviations = ObjectMapper.Map<DeviationMatrixListDto>(deviationMatrix);

                return Deviations;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Deviation Matrix"));
            }
        }

        public DeviationMatrixListDto GetDeviationMatrixById(int Id)
        {
            try
            {
                var deviationMatrix = _deviationMatrixRepository.Get(Id);
                var deviation= ObjectMapper.Map<DeviationMatrixListDto>(deviationMatrix); 
                if (deviation.fk_ProductId != 0)
                {
                    var Product = _productTypeRepository.GetAllList().Where(x => x.Id == deviation.fk_ProductId).FirstOrDefault();
                    deviation.ProductName = Product.Name;
                }
                return deviation;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Deviation Matrix"));
            }
        }

        public async Task<string> UpdateDeviationMatrix(CreateDeviationMatrixDto input)
        {
            string ResponseString = "";
            try
            {
                var deviationMatrix = _deviationMatrixRepository.GetAllList(x=>x.fk_ProductId==input.fk_ProductId).FirstOrDefault();
                if (deviationMatrix!=null)
                {

                    await _deviationMatrixRepository.DeleteAsync(deviationMatrix);
                    var str=CreateDeviationMatrix(input);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "Deviation Matrix"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Deviation Matrix"));
            }
        }
    }
}
