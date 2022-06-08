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
using TFCLPortal.Targets.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.Users;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.Branches;

namespace TFCLPortal.Targets
{
    public class TargetAppService : TFCLPortalAppServiceBase, ITargetAppService
    {
        private readonly IRepository<Target, Int32> _TargetRepository;
        private string Targets = "Target";
        private readonly IProductTypeAppService _productTypeAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly IUserAppService _userAppService;
        public TargetAppService(IBranchDetailAppService branchDetailAppService, IProductTypeAppService productTypeAppService, IUserAppService userAppService, IRepository<Target, Int32> TargetRepository)
        {
            _branchDetailAppService = branchDetailAppService;
            _productTypeAppService = productTypeAppService;
            _userAppService = userAppService;
            _TargetRepository = TargetRepository;
        }

        public async Task<string> CreateTarget(CreateTargetDto input)
        {
            string ResponseString = "";

            try
            {

                var Target = ObjectMapper.Map<Target>(input);
                await _TargetRepository.InsertAsync(Target);
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", Targets));
            }
        }

        public TargetListDto GetTargetById(int Id)
        {
            try
            {
                var Target = _TargetRepository.Get(Id);

                return ObjectMapper.Map<TargetListDto>(Target);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Targets));
            }
        }

        public async Task<string> UpdateTarget(UpdateTargetDto input)
        {
            string ResponseString = "";
            try
            {
                var Target = _TargetRepository.Get(input.Id);
                if (Target != null && Target.Id > 0)
                {
                    ObjectMapper.Map(input, Target);
                    await _TargetRepository.UpdateAsync(Target);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", Targets));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Targets));
            }
        }

        public List<TargetListDto> GetAllAlocatedTarget()
        {
            try
            {
                var Targets = _TargetRepository.GetAllList();
                var ReturnTargets = ObjectMapper.Map<List<TargetListDto>>(Targets);

                var users = _userAppService.GetAllUsers();
                var products = _productTypeAppService.GetAllList();
                var branches = _branchDetailAppService.GetBranchListDetail();

                foreach (var target in ReturnTargets)
                {
                    if (target.Fk_SdeId != 0)
                    {
                        var sde = users.Where(x => x.Id == target.Fk_SdeId).FirstOrDefault();
                        target.SdeName = sde.FullName;
                    }
                    if (target.Fk_ProductTypeId != 0)
                    {
                        var product = getProducts().Where(x => x.Id == target.Fk_ProductTypeId).FirstOrDefault();
                        target.ProductName = product.Name;
                    }
                    if (target.Fk_BranchId != 0)
                    {
                        var branch = branches.Where(x => x.Id == target.Fk_BranchId).FirstOrDefault();
                        target.BranchName = branch.BranchCode;
                    }
                    target.MonthName = getMonth(target.Month);
                }


                return ReturnTargets;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Targets));
            }
        }

        public string getMonth(int number)
        {
            switch (number)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "";
            }

        }

        public List<TargetProducts> getProducts()
        {
            List<TargetProducts> tp = new List<TargetProducts>();

            tp.Add(new TargetProducts { Id = 1, Name = "TALEEM SCHOOL SARMAYA / TALEEM SCHOOL ASASAH" });
            tp.Add(new TargetProducts { Id = 2, Name = "TALEEM DOST SAHULAT" });
            tp.Add(new TargetProducts { Id = 3, Name = "TALEEM JARI SAHULAT" });

            return tp;

        }

    }

    public class TargetProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
