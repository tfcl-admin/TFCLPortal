using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Klasses.Dto;

namespace TFCLPortal.Klasses
{
  public  interface IKlassAppService : IApplicationService
    {

        KlassListDto GetklassById(int Id);
        Task CreateKlass(CreateKlassDto input);
        List<KlassListDto> GetKlassList();

    }
}
