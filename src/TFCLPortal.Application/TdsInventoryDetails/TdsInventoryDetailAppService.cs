using Abp.Domain.Repositories;
using Abp.UI;
using Abp.UI.Inputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.TdsInventoryDetailChilds;
using TFCLPortal.TdsInventoryDetails.Dto;
using TFCLPortal.TdsInventoryDetailGrandChilds;
using TFCLPortal.TdsInventoryDetails;
using TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances;
using TFCLPortal.DynamicDropdowns.InventoryEntrySources;

namespace TFCLPortal.TdsInventoryDetails
{
    public class TdsInventoryDetailAppService : TFCLPortalAppServiceBase, ITdsInventoryDetailAppService
    {
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<TdsInventoryDetail> _TdsInventoryDetailRepository;
        private readonly IRepository<TdsInventoryDetailChild> _TdsInventoryDetailChildRepository;
        private readonly IRepository<TdsInventoryDetailGrandChild> _TdsInventoryDetailGrandChildRepository;
        private readonly IRepository<InventoryRecordMaintenance> _InventoryRecordMaintenanceRepository;
        private readonly IRepository<InventoryEntrySource> _InventoryEntrySourceRepository;
        public TdsInventoryDetailAppService(IRepository<TdsInventoryDetail> TdsInventoryDetailRepository, IRepository<InventoryEntrySource> InventoryEntrySourceRepository, IRepository<InventoryRecordMaintenance> InventoryRecordMaintenanceRepository,   IApiCallLogAppService apiCallLogAppService, IRepository<TdsInventoryDetailGrandChild> TdsInventoryDetailGrandChildRepository, IRepository<TdsInventoryDetailChild> TdsInventoryDetailChildRepository)
        {
            _TdsInventoryDetailRepository = TdsInventoryDetailRepository;
            _TdsInventoryDetailChildRepository = TdsInventoryDetailChildRepository;
            _InventoryEntrySourceRepository = InventoryEntrySourceRepository;
            _TdsInventoryDetailGrandChildRepository = TdsInventoryDetailGrandChildRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _InventoryRecordMaintenanceRepository = InventoryRecordMaintenanceRepository;
        }

