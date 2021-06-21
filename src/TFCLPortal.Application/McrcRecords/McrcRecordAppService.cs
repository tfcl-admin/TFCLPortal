using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.McrcRecords.Dto;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.McrcRecords
{
    public class McrcRecordAppService : TFCLPortalAppServiceBase, IMcrcRecordAppService
    {
        private readonly IRepository<McrcRecord, Int32> _McrcRecord;
        private readonly IRepository<Applicationz, Int32> _applicationz;
        private readonly ICustomRepository _customRepository;
        private string McrcRecordDetails = "Branch Credit Committee Detail";

        public McrcRecordAppService(
            IRepository<McrcRecord, Int32> McrcRecord,
            IRepository<Applicationz, Int32> applicationz,
             ICustomRepository customRepository
            )
        {
            _McrcRecord = McrcRecord;
            _applicationz = applicationz;
            _customRepository = customRepository;
        }
        public int CreateMcrcRecordDetail(CreateMcrcRecordDto input)
        {
            try
            {
                var McrcRecordDetail = ObjectMapper.Map<McrcRecord>(input);
                var creditCommetee = _McrcRecord.Insert(McrcRecordDetail);
                  CurrentUnitOfWork.SaveChanges();
                if (creditCommetee.Id > 0)
                {
                    return creditCommetee.Id;
                }
                else
                {
                    throw  new UserFriendlyException(L("CreateMethodError{0}", McrcRecordDetails));
                }
                
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", McrcRecordDetails));
            }
        }

        public McrcRecordListDto GetMcrcRecordListByApplicationId(int ApplicationId)
        {
            try
            {
                var McrcRecordDetail = _McrcRecord.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
               
                return ObjectMapper.Map<McrcRecordListDto>(McrcRecordDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcRecordDetails));
            }
        }

        public List<McrcRecordListDto> GetMcrcRecordList()
        {
            try
            {
                var McrcRecordDetail = _McrcRecord.GetAllList().OrderByDescending(x=>x.Id);

                return ObjectMapper.Map<List<McrcRecordListDto>>(McrcRecordDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcRecordDetails));
            }
        }

        public async Task<List<ApplicationDto>> GetMcrcRecordListByScreenCode(string applicationState, int? branchId, bool showAll = false, bool IsAdmin = false)
        {
            try
            {
                return _customRepository.GetAllApplicationList(applicationState, (int)branchId, showAll, IsAdmin);
                //var McrcRecordDetail = _applicationz.GetAllList(x => x.ScreenStatus == "BCC");

                //return ObjectMapper.Map<List<ApplicationListDto>>(McrcRecordDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcRecordDetails));
            }
        }

        public McrcRecordListDto GetMcrcRecordListDetailById(int Id)
        {
            try
            {
                var McrcRecordDetail =  _McrcRecord.GetAllList().Where(x=>x.Id==Id).FirstOrDefault();

                return ObjectMapper.Map<McrcRecordListDto>(McrcRecordDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcRecordDetails));
            }
        }


       
        public List<McrcRecordListDto> GetMcrcRecordListSDEUserId(int SDEUserId)
        {
            try
            {

                List<McrcRecord> list = new List<McrcRecord>();


                var McrcRecordDetail = _McrcRecord.GetAllList().Where(x => x.User1Id == SDEUserId || x.User2Id == SDEUserId || x.User3Id == SDEUserId || x.User4Id == SDEUserId || x.User5Id == SDEUserId).ToList();

                //foreach (var mcrc in McrcRecordDetail)
                //{
                //    McrcRecord obj = new McrcRecord();
                //    if (mcrc.Applications.ScreenStatus != "BCC Approved")
                //    {
                //        obj = mcrc;
                //        list.Add(obj);
                //    }
                   
                
                //}

                return ObjectMapper.Map<List<McrcRecordListDto>>(McrcRecordDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", McrcRecordDetails));
            }
        }

        public async Task<string> UpdateMcrcRecord(UpdateMcrcRecordDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var McrcRecordDetail = _McrcRecord.Get(input.Id);
                if (McrcRecordDetail != null && McrcRecordDetail.Id > 0)
                {
                    ObjectMapper.Map(input, McrcRecordDetail);
                    await _McrcRecord.UpdateAsync(McrcRecordDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", McrcRecordDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", McrcRecordDetails));
            }
        }
    }
}
