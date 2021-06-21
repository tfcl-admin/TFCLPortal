using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Company.Dto;

namespace TFCLPortal.Companies.Dto
{
    public class CompanyDetailAppService : TFCLPortalAppServiceBase, ICompanyDetailAppService
    {
        private readonly IRepository<Company, Int32> _companyRepository;
        private string company = "Company Detail";
        public CompanyDetailAppService(IRepository<Company, Int32> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task CreateCompanyDetail(CreateCompanyDetailDto input)
        {
            try
            {
                var companyDetail = ObjectMapper.Map<Company>(input);
                await _companyRepository.InsertAsync(companyDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", company));
            }
        }
        public  CompanyDetailListDto GetCompanyDetailById(int Id)
        {
            try
            {
                var companyDetail = _companyRepository.Get(Id);

                return ObjectMapper.Map<CompanyDetailListDto>(companyDetail);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<CompanyDetailListDto> GetCompanyListDetail()
        {
            try
            {
                var companyDetail = _companyRepository.GetAll();

                return ObjectMapper.Map<List<CompanyDetailListDto>>(companyDetail);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }
        }

        public async Task<string> UpdateCompanyDetail(UpdateCompanyDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var companyDetail = _companyRepository.Get(input.Id);
                if (companyDetail != null && companyDetail.Id > 0)
                {
                    ObjectMapper.Map(input, companyDetail);
                    await _companyRepository.UpdateAsync(companyDetail);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", company));
            }
            return ResponseString;
        }
    }
}
