using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CompanyBankAccounts;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.WriteOffs.Dto;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.WriteOffs
{
    public class WriteOffAppService : TFCLPortalAppServiceBase, IWriteOffAppService
    {
        #region Properties
        private readonly IRepository<WriteOff, int> _WriteOffRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IApplicationAppService _applicationAppService;


        #endregion
        #region Constructor 
        public WriteOffAppService(IRepository<WriteOff> WriteOffRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _WriteOffRepository = WriteOffRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
            _applicationAppService = applicationAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateWriteOff createWriteOff)
        {
            try
            {
                var WriteOff = ObjectMapper.Map<WriteOff>(createWriteOff);
                await _WriteOffRepository.InsertAsync(WriteOff);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<WriteOffListDto> GetWriteOffById(int Id)
        {
            try
            {
                var WriteOff = await _WriteOffRepository.GetAsync(Id);

                if (WriteOff != null)
                {
                    var mapped = ObjectMapper.Map<WriteOffListDto>(WriteOff);

                    var app = _applicationAppService.GetApplicationById(mapped.ApplicationId);

                    mapped.ClientID = app.ClientID;
                    mapped.ClientName = app.ClientName;
                    mapped.SchoolName = app.SchoolName;
                    mapped.CNIC = app.CNICNo;

                    return mapped;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(EditWriteOff editWriteOff)
        {
            string ResponseString = "";
            try
            {


                var WriteOff = _WriteOffRepository.Get(editWriteOff.Id);
                if (WriteOff != null && WriteOff.Id > 0)
                {
                    ObjectMapper.Map(editWriteOff, WriteOff);
                    await _WriteOffRepository.UpdateAsync(WriteOff);

                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "payment"));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "payment"));
            }
            return ResponseString;
        }

        public async Task<List<WriteOffListDto>> GetWriteOffByApplicationId(int ApplicationId)
        {
            try
            {
                var WriteOff = _WriteOffRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<WriteOffListDto>>(WriteOff);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<WriteOffListDto>> GetAllWriteOffs()
        {
            try
            {
                var WriteOff = _WriteOffRepository.GetAllList().ToList();
                var payments = ObjectMapper.Map<List<WriteOffListDto>>(WriteOff);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckWriteOffByApplicationId(int ApplicationId)
        {
            try
            {
                var WriteOff = _WriteOffRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (WriteOff != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "payment"));
            }
        }
        #endregion
    }
}
