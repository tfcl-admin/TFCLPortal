using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.BankAccountChildDetails;
using TFCLPortal.BankAccountDetails.Dto;
using TFCLPortal.Banks;

namespace TFCLPortal.BankAccountDetails
{
    public class BankAccountAppService : TFCLPortalAppServiceBase, IBankAccountAppService
    {

        private readonly IRepository<BankAccountDetail, int> _bankAccountDetailRepository;
        private readonly IRepository<BankAccountChildDetail, int> _bankAccountChildDetailRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<Bank, int> _bankNameRepository;
        private string bankAccountDetail = "Bank Account Detail";

        public BankAccountAppService(IRepository<BankAccountDetail, int> repository, IApplicationAppService applicationAppService, IRepository<Bank, int> bankNameRepository, IRepository<BankAccountChildDetail, int> bankAccountChildDetailRepository)
        {
            _bankAccountDetailRepository = repository;
            _bankAccountChildDetailRepository = bankAccountChildDetailRepository;
            _bankNameRepository = bankNameRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateBankDetail(CreateBankAccountDto input, int applicationId)
        {

            try
            {

                var IsExist = _bankAccountDetailRepository.GetAllList().Where(x => x.ApplicationId == applicationId).ToList();
                if (IsExist.Count > 0)
                {
                    foreach (var bankacc in IsExist)
                    {
                        var bankDetail = ObjectMapper.Map<BankAccountDetail>(bankacc);
                        var IsChildExist = _bankAccountChildDetailRepository.GetAllList().Where(x => x.Fk_BankAccountDetail == bankacc.Id).ToList();
                        if (IsExist != null)
                        {
                            foreach (var bankAccChild in IsChildExist)
                            {
                                _bankAccountChildDetailRepository.Delete(bankAccChild);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                        _bankAccountDetailRepository.Delete(bankDetail);
                        CurrentUnitOfWork.SaveChanges();
                    }
                    foreach (BankAccountDto bankAccount in input.BankAccountDetails)
                    {
                        bankAccount.ApplicationId = applicationId;
                        var bankDetail = ObjectMapper.Map<BankAccountDetail>(bankAccount);
                        var result = _bankAccountDetailRepository.Insert(bankDetail);
                        CurrentUnitOfWork.SaveChanges();

                        if (bankAccount.BankAccountChilds.Count > 0)
                        {
                            foreach (var BankAccountChild in bankAccount.BankAccountChilds)
                            {
                                var bankChildDetail = ObjectMapper.Map<BankAccountChildDetail>(BankAccountChild);
                                bankChildDetail.Fk_BankAccountDetail = result.Id;
                                _bankAccountChildDetailRepository.Insert(bankChildDetail);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }
                    }
                }
                else
                {
                    foreach (BankAccountDto bankAccount in input.BankAccountDetails)
                    {
                        bankAccount.ApplicationId = applicationId;
                        var bankDetail = ObjectMapper.Map<BankAccountDetail>(bankAccount);
                        var result = _bankAccountDetailRepository.Insert(bankDetail);
                        CurrentUnitOfWork.SaveChanges();

                        if (bankAccount.BankAccountChilds.Count > 0)
                        {
                            foreach (var BankAccountChild in bankAccount.BankAccountChilds)
                            {
                                var bankChildDetail = ObjectMapper.Map<BankAccountChildDetail>(BankAccountChild);
                                bankChildDetail.Fk_BankAccountDetail = result.Id;
                                _bankAccountChildDetailRepository.Insert(bankChildDetail);
                                CurrentUnitOfWork.SaveChanges();

                            }
                        }
                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Bank Account Detail", applicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", bankAccountDetail));
            }

        }

        public async Task<List<BankAccountListDto>> GetBankAccountDetailById(int Id)
        {
            try
            {
                var bankAccountDetailsList = _bankAccountDetailRepository.GetAllList().Where(x => x.Id == Id).ToList();

                return ObjectMapper.Map<List<BankAccountListDto>>(bankAccountDetailsList);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bankAccountDetail));
            }
        }

        public async Task<string> UpdateBankAccountDetail(List<UpdateBankDto> input)
        {

            // CheckUpdatePermission();
            string ResponseString = "";
            try
            {

                foreach (UpdateBankDto bankAccount in input)
                {
                    var bankDetail = _bankAccountDetailRepository.Get(bankAccount.Id);
                    if (bankDetail != null && bankDetail.Id > 0)
                    {


                        ObjectMapper.Map(bankAccount, bankDetail);

                        await _bankAccountDetailRepository.UpdateAsync(bankDetail);

                        CurrentUnitOfWork.SaveChanges();
                        ResponseString = "Records Updated Successfully";
                    }
                    else
                    {
                        throw new UserFriendlyException(L("UpdateMethodError{0}", bankAccountDetail));

                    }
                }

                return ResponseString;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", bankAccountDetail));
            }
        }

        public async Task<List<BankAccountListDto>> GetBankAccountDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var bankAccountDetailsList = _bankAccountDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId);
                if (bankAccountDetailsList.Count > 0)
                {
                    var bankAccountMapped = ObjectMapper.Map<List<BankAccountListDto>>(bankAccountDetailsList);
                    foreach (var BankAccount in bankAccountMapped)
                    {
                        var bankAccountChildList = _bankAccountChildDetailRepository.GetAllList(x => x.Fk_BankAccountDetail == BankAccount.Id);
                        var bankAccountChildMapped = ObjectMapper.Map<List<BankAccountChildListDto>>(bankAccountChildList);
                        BankAccount.BankAccountChilds = bankAccountChildMapped;

                        if(BankAccount.BankName!=null || BankAccount.BankName != 0)
                        {
                            var bankName = _bankNameRepository.Get((int)BankAccount.BankName);
                            BankAccount.BankFullName = bankName.Name;
                        }
                    }
                    
                    return bankAccountMapped;
                }
                else
                {
                    return new List<BankAccountListDto>();
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", bankAccountDetail));
            }
        }

        public bool CheckBankAccountDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var bankAccountDetailsList = _bankAccountDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                if (bankAccountDetailsList.Count>0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", bankAccountDetail));
            }
        }
    }
}
