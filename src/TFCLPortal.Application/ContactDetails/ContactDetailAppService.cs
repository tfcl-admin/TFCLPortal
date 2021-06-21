using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.ContactDetails.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;

namespace TFCLPortal.ContactDetails
{
    public class ContactDetailAppService : TFCLPortalAppServiceBase, IContactDetailAppService
    {
        private readonly IRepository<ContactDetail, Int32> _contactDetailRepository;
        private readonly IRepository<OwnershipStatus> _ownershipStatusRepository;
        private readonly IRepository<Province> _provinceRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<RentAgreementSignatory> _rentAgreementSignatoryRepository;
        private string ContactDetails = "Contact Detail";
        public ContactDetailAppService(IRepository<ContactDetail, Int32> contactDetailRepository,
            IRepository<OwnershipStatus> ownershipStatusRepository,
            IRepository<Province> provinceRepository,
            IApiCallLogAppService apiCallLogAppService,
            IApplicationAppService applicationAppService,
            IRepository<RentAgreementSignatory> rentAgreementSignatoryRepository,
            IRepository<District> districtRepository)
        {
            _contactDetailRepository = contactDetailRepository;
            _ownershipStatusRepository = ownershipStatusRepository;
            _provinceRepository = provinceRepository;
            _applicationAppService = applicationAppService;
            _districtRepository = districtRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _rentAgreementSignatoryRepository = rentAgreementSignatoryRepository;

        }
        public async Task<string> CreateContactDetail(CreateContactDetailDto input)
        {
            string ResponseString = "";

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateContactDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _contactDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsExist != null && IsExist.ApplicationId > 0)
                {
                    var contactDetail = _contactDetailRepository.Get(IsExist.Id);
                    contactDetail.Id = IsExist.Id;
                    contactDetail.ApplicationId = input.ApplicationId;
                    contactDetail.PresentAddress = input.PresentAddress;
                    contactDetail.PresentProvince = input.PresentProvince;
                    contactDetail.PresentDistrict = input.PresentDistrict;
                    contactDetail.PresentTehsil = input.PresentTehsil;
                    contactDetail.PresentUCNo = input.PresentUCNo;
                    contactDetail.PresentMouzaTown = input.PresentMouzaTown;
                    contactDetail.PresentNearestLandMark = input.PresentNearestLandMark;
                    contactDetail.OwnershipStatus = input.OwnershipStatus;
                    contactDetail.CurrentAddressSince = input.CurrentAddressSince;
                    contactDetail.IsSamePermanent = input.IsSamePermanent;
                    contactDetail.permanentAddress = input.permanentAddress;
                    contactDetail.permanentProvince = input.permanentProvince;
                    contactDetail.permanentDistrict = input.permanentDistrict;
                    contactDetail.permanentTehsil = input.permanentTehsil;
                    contactDetail.permanentUCNo = input.permanentUCNo;
                    contactDetail.permanentMouzaTown = input.permanentMouzaTown;
                    contactDetail.permanentNearestLandMark = input.permanentNearestLandMark;
                    contactDetail.MobileNo = input.MobileNo;
                    contactDetail.LandlineNo = input.LandlineNo;
                    contactDetail.AlternateMobileNo = input.AlternateMobileNo;
                    contactDetail.ScreenStatus = input.ScreenStatus;
                    contactDetail.Comments = input.Comments;
                    contactDetail.RentAmount = input.RentAmount;
                    contactDetail.RentAgreementSignatory = input.RentAgreementSignatory;
                    contactDetail.RentAgreementSignatoryOthers = input.RentAgreementSignatoryOthers;
                    contactDetail.MonthlyRentSharingPercentage = input.MonthlyRentSharingPercentage;
                    contactDetail.MonthlyShare = input.MonthlyShare;
                    contactDetail.AreaOfResidenceSqFt = input.AreaOfResidenceSqFt;
                    contactDetail.AlternateMobileNoSelf = input.AlternateMobileNoSelf;
                    contactDetail.FaxNo = input.FaxNo;
                    contactDetail.RentAgreementExpiryDate = input.RentAgreementExpiryDate;
                    contactDetail.AlternateMobileNoName = input.AlternateMobileNoName;

                    await _contactDetailRepository.UpdateAsync(contactDetail);
                }
                else
                {
                    var contactDetail = ObjectMapper.Map<ContactDetail>(input);
                    await _contactDetailRepository.InsertAsync(contactDetail);
                    _applicationAppService.UpdateApplicationLastScreen("CONTACT DETAILS", input.ApplicationId);

                }

                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", ContactDetails));
            }
        }

        public  ContactDetailListDto GetContactDetailById(int Id)
        {
            try
            {
                var contactDetail =  _contactDetailRepository.Get(Id);

                return ObjectMapper.Map<ContactDetailListDto>(contactDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ContactDetails));
            }
        }

        public async Task<string> UpdateContactDetail(UpdateContactDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var contactDetail = _contactDetailRepository.Get(input.Id);
                if (contactDetail != null && contactDetail.Id > 0)
                {
                    ObjectMapper.Map(input, contactDetail);
                    await _contactDetailRepository.UpdateAsync(contactDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", ContactDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", ContactDetails));
            }
        }

        public async Task<ContactDetailListDto> GetContactDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var contactDetail =  _contactDetailRepository.FirstOrDefault(x=>x.ApplicationId==ApplicationId);

                var contact= ObjectMapper.Map<ContactDetailListDto>(contactDetail);

                if (contact != null && contact.ApplicationId > 0)
                {
                    if (contact.OwnershipStatus != 0)
                    {
                        var OwnershipStatus = _ownershipStatusRepository.Get(contact.OwnershipStatus);
                        contact.OwnershipStatusName = OwnershipStatus.Name;
                    }
                    if (contact.permanentProvince != 0)
                    {
                        var permanentProvince = _provinceRepository.Get(contact.permanentProvince);
                        contact.PermanentProvinceName = permanentProvince.Name;
                    }
                    if (contact.PresentProvince != 0)
                    {
                        var presentprovince = _provinceRepository.Get(contact.PresentProvince);
                        contact.PresentProvinceName = presentprovince.Name;
                    }
                    if (contact.permanentDistrict != 0)
                    {
                        var permanentDistrict = _districtRepository.Get(contact.permanentDistrict);
                        contact.PermanentDistrictName = permanentDistrict.Name;
                    }
                    if (contact.PresentDistrict != 0)
                    {
                        var PresentDistrict = _districtRepository.Get(contact.PresentDistrict);
                        contact.PresentDistrictName = PresentDistrict.Name;
                    }
                    if (contact.RentAgreementSignatory != null && contact.RentAgreementSignatory != 0)
                    {
                        var RentAgreementSignatory = _rentAgreementSignatoryRepository.Get((int)contact.RentAgreementSignatory);
                        contact.RentAgreementSignatoryName = RentAgreementSignatory.Name;
                    }
                    if(contact.CurrentAddressSince!=null)
                    {
                        if (contact.LastModificationTime != null)
                        {
                        contact.currentAddressDuration = getDuration((DateTime)contact.CurrentAddressSince, (DateTime)contact.LastModificationTime);
                        }
                        else
                        {
                            contact.currentAddressDuration = getDuration((DateTime)contact.CurrentAddressSince, contact.CreationTime);
                        }
                    }

                }
                return contact;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", ContactDetails));
            }
        }

        public string getDuration(DateTime dStart, DateTime dEnd)
        {
            DateTime startDate = dStart;
            DateTime endDate = dEnd;
            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;


            return string.Format("{0} years, {1} months, {2} days", years, months, days);
        }

        public bool CheckContactDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var contactDetail = _contactDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (contactDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", ContactDetails));
            }
        }
    }
}
