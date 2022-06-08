using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.SchoolFinancials.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.DynamicDropdowns.SpouseFamilyOtherIncomes;

namespace TFCLPortal.SchoolFinancials
{
    public class SchoolFinancialAppService : TFCLPortalAppServiceBase, ISchoolFinancialAppService
    {
        private readonly IRepository<SchoolFinancial, int> _SchoolFinancialRepository;
        private readonly IRepository<SpouseFamilyOtherIncome, int> _SpouseFamilyOtherIncomeRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public SchoolFinancialAppService(IRepository<SpouseFamilyOtherIncome, int> SpouseFamilyOtherIncomeRepository,IRepository<SchoolFinancial, int> SchoolFinancialRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _SpouseFamilyOtherIncomeRepository = SpouseFamilyOtherIncomeRepository;
            _SchoolFinancialRepository = SchoolFinancialRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

        }

        public async Task<string> CreateSchoolFinancial(CreateSchoolFinancialDto Input)
        {
            try
            {
                var existing = _SchoolFinancialRepository.GetAllList(x => x.ApplicationId == Input.ApplicationId).ToList();
                if(existing.Count>0)
                {
                    foreach(var sf in existing)
                    {
                        _SchoolFinancialRepository.Delete(sf);
                    }
                }

                var filUpload = ObjectMapper.Map<SchoolFinancial>(Input);
                await _SchoolFinancialRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }


        public async Task<SchoolFinancialListDto> GetSchoolFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolFinancialRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var files = ObjectMapper.Map<SchoolFinancialListDto>(filesList);

                if(files!=null)
                {
                    if(files.spouseFamilyOtherIncome!=0)
                    {
                        files.spouseFamilyOtherIncomeName = _SpouseFamilyOtherIncomeRepository.Get(files.spouseFamilyOtherIncome).Name;
                    }
                }

                //foreach (var file in files)
                //{
                //    if(file.Fk_idForName!=0)
                //    {
                //        if (file.ScreenCode.StartsWith("co_applicant"))
                //        {
                //            var coapplicantFile=_coApplicantDetailAppService.GetCoApplicantDetailById(file.Fk_idForName).Result.FirstOrDefault();
                //            if(coapplicantFile!=null)
                //            {
                //                file.RespectiveName = coapplicantFile.FullName;
                //            }
                //        }
                //        else if (file.ScreenCode.StartsWith("guarantor"))
                //        {
                //            var guarantorFile = _guarantorDetailAppService.GetGuarantorDetailById(file.Fk_idForName).Result.FirstOrDefault();
                //            if (guarantorFile != null)
                //            {
                //                file.RespectiveName = guarantorFile.FullName;
                //            }
                //        }

                //    }
                //}


                return files;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }

        public bool CheckSchoolFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolFinancialRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
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
