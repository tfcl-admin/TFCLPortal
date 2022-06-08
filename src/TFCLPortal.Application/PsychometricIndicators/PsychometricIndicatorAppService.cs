using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.PsychometricIndicators.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.DynamicDropdowns.PeopleSteals;
using TFCLPortal.DynamicDropdowns.AvoidConflicts;
using TFCLPortal.DynamicDropdowns.BiggestMotivations;
using TFCLPortal.DynamicDropdowns.HopefulFutures;
using TFCLPortal.DynamicDropdowns.DigitalInitiatives;
using TFCLPortal.DynamicDropdowns.TeacherTrainingDays;
using TFCLPortal.DynamicDropdowns.ParentEngagements;

namespace TFCLPortal.PsychometricIndicators
{
    public class PsychometricIndicatorAppService : TFCLPortalAppServiceBase, IPsychometricIndicatorAppService
    {
        private readonly IRepository<PsychometricIndicator, int> _PsychometricIndicatorRepository;
        private readonly IRepository<PeopleSteal, int> _PeopleStealRepository;
        private readonly IRepository<AvoidConflict, int> _AvoidConflictRepository;
        private readonly IRepository<BiggestMotivation, int> _BiggestMotivationRepository;
        private readonly IRepository<HopefulFuture, int> _HopefulFutureRepository;
        private readonly IRepository<DigitalInitiative, int> _DigitalInitiativeRepository;
        private readonly IRepository<TeacherTrainingDay, int> _TeacherTrainingDayRepository;
        private readonly IRepository<ParentEngagement, int> _ParentEngagementRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public PsychometricIndicatorAppService(
            IRepository<PsychometricIndicator, int> PsychometricIndicatorRepository,
             IRepository<PeopleSteal, int> PeopleStealRepository,
        IRepository<AvoidConflict, int> AvoidConflictRepository,
        IRepository<BiggestMotivation, int> BiggestMotivationRepository,
        IRepository<HopefulFuture, int> HopefulFutureRepository,
        IRepository<DigitalInitiative, int> DigitalInitiativeRepository,
        IRepository<TeacherTrainingDay, int> TeacherTrainingDayRepository,
        IRepository<ParentEngagement, int> ParentEngagementRepository,
        IApplicationAppService applicationAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _ParentEngagementRepository = ParentEngagementRepository;
            _TeacherTrainingDayRepository = TeacherTrainingDayRepository;
            _BiggestMotivationRepository = BiggestMotivationRepository;
            _DigitalInitiativeRepository = DigitalInitiativeRepository;
            _HopefulFutureRepository = HopefulFutureRepository;
            _PeopleStealRepository = PeopleStealRepository;
            _AvoidConflictRepository = AvoidConflictRepository;
            _PsychometricIndicatorRepository = PsychometricIndicatorRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

        }

        public async Task<string> CreatePsychometricIndicator(CreatePsychometricIndicatorDto Input)
        {
            try
            {
                var filUpload = ObjectMapper.Map<PsychometricIndicator>(Input);
                await _PsychometricIndicatorRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }


        public async Task<PsychometricIndicatorListDto> GetPsychometricIndicatorByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _PsychometricIndicatorRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var files = ObjectMapper.Map<PsychometricIndicatorListDto>(filesList);

                if (files != null)
                {

                    if (files.PercentageToSteal != 0)
                    {
                        files.PercentageToStealName = _PeopleStealRepository.Get(files.PercentageToSteal).Name;
                    }
                    if (files.AvoidConflict != 0)
                    {
                        files.AvoidConflictName = _AvoidConflictRepository.Get(files.AvoidConflict).Name;

                    }
                    if (files.MotivationToRunSchool != 0)
                    {
                        files.MotivationToRunSchoolName = _BiggestMotivationRepository.Get(files.MotivationToRunSchool).Name;

                    }
                    if (files.HopefulForFuture != 0)
                    {
                        files.HopefulForFutureName = _HopefulFutureRepository.Get(files.HopefulForFuture).Name;

                    }
                    if (files.DigitalInitiatives != 0)
                    {
                        files.DigitalInitiativesName = _DigitalInitiativeRepository.Get(files.DigitalInitiatives).Name;

                    }
                    if (files.TeacherTrainings != 0)
                    {
                        files.TeacherTrainingsName = _TeacherTrainingDayRepository.Get(files.TeacherTrainings).Name;

                    }
                    if (files.ParentEngagement != 0)
                    {
                        files.ParentEngagementName = _ParentEngagementRepository.Get(files.ParentEngagement).Name;
                    }

                }

                return files;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }

        public bool CheckPsychometricIndicatorByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _PsychometricIndicatorRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                if (filesList.Count > 0)
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
