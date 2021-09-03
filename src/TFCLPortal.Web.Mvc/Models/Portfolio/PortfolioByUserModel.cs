using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaggedPortfolios;

namespace TFCLPortal.Web.Models.Portfolio
{
    public class PortfolioByUserModel
    {
        public List<Applicationz> UserApplications { get; set; }
        public List<ApplicationListDto> UserTaggedApplications { get; set; }
    }
}
