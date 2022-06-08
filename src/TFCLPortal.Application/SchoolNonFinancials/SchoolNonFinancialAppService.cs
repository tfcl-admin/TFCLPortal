using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.SchoolNonFinancials.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.DynamicDropdowns.BuildingConditions;
using TFCLPortal.DynamicDropdowns.FinancialRecords;
using TFCLPortal.DynamicDropdowns.BusinessRadiuses;
using TFCLPortal.DynamicDropdowns.BankingTransactiones;
using TFCLPortal.DynamicDropdowns.OtherPaymentBehaviours;

namespace TFCLPortal.SchoolNonFinancials
{
    public class SchoolNonFinancialAppService : TFCLPortalAppServiceBase, ISchoolNonFinancialAppService
    {
        private readonly IRepository<SchoolNonFinancial, int> _SchoolNonFinancialRepository;
        private readonly IRepository<BuildingCondition, int> _BuildingConditionRepository;
        private readonly IRepository<FinancialRecord, int> _FinancialRecordRepository;
        private readonly IRepository<BusinessRadius, int> _BusinessRadiusRepository;
        private readonly IRepository<BankingTransaction, int> _BankingTransactionRepository;
        private readonly IRepository<OtherPaymentBehaviour, int> _OtherPaymentBehaviourRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public SchoolNonFinancialAppService(IRepository<OtherPaymentBehaviour, int> OtherPaymentBehaviourRepository,IRepository<BankingTransaction, int> BankingTransactionRepository,IRepository<BusinessRadius, int> BusinessRadiusRepository,IRepository<FinancialRecord, int> FinancialRecordRepository,IRepository<BuildingCondition, int> BuildingConditionRepository,IRepository<SchoolNonFinancial, int> SchoolNonFinancialRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _OtherPaymentBehaviourRepository = OtherPaymentBehaviourRepository;
            _BankingTransactionRepository = BankingTransactionRepository;
            _BusinessRadiusRepository = BusinessRadiusRepository;
            _FinancialRecordRepository = FinancialRecordRepository;
            _BuildingConditionRepository = BuildingConditionRepository;
            _SchoolNonFinancialRepository = SchoolNonFinancialRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

        }

        public async Task<string> CreateSchoolNonFinancial(CreateSchoolNonFinancialDto Input)
        {
            try
            {
                var filUpload = ObjectMapper.Map<SchoolNonFinancial>(Input);
                await _SchoolNonFinancialRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }


        public async Task<SchoolNonFinancialListDto> GetSchoolNonFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolNonFinancialRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var files = ObjectMapper.Map<SchoolNonFinancialListDto>(filesList);

                if(files!=null)
                {
                    if(files.BuildingCondition!=0)
                    {
                        files.BuildingConditionName = _BuildingConditionRepository.Get(files.BuildingCondition).Name;
                    }
                    if (files.TransactionHistory != 0)
                    {
                        files.TransactionHistoryName = _BankingTransactionRepository.Get(files.TransactionHistory).Name;
                    }
                    if (files.FinancialRecords != 0)
                    {
                        files.FinancialRecordsName = _FinancialRecordRepository.Get(files.FinancialRecords).Name;
                    }
                    if (files.BusinessRadius != 0)
                    {
                        files.BusinessRadiusName = _BusinessRadiusRepository.Get(files.BusinessRadius).Name;
                    }
                    if (files.OtherPaymentBehaviour != 0)
                    {
                        files.OtherPaymentBehaviourName = _OtherPaymentBehaviourRepository.Get(files.OtherPaymentBehaviour).Name;
                    }
                }

                return files;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }

        public bool CheckSchoolNonFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolNonFinancialRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                if (filesList.Count>0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }
    }
}
