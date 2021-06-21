using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.CompanyBankAccounts.Dto;

namespace TFCLPortal.CompanyBankAccounts.Dto
{
    public class CompanyBankAccountAppService : TFCLPortalAppServiceBase, ICompanyBankAccountAppService
    {
        private readonly IRepository<CompanyBankAccount, Int32> _CompanyBankAccountRepository;
        private string company = "Company Bank Account";
        public CompanyBankAccountAppService(IRepository<CompanyBankAccount, Int32> CompanyBankAccountRepository)
        {
            _CompanyBankAccountRepository = CompanyBankAccountRepository;
        }
        public async Task CreateCompanyBankAccount(CreateCompanyBankAccountDto input)
        {
            try
            {
                var CompanyBankAccount = ObjectMapper.Map<CompanyBankAccount>(input);
                await _CompanyBankAccountRepository.InsertAsync(CompanyBankAccount);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", company));
            }
        }
        public  CompanyBankAccountListDto GetCompanyBankAccountById(int Id)
        {
            try
            {
                var CompanyBankAccount = _CompanyBankAccountRepository.Get(Id);

                return ObjectMapper.Map<CompanyBankAccountListDto>(CompanyBankAccount);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<CompanyBankAccountListDto> GetCompanyBankAccountListDetail()
        {
            try
            {
                var CompanyBankAccount = _CompanyBankAccountRepository.GetAll();

                return ObjectMapper.Map<List<CompanyBankAccountListDto>>(CompanyBankAccount);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }
        }

        public async Task<string> UpdateCompanyBankAccount(UpdateCompanyBankAccountDto input)
        {
            string ResponseString = "";
            try
            {
                var CompanyBankAccount = _CompanyBankAccountRepository.Get(input.Id);
                if (CompanyBankAccount != null && CompanyBankAccount.Id > 0)
                {
                    ObjectMapper.Map(input, CompanyBankAccount);
                    await _CompanyBankAccountRepository.UpdateAsync(CompanyBankAccount);
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
