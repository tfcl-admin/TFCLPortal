using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Companies.Dto;
using TFCLPortal.Company.Dto;

namespace TFCLPortal.Companies
{
  public  interface ICompanyDetailAppService : IApplicationService
    {

        CompanyDetailListDto GetCompanyDetailById(int Id);
        Task CreateCompanyDetail(CreateCompanyDetailDto input);
        Task<string> UpdateCompanyDetail(UpdateCompanyDetailDto input);
        List<CompanyDetailListDto> GetCompanyListDetail();


    }
}