        public async Task<string> CreateTdsInventoryDetails(CreateTdsInventoryDetailDto input)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateTdsInventoryDetails";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _TdsInventoryDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (IsExist != null)
                {
                    var TdsInventoryDetail = ObjectMapper.Map<TdsInventoryDetail>(IsExist);
                    var IsExistTdsInventoryDetailChild = _TdsInventoryDetailChildRepository.GetAllList(x => x.Fk_TdsInventoryDetail == TdsInventoryDetail.Id);


                    if (IsExistTdsInventoryDetailChild != null)
                    {
                        var TdsInventoryDetailChilds = ObjectMapper.Map<List<TdsInventoryDetailChild>>(IsExistTdsInventoryDetailChild);
                        foreach (var TdsInventoryDetailChild in TdsInventoryDetailChilds)
                        {
                            var IsExistTdsInventoryDetailGrandChild = _TdsInventoryDetailGrandChildRepository.GetAllList(x => x.Fk_TdsInventoryDetailChild == TdsInventoryDetailChild.Id);
                            if (IsExistTdsInventoryDetailGrandChild != null)
                            {
                                var TdsInventoryDetailGrandChilds = ObjectMapper.Map<List<TdsInventoryDetailGrandChild>>(IsExistTdsInventoryDetailGrandChild);
                                foreach (var TdsInventoryDetailGrandChild in TdsInventoryDetailGrandChilds)
                                {

                                    await _TdsInventoryDetailGrandChildRepository.DeleteAsync(TdsInventoryDetailGrandChild);
                                    CurrentUnitOfWork.SaveChanges();
                                }

                            }
                            await _TdsInventoryDetailChildRepository.DeleteAsync(TdsInventoryDetailChild);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                    await _TdsInventoryDetailRepository.DeleteAsync(TdsInventoryDetail);
                    CurrentUnitOfWork.SaveChanges();


                    var TdsInventoryDetailInput = ObjectMapper.Map<TdsInventoryDetail>(input);

                    var result = await _TdsInventoryDetailRepository.InsertAsync(TdsInventoryDetailInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var TdsInventoryDetailChild in input.TdsInventoryDetailChilds)
                    {

                        TdsInventoryDetailChild.Fk_TdsInventoryDetail = result.Id;
                        var TdsInventoryDetailChildDetail = ObjectMapper.Map<TdsInventoryDetailChild>(TdsInventoryDetailChild);

                        var resultChild = await _TdsInventoryDetailChildRepository.InsertAsync(TdsInventoryDetailChildDetail);
                        CurrentUnitOfWork.SaveChanges();

                        foreach (var TdsInventoryDetailGrandChild in TdsInventoryDetailChild.TdsInventoryDetailGrandChilds)
                        {
                            TdsInventoryDetailGrandChild.Fk_TdsInventoryDetailChild = resultChild.Id;
                            var TdsInventoryDetailGrandChildDetail = ObjectMapper.Map<TdsInventoryDetailGrandChild>(TdsInventoryDetailGrandChild);
                            await _TdsInventoryDetailGrandChildRepository.InsertAsync(TdsInventoryDetailGrandChildDetail);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                }
                else
                {

                    var TdsInventoryDetailInput = ObjectMapper.Map<TdsInventoryDetail>(input);

                    var result = await _TdsInventoryDetailRepository.InsertAsync(TdsInventoryDetailInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var TdsInventoryDetailChild in input.TdsInventoryDetailChilds)
                    {

                        TdsInventoryDetailChild.Fk_TdsInventoryDetail = result.Id;
                        var TdsInventoryDetailChildDetail = ObjectMapper.Map<TdsInventoryDetailChild>(TdsInventoryDetailChild);
                        var resultChild = await _TdsInventoryDetailChildRepository.InsertAsync(TdsInventoryDetailChildDetail);
                        CurrentUnitOfWork.SaveChanges();

                        foreach (var TdsInventoryDetailGrandChild in TdsInventoryDetailChild.TdsInventoryDetailGrandChilds)
                        {
                            TdsInventoryDetailGrandChild.Fk_TdsInventoryDetailChild = resultChild.Id;
                            var TdsInventoryDetailGrandChildDetail = ObjectMapper.Map<TdsInventoryDetailGrandChild>(TdsInventoryDetailGrandChild);
                            await _TdsInventoryDetailGrandChildRepository.InsertAsync(TdsInventoryDetailGrandChildDetail);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }

                if (response != "")
                {
                    return response;
                }
                else
                {
                    return "Success";
                }
            }
            catch (Exception)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "TDS Inventory Details"));
            }
        }

        public async Task<TdsInventoryDetailListDto> GetTdsInventoryDetailDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _TdsInventoryDetailRepository.GetAllList().Where(x => x.ApplicationId == Id).SingleOrDefault();
                if (IsExist != null)
                {
                    var TdsInventoryDetail = ObjectMapper.Map<TdsInventoryDetailListDto>(IsExist);

                    var IsExistTdsInventoryDetailChild = _TdsInventoryDetailChildRepository.GetAllList().Where(x => x.Fk_TdsInventoryDetail == TdsInventoryDetail.Id).ToList();
                    if (IsExistTdsInventoryDetailChild.Count > 0)
                    {
                        var TdsInventoryDetailChilds = ObjectMapper.Map<List<TdsInventoryDetailChildListDto>>(IsExistTdsInventoryDetailChild);

                        foreach (var TdsInventoryDetailChild in TdsInventoryDetailChilds)
                        {

                            if (TdsInventoryDetailChild.InventoryRecordMaintenance != 0)
                            {
                                var inventory = _InventoryRecordMaintenanceRepository.Get(TdsInventoryDetailChild.InventoryRecordMaintenance);
                                TdsInventoryDetailChild.InventoryRecordMaintenanceName = inventory.Name;
                            }
                            if (TdsInventoryDetailChild.InventoryEntrySource != 0)
                            {
                                var inventory = _InventoryEntrySourceRepository.Get(TdsInventoryDetailChild.InventoryEntrySource);
                                TdsInventoryDetailChild.InventoryEntrySourceName = inventory.Name;
                            }

                            var IsExistTdsInventoryDetailGrandChild = _TdsInventoryDetailGrandChildRepository.GetAllList().Where(x => x.Fk_TdsInventoryDetailChild == TdsInventoryDetailChild.Id).ToList();
                            if (IsExistTdsInventoryDetailGrandChild.Count > 0)
                            {
                                var TdsInventoryDetailGrandChilds = ObjectMapper.Map<List<TdsInventoryDetailGrandChildListDto>>(IsExistTdsInventoryDetailGrandChild);

                                TdsInventoryDetailChild.TdsInventoryDetailGrandChilds = TdsInventoryDetailGrandChilds;
                            }

                        }

                        TdsInventoryDetail.TdsInventoryDetailChilds = TdsInventoryDetailChilds;
                    }

                    return TdsInventoryDetail;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "TDS Inventory Details"));
            }
        }
        public bool CheckTdsInventoryDetailDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _TdsInventoryDetailRepository.GetAllList().Where(x => x.ApplicationId == Id).SingleOrDefault();
                if (IsExist != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "TDS Inventory Details"));
            }
        }
    }
}
