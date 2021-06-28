using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ColatteralGolds;
using TFCLPortal.CollateralDetails.Dto;
using TFCLPortal.CollateralLandBuildings;
using TFCLPortal.CollateralTDRs;
using TFCLPortal.CollateralVehicles;
using TFCLPortal.CollateralFranchises;
using TFCLPortal.DynamicDropdowns.CollateralTypes;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.PropertyTypes;
using TFCLPortal.Applications;
using TFCLPortal.ApiCallLogs.Dto;
using Newtonsoft.Json;
using TFCLPortal.DynamicDropdowns.RelationshipWithApplicants;
using TFCLPortal.DynamicDropdowns.CollateralOwnerships;

namespace TFCLPortal.CollateralDetails
{
    public class CollateralDetailAppService : TFCLPortalAppServiceBase, ICollateralDetailAppService
    {
        private readonly IRepository<CollateralDetail, Int32> _collateralDetailRepository;
        private readonly IRepository<CollateralGold, Int32> _collateralGoldRepository;
        private readonly IRepository<CollateralVehicle, Int32> _collateralVehicleRepository;
        private readonly IRepository<CollateralLandBuilding, Int32> _collateralLandBuildingRepository;
        private readonly IRepository<CollateralFranchise, Int32> _collateralFranchiseRepository;
        private readonly IRepository<CollateralTDR, Int32> _collateralTDRRepository;
        private readonly IRepository<OwnershipStatus> _ownershipStatusRepository;
        private readonly IRepository<RelationshipWithApplicant> _relationshipWithApplicantRepository;
        private readonly IRepository<PropertyType> _propertyTyperepo;
        private readonly IRepository<CollateralOwnership> _collateralOwnershipDto;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<CollateralType> _collateralType;
        private string collateralDetails = "Collateral Detail";
        public CollateralDetailAppService(
            IRepository<CollateralDetail, Int32> collateralDetailRepository,
            IRepository<CollateralGold, Int32> collateralGoldRepository,
            IRepository<CollateralVehicle, Int32> collateralVehicleRepository,
            IRepository<CollateralFranchise, Int32> collateralFranchiseRepository,
            IRepository<CollateralLandBuilding, Int32> collateralLandBuildingRepository,
            IRepository<CollateralTDR, Int32> collateralTDRRepository,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<CollateralOwnership> collateralOwnershipDto,
            IRepository<OwnershipStatus> ownershipStatusRepository,
            IRepository<PropertyType> PropertyTyperepo,
            IApplicationAppService applicationAppService,
            IRepository<RelationshipWithApplicant> relationshipWithApplicantRepository,
            IRepository<CollateralType> collateralType)
        {
            _collateralDetailRepository = collateralDetailRepository;
            _collateralGoldRepository = collateralGoldRepository;
            _collateralVehicleRepository = collateralVehicleRepository;
            _collateralLandBuildingRepository = collateralLandBuildingRepository;
            _collateralTDRRepository = collateralTDRRepository;
            _ownershipStatusRepository = ownershipStatusRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _collateralOwnershipDto = collateralOwnershipDto;
            _propertyTyperepo = PropertyTyperepo;
            _collateralType = collateralType;
            _collateralFranchiseRepository = collateralFranchiseRepository;
            _relationshipWithApplicantRepository = relationshipWithApplicantRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task CreateCollateralDetail(CreateCollateralDetailDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateCollateralDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsCollateralExist = _collateralDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
                if (IsCollateralExist != null)
                {
                    var IsLandBuildingExist = _collateralLandBuildingRepository.GetAllList().Where(x => x.Fk_ColateralID == IsCollateralExist.Id).ToList();
                    var IsVehiclExist = _collateralVehicleRepository.GetAllList().Where(x => x.Fk_ColateralID == IsCollateralExist.Id).ToList();
                    var IsTDRExist = _collateralTDRRepository.GetAllList().Where(x => x.Fk_ColateralID == IsCollateralExist.Id).ToList();
                    var IsGoldExist = _collateralGoldRepository.GetAllList().Where(x => x.Fk_ColateralID == IsCollateralExist.Id).ToList();
                    var IsFranchiseExist = _collateralFranchiseRepository.GetAllList().Where(x => x.Fk_ColateralID == IsCollateralExist.Id).ToList();

                    var collateralDetail1 = ObjectMapper.Map<CollateralDetail>(IsCollateralExist);
                    await _collateralDetailRepository.DeleteAsync(collateralDetail1);

                    var collateralDetail = ObjectMapper.Map<CollateralDetail>(input);
                    var result = await _collateralDetailRepository.InsertAsync(collateralDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (IsLandBuildingExist.Count > 0)
                    {
                        foreach (var land in IsLandBuildingExist)
                        {
                            land.Fk_ColateralID = result.Id;
                            var lands = ObjectMapper.Map<CollateralLandBuilding>(land);
                            await _collateralLandBuildingRepository.DeleteAsync(lands);
                            CurrentUnitOfWork.SaveChanges();
                        }
                        if (input.createCollateralLandBuilding.Count() > 0)
                        {
                            List<CreateCollateralLandBuildingDto> createCollateralLandBuildingDtos = input.createCollateralLandBuilding;
                            foreach (var createCollateralLandBuildingDto in createCollateralLandBuildingDtos)
                            {
                                createCollateralLandBuildingDto.Fk_ColateralID = result.Id;
                                var collateralLandDto = ObjectMapper.Map<CollateralLandBuilding>(createCollateralLandBuildingDto);
                                await _collateralLandBuildingRepository.InsertAsync(collateralLandDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if (input.createCollateralLandBuilding.Count() > 0)
                        {
                            List<CreateCollateralLandBuildingDto> createCollateralLandBuildingDtos = input.createCollateralLandBuilding;
                            foreach (var createCollateralLandBuildingDto in createCollateralLandBuildingDtos)
                            {
                                createCollateralLandBuildingDto.Fk_ColateralID = result.Id;
                                var collateralLandDto = ObjectMapper.Map<CollateralLandBuilding>(createCollateralLandBuildingDto);
                                await _collateralLandBuildingRepository.InsertAsync(collateralLandDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    if (IsVehiclExist.Count > 0)
                    {
                        foreach (var vehicle in IsVehiclExist)
                        {
                            vehicle.Fk_ColateralID = result.Id;
                            var vehicles = ObjectMapper.Map<CollateralVehicle>(vehicle);
                            await _collateralVehicleRepository.DeleteAsync(vehicles);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        if (input.createCollateralVehicle.Count() > 0)
                        {
                            List<CreateCollateralVehicleDto> createCollateralVehicleDtos = input.createCollateralVehicle;
                            foreach (var createCollateralVehicleDto in createCollateralVehicleDtos)
                            {
                                createCollateralVehicleDto.Fk_ColateralID = result.Id;
                                var collateralVehicle = ObjectMapper.Map<CollateralVehicle>(createCollateralVehicleDto);
                                await _collateralVehicleRepository.InsertAsync(collateralVehicle);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if (input.createCollateralVehicle.Count() > 0)
                        {
                            List<CreateCollateralVehicleDto> createCollateralVehicleDtos = input.createCollateralVehicle;
                            foreach (var createCollateralVehicleDto in createCollateralVehicleDtos)
                            {
                                createCollateralVehicleDto.Fk_ColateralID = result.Id;
                                var collateralVehicle = ObjectMapper.Map<CollateralVehicle>(createCollateralVehicleDto);
                                await _collateralVehicleRepository.InsertAsync(collateralVehicle);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    if (IsTDRExist.Count > 0)
                    {
                        foreach (var TDR in IsTDRExist)
                        {
                            TDR.Fk_ColateralID = result.Id;
                            var TDRs = ObjectMapper.Map<CollateralTDR>(TDR);
                            await _collateralTDRRepository.DeleteAsync(TDRs);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        if (input.createCollateralTDR.Count() > 0)
                        {
                            List<CreateCollateralTDRDto> createCollateralTDRDtos = input.createCollateralTDR;
                            foreach (var createCollateralTDRDto in createCollateralTDRDtos)
                            {
                                createCollateralTDRDto.Fk_ColateralID = result.Id;
                                var collateralTDR = ObjectMapper.Map<CollateralTDR>(createCollateralTDRDto);
                                await _collateralTDRRepository.InsertAsync(collateralTDR);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if (input.createCollateralTDR.Count() > 0)
                        {
                            List<CreateCollateralTDRDto> createCollateralTDRDtos = input.createCollateralTDR;
                            foreach (var createCollateralTDRDto in createCollateralTDRDtos)
                            {
                                createCollateralTDRDto.Fk_ColateralID = result.Id;
                                var collateralTDR = ObjectMapper.Map<CollateralTDR>(createCollateralTDRDto);
                                await _collateralTDRRepository.InsertAsync(collateralTDR);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    if (IsGoldExist.Count > 0)
                    {
                        foreach (var gold in IsGoldExist)
                        {
                            gold.Fk_ColateralID = result.Id;
                            var golds = ObjectMapper.Map<CollateralGold>(gold);
                            await _collateralGoldRepository.DeleteAsync(golds);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        if (input.createCollateralGold.Count() > 0)
                        {
                            List<CreateCollateralGoldDto> createCollateralGoldDtos = input.createCollateralGold;
                            foreach (var createCollateralGoldDto in createCollateralGoldDtos)
                            {
                                createCollateralGoldDto.Fk_ColateralID = result.Id;
                                var collateralGoldDto = ObjectMapper.Map<CollateralGold>(createCollateralGoldDto);
                                await _collateralGoldRepository.InsertAsync(collateralGoldDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if (input.createCollateralGold.Count() > 0)
                        {
                            List<CreateCollateralGoldDto> createCollateralGoldDtos = input.createCollateralGold;
                            foreach (var createCollateralGoldDto in createCollateralGoldDtos)
                            {
                                createCollateralGoldDto.Fk_ColateralID = result.Id;
                                var collateralGoldDto = ObjectMapper.Map<CollateralGold>(createCollateralGoldDto);
                                await _collateralGoldRepository.InsertAsync(collateralGoldDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    if (IsFranchiseExist.Count > 0)
                    {
                        foreach (var franchise in IsFranchiseExist)
                        {
                            franchise.Fk_ColateralID = result.Id;
                            var franchises = ObjectMapper.Map<CollateralFranchise>(franchise);
                            await _collateralFranchiseRepository.DeleteAsync(franchises);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        if (input.createCollateralFranchise.Count() > 0)
                        {
                            List<CreateCollateralFranchiseDto> CreateCollateralFranchiseDtos = input.createCollateralFranchise;
                            foreach (var CreateCollateralFranchiseDto in CreateCollateralFranchiseDtos)
                            {
                                CreateCollateralFranchiseDto.Fk_ColateralID = result.Id;
                                var CollateralFranchiseDto = ObjectMapper.Map<CollateralFranchise>(CreateCollateralFranchiseDto);
                                await _collateralFranchiseRepository.InsertAsync(CollateralFranchiseDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if (input.createCollateralFranchise.Count() > 0)
                        {
                            List<CreateCollateralFranchiseDto> CreateCollateralFranchiseDtos = input.createCollateralFranchise;
                            foreach (var CreateCollateralFranchiseDto in CreateCollateralFranchiseDtos)
                            {
                                CreateCollateralFranchiseDto.Fk_ColateralID = result.Id;
                                var CollateralFranchiseDto = ObjectMapper.Map<CollateralFranchise>(CreateCollateralFranchiseDto);
                                await _collateralFranchiseRepository.InsertAsync(CollateralFranchiseDto);
                                CurrentUnitOfWork.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    var collateralDetail = ObjectMapper.Map<CollateralDetail>(input);
                    var result = await _collateralDetailRepository.InsertAsync(collateralDetail);
                    CurrentUnitOfWork.SaveChanges();

                    if (input.createCollateralLandBuilding.Count() > 0)
                    {
                        List<CreateCollateralLandBuildingDto> createCollateralLandBuildingDtos = input.createCollateralLandBuilding;
                        foreach (var createCollateralLandBuildingDto in createCollateralLandBuildingDtos)
                        {
                            createCollateralLandBuildingDto.Fk_ColateralID = result.Id;
                            var collateralLandDto = ObjectMapper.Map<CollateralLandBuilding>(createCollateralLandBuildingDto);
                            await _collateralLandBuildingRepository.InsertAsync(collateralLandDto);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    if (input.createCollateralVehicle.Count() > 0)
                    {
                        List<CreateCollateralVehicleDto> createCollateralVehicleDtos = input.createCollateralVehicle;
                        foreach (var createCollateralVehicleDto in createCollateralVehicleDtos)
                        {
                            createCollateralVehicleDto.Fk_ColateralID = result.Id;
                            var collateralVehicle = ObjectMapper.Map<CollateralVehicle>(createCollateralVehicleDto);
                            await _collateralVehicleRepository.InsertAsync(collateralVehicle);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    if (input.createCollateralTDR.Count() > 0)
                    {
                        List<CreateCollateralTDRDto> createCollateralTDRDtos = input.createCollateralTDR;
                        foreach (var createCollateralTDRDto in createCollateralTDRDtos)
                        {
                            createCollateralTDRDto.Fk_ColateralID = result.Id;
                            var collateralTDR = ObjectMapper.Map<CollateralTDR>(createCollateralTDRDto);
                            await _collateralTDRRepository.InsertAsync(collateralTDR);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                    if (input.createCollateralGold.Count() > 0)
                    {
                        List<CreateCollateralGoldDto> createCollateralGoldDtos = input.createCollateralGold;
                        foreach (var createCollateralGoldDto in createCollateralGoldDtos)
                        {
                            createCollateralGoldDto.Fk_ColateralID = result.Id;
                            var collateralGoldDto = ObjectMapper.Map<CollateralGold>(createCollateralGoldDto);
                            await _collateralGoldRepository.InsertAsync(collateralGoldDto);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    if (input.createCollateralFranchise.Count() > 0)
                    {
                        List<CreateCollateralFranchiseDto> createCollateralFranchiseDtos = input.createCollateralFranchise;
                        foreach (var createCollateralFranchiseDto in createCollateralFranchiseDtos)
                        {
                            createCollateralFranchiseDto.Fk_ColateralID = result.Id;
                            var collateralFranchiseDto = ObjectMapper.Map<CollateralFranchise>(createCollateralFranchiseDto);
                            await _collateralFranchiseRepository.InsertAsync(collateralFranchiseDto);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Collateral DETAILS", input.ApplicationId);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", collateralDetails));
            }
        }

        public async Task<CollateralDetailListDto> GetCollateralDetailById(int Id)
        {
            //CollateralTypeListDto collateral = new CollateralTypeListDto();
            try
            {

                var collateralDetail = await _collateralDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<CollateralDetailListDto>(collateralDetail);
                if (result != null)
                {
                    if (result.CollateralType == 2)
                    {
                        var LandBuilding = _collateralLandBuildingRepository.GetAllList(i => i.Fk_ColateralID == Id);
                        var collateralLandBuilding = ObjectMapper.Map<List<CollateralLandBuildingListDto>>(LandBuilding);
                        result.createCollateralLandBuilding = collateralLandBuilding;
                    }
                    else if (result.CollateralType == 3)
                    {
                        var vehicle = _collateralVehicleRepository.GetAllList(i => i.Fk_ColateralID == Id);
                        var collateralVehicle = ObjectMapper.Map<List<CollateralVehicleListDto>>(vehicle);
                        result.createCollateralVehicle = collateralVehicle;
                    }
                    else if (result.CollateralType == 4)
                    {
                        var TDR = _collateralTDRRepository.GetAllList(i => i.Fk_ColateralID == Id);
                        var collateralTDR = ObjectMapper.Map<List<CollateralTDRListDto>>(TDR);
                        result.createCollateralTDR = collateralTDR;
                    }
                    else if (result.CollateralType == 5)
                    {
                        var gold = _collateralGoldRepository.GetAllList(i => i.Fk_ColateralID == Id);
                        var collateralgold = ObjectMapper.Map<List<CollateralGoldListDto>>(gold);
                        result.createCollateralGold = collateralgold;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", collateralDetails));
            }
        }

        public async Task<string> UpdateCollateralDetail(UpdateCollateralDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var collateralDetail = _collateralDetailRepository.Get(input.Id);
                if (collateralDetail != null && collateralDetail.Id > 0)
                {
                    ObjectMapper.Map(input, collateralDetail);
                    await _collateralDetailRepository.UpdateAsync(collateralDetail);
                    CurrentUnitOfWork.SaveChanges();
                    if (input.updateCollateralLandBuilding.Count > 0)
                    {
                        foreach (var child in input.updateCollateralLandBuilding)
                        {
                            var LandBuilding = _collateralLandBuildingRepository.Get(child.Id);
                            ObjectMapper.Map(child, LandBuilding);
                            await _collateralLandBuildingRepository.UpdateAsync(LandBuilding);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    else if (input.updateCollateralVehicle.Count > 0)
                    {
                        foreach (var child in input.updateCollateralVehicle)
                        {
                            var vehicle = _collateralVehicleRepository.Get(child.Id);
                            ObjectMapper.Map(child, vehicle);
                            await _collateralVehicleRepository.UpdateAsync(vehicle);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    else if (input.updateCollateralTDR.Count > 0)
                    {
                        foreach (var child in input.updateCollateralTDR)
                        {
                            var TDR = _collateralTDRRepository.Get(child.Id);
                            ObjectMapper.Map(child, TDR);
                            await _collateralTDRRepository.UpdateAsync(TDR);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    else if (input.updateCollateralGold.Count > 0)
                    {
                        foreach (var child in input.updateCollateralGold)
                        {
                            var Gold = _collateralGoldRepository.Get(child.Id);
                            ObjectMapper.Map(child, Gold);
                            await _collateralGoldRepository.UpdateAsync(Gold);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", collateralDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", collateralDetails));
            }
        }

        public async Task<CollateralDetailListDto> GetCollateralDetailByApplicationId(int ApplicationId)
        {
            //CollateralTypeListDto collateral = new CollateralTypeListDto();
            try
            {

                var collateralDetail = _collateralDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var result = ObjectMapper.Map<CollateralDetailListDto>(collateralDetail);

                var initChat = (from objCollateralDetail in _collateralDetailRepository.GetAllList()
                                join collateralType in _collateralType.GetAllList() on objCollateralDetail.CollateralType equals collateralType.Id
                                where objCollateralDetail.ApplicationId == ApplicationId
                                select new
                                {
                                    objCollateralDetail,
                                    collateralTypeName = collateralType.Name
                                }).FirstOrDefault();

                if (initChat != null)
                {
                    result.CollateralTypeName = initChat.collateralTypeName;
                }

                if (result != null)
                {
                    //--------------------------Land Building--------------------------------//
                    var LandBuilding = _collateralLandBuildingRepository.GetAllList(i => i.Fk_ColateralID == result.Id);
                    if (LandBuilding != null)
                    {
                        var collateralLandBuildings = ObjectMapper.Map<List<CollateralLandBuildingListDto>>(LandBuilding);

                        foreach (CollateralLandBuildingListDto collateralLandBuilding in collateralLandBuildings)
                        {
                            var ownership = _collateralOwnershipDto.Get(collateralLandBuilding.CollateralOwnership);
                            if (ownership != null)
                            {
                                collateralLandBuilding.OwnershipName = ownership.Name;
                            }
                            var PropertyType = _propertyTyperepo.Get(collateralLandBuilding.PropertyType);
                            if (PropertyType != null)
                            {
                                collateralLandBuilding.propertyTypeName = PropertyType.Name;
                            }
                        }
                        result.createCollateralLandBuilding = collateralLandBuildings;

                    }
                    //--------------------------Vehicle--------------------------------//

                    var vehicle = _collateralVehicleRepository.GetAllList(i => i.Fk_ColateralID == result.Id);
                    if (vehicle != null)
                    {
                        var collateralVehicles = ObjectMapper.Map<List<CollateralVehicleListDto>>(vehicle);

                        foreach (CollateralVehicleListDto collateralVehicle in collateralVehicles)
                        {
                            var ownership = _collateralOwnershipDto.Get(collateralVehicle.CollateralOwnership);
                            if (ownership != null)
                            {
                                collateralVehicle.VehicleOwnerName = ownership.Name;
                            }
                            //var relation = _relationshipWithApplicantRepository.GetAllList().Where(x => x.Id == collateralVehicle.RelationWithApplicant).SingleOrDefault();
                            //if (relation != null)
                            //{
                            //    collateralVehicle.RelationWithApplicantName = relation.Name;
                            //}
                        }
                        result.createCollateralVehicle = collateralVehicles;

                    }

                    //--------------------------TDR--------------------------------//


                    var TDR = _collateralTDRRepository.GetAllList(i => i.Fk_ColateralID == result.Id);

                    if (TDR != null)
                    {
                        var collateralTDRs = ObjectMapper.Map<List<CollateralTDRListDto>>(TDR);

                        foreach (CollateralTDRListDto collateralTDR in collateralTDRs)
                        {
                            var ownership = _ownershipStatusRepository.Get(collateralTDR.CollateralOwnership);
                            if (ownership != null)
                            {
                                collateralTDR.TDrOwnerName = ownership.Name;
                            }
                            //var relation = _relationshipWithApplicantRepository.GetAllList().Where(x => x.Id == collateralTDR.RelationWithApplicant).SingleOrDefault();
                            //if (relation != null)
                            //{
                            //    collateralTDR.RelationWithApplicantName = relation.Name;
                            //}
                        }
                        result.createCollateralTDR = collateralTDRs;

                    }

                    //--------------------------Gold--------------------------------//



                    var gold = _collateralGoldRepository.GetAllList(i => i.Fk_ColateralID == result.Id);

                    if (gold != null)
                    {
                        var collateralgolds = ObjectMapper.Map<List<CollateralGoldListDto>>(gold);

                        foreach (CollateralGoldListDto collateralgold in collateralgolds)
                        {
                            var ownership = _collateralOwnershipDto.Get(collateralgold.CollateralOwnership);
                            if (ownership != null)
                            {
                                collateralgold.CollateralOwnershipName = ownership.Name;
                            }
                            //var relation = _relationshipWithApplicantRepository.GetAllList().Where(x => x.Id == collateralgold.RelationWithApplicant).SingleOrDefault();
                            //if (relation != null)
                            //{
                            //    collateralgold.RelationWithApplicantName = relation.Name;
                            //}
                        }
                        result.createCollateralGold = collateralgolds;

                    }

                    //--------------------------Franchise--------------------------------//


                    var Franchise = _collateralFranchiseRepository.GetAllList(i => i.Fk_ColateralID == result.Id);

                    if (Franchise != null)
                    {
                        var collateralFranchises = ObjectMapper.Map<List<CollateralFranchiseListDto>>(Franchise);

                        foreach (CollateralFranchiseListDto collateralFranchise in collateralFranchises)
                        {
                            var ownership = _collateralOwnershipDto.Get(collateralFranchise.CollateralOwnership);
                            if(ownership!=null)
                            {
                                collateralFranchise.OwnershipName = ownership.Name;
                            }
                            //var relation = _relationshipWithApplicantRepository.GetAllList().Where(x => x.Id == collateralFranchise.RelationWithApplicant).SingleOrDefault();
                            //if (relation != null)
                            //{
                            //    collateralFranchise.RelationWithApplicantName = relation.Name;
                            //}
                        }
                        result.createCollateralFranchise = collateralFranchises;

                    }

                    //var FranchiseList = (from FranchiseObj in _collateralFranchiseRepository.GetAllList()
                    //                     join ownership in _ownershipStatusRepository.GetAllList() on FranchiseObj.CollateralOwnership equals ownership.Id
                    //                     where FranchiseObj.Fk_ColateralID == result.Id
                    //                     select new
                    //                     {
                    //                         FranchiseId = FranchiseObj.Id,
                    //                         OwnershipName = ownership.Name,
                    //                     }).ToList();

                    //List<CollateralFranchiseListDto> CollateralFranchiseList = new List<CollateralFranchiseListDto>();
                    //if (FranchiseList != null)
                    //{
                    //    foreach (CollateralFranchiseListDto collateralFranch in result.createCollateralFranchise)
                    //    {
                    //        foreach (var objFranchise in FranchiseList)
                    //        {
                    //            if (collateralFranch.Id == objFranchise.FranchiseId)
                    //            {
                    //                collateralFranch.OwnershipName = objFranchise.OwnershipName;
                    //                CollateralFranchiseList.Add(collateralFranch);
                    //                break;
                    //            }

                    //        }
                    //    }
                    //}





                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", collateralDetails));
            }
        }

        public bool CheckCollateralDetailByApplicationId(int ApplicationId)
        {
            //CollateralTypeListDto collateral = new CollateralTypeListDto();
            try
            {
                var collateralDetail = _collateralDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (collateralDetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", collateralDetails));
            }
        }
    }
}
