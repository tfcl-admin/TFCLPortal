using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Branches.Dto;

namespace TFCLPortal.Branches
{

    public class BranchDetailAppService : TFCLPortalAppServiceBase, IBranchDetailAppService
    {
        private readonly IRepository<Branch, Int32> _branchRepository;
        private string branch = "Branch Detail";

        public BranchDetailAppService(IRepository<Branch, Int32> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task CreateBranchDetail(CreateBranchDetail input)
        {
            try
            {
                var branchDetail = ObjectMapper.Map<Branch>(input);
                await _branchRepository.InsertAsync(branchDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", branch));
            }
        }

        public BranchDetailList GetBranchDetailById(int Id)
        {
            try
            {
                var branchDetail = _branchRepository.Get(Id);

                return ObjectMapper.Map<BranchDetailList>(branchDetail);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }

        public async Task<string> UpdateBranchDetail(UpdateBranchDetail input)
        {
            string ResponseString = "";
            try
            {
                var branchDetail = _branchRepository.Get(input.Id);
                if (branchDetail != null && branchDetail.Id > 0)
                {
                    ObjectMapper.Map(input, branchDetail);
                    await _branchRepository.UpdateAsync(branchDetail);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", branch));
            }
            return ResponseString;
        }
        public List<BranchDetailList> GetBranchListDetail()
        {
            try
            {
                var companyDetail = _branchRepository.GetAllIncluding(x=>x.Comapny);

                return ObjectMapper.Map<List<BranchDetailList>>(companyDetail);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", branch));
            }
        }
    }
}
