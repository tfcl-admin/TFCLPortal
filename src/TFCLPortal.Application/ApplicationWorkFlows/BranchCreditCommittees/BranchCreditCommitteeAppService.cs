using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees.Dto;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees
{
    public class BranchCreditCommitteeAppService : TFCLPortalAppServiceBase, IBranchCreditCommitteeAppService
    {
        private readonly IRepository<BranchCreditCommittee, Int32> _branchCreditCommittee;
        private readonly IRepository<Applicationz, Int32> _applicationz;
        private readonly ICustomRepository _customRepository;
        private string BranchCreditCommitteeDetails = "Branch Credit Committee Detail";

        public BranchCreditCommitteeAppService(
            IRepository<BranchCreditCommittee, Int32> branchCreditCommittee,
            IRepository<Applicationz, Int32> applicationz,
             ICustomRepository customRepository
            )
        {
            _branchCreditCommittee = branchCreditCommittee;
            _applicationz = applicationz;
            _customRepository = customRepository;
        }
        public int CreateBranchCreditCommitteeDetail(CreateBranchCreditCommitteeDto input)
        {
            try
            {
                var BranchCreditCommitteeDetail = ObjectMapper.Map<BranchCreditCommittee>(input);
                var creditCommetee = _branchCreditCommittee.Insert(BranchCreditCommitteeDetail);
                  CurrentUnitOfWork.SaveChanges();
                if (creditCommetee.Id > 0)
                {
                    return creditCommetee.Id;
                }
                else
                {
                    throw  new UserFriendlyException(L("CreateMethodError{0}", BranchCreditCommitteeDetails));
                }
                
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", BranchCreditCommitteeDetails));
            }
        }

        public BranchCreditCommitteeListDto GetBranchCreditCommitteeListByApplicationId(int ApplicationId)
        {
            try
            {
                var BranchCreditCommitteeDetail = _branchCreditCommittee.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
               
                return ObjectMapper.Map<BranchCreditCommitteeListDto>(BranchCreditCommitteeDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BranchCreditCommitteeDetails));
            }
        }

        public List<BranchCreditCommitteeListDto> GetBranchCreditCommitteeList()
        {
            try
            {
                var BranchCreditCommitteeDetail = _branchCreditCommittee.GetAllIncluding(x=>x.Applications,b=>b.SDE1_User,c=>c.SDE2_User).OrderByDescending(x=>x.Id);

                return ObjectMapper.Map<List<BranchCreditCommitteeListDto>>(BranchCreditCommitteeDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BranchCreditCommitteeDetails));
            }
        }

        public async Task<List<ApplicationDto>> GetBranchCreditCommitteeListByScreenCode(string applicationState, int? branchId, bool showAll = false, bool IsAdmin = false)
        {
            try
            {
                return _customRepository.GetAllApplicationList(applicationState, (int)branchId, showAll, IsAdmin);
                //var BranchCreditCommitteeDetail = _applicationz.GetAllList(x => x.ScreenStatus == "BCC");

                //return ObjectMapper.Map<List<ApplicationListDto>>(BranchCreditCommitteeDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BranchCreditCommitteeDetails));
            }
        }

        public BranchCreditCommitteeListDto GetBranchCreditCommitteeListDetailById(int Id)
        {
            try
            {
                var BranchCreditCommitteeDetail =  _branchCreditCommittee.GetAllIncluding(x=>x.Applications,b=>b.SDE1_User,c=>c.SDE2_User).Where(x=>x.Id==Id).FirstOrDefault();

                return ObjectMapper.Map<BranchCreditCommitteeListDto>(BranchCreditCommitteeDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BranchCreditCommitteeDetails));
            }
        }


       
        public List<BranchCreditCommitteeListDto> GetBranchCreditCommitteeListSDEUserId(int SDEUserId)
        {
            try
            {

                List<BranchCreditCommittee> list = new List<BranchCreditCommittee>();


                var BranchCreditCommitteeDetail = _branchCreditCommittee.GetAllIncluding(x => x.Applications, b => b.SDE1_User, c => c.SDE2_User).Where(x => x.SDE1_UserId == SDEUserId ||  x.SDE2_UserId == SDEUserId).ToList();

                foreach (var BCC in BranchCreditCommitteeDetail)
                {
                    BranchCreditCommittee obj = new BranchCreditCommittee();
                    if (BCC.Applications.ScreenStatus != "BCC Approved")
                    {
                        obj = BCC;
                        list.Add(obj);
                    }
                   
                
                }

                return ObjectMapper.Map<List<BranchCreditCommitteeListDto>>(list);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", BranchCreditCommitteeDetails));
            }
        }

        public async Task<string> UpdateBranchCreditCommittee(UpdateBranchCreditCommitteeDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var BranchCreditCommitteeDetail = _branchCreditCommittee.Get(input.Id);
                if (BranchCreditCommitteeDetail != null && BranchCreditCommitteeDetail.Id > 0)
                {
                    ObjectMapper.Map(input, BranchCreditCommitteeDetail);
                    await _branchCreditCommittee.UpdateAsync(BranchCreditCommitteeDetail);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString;
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", BranchCreditCommitteeDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", BranchCreditCommitteeDetails));
            }
        }
    }
}
