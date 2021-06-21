using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;

namespace TFCLPortal.Web.Host.Models
{
    public class ApplicationState
    {
        public int ApplicationId { get; set; }
        public string AppState { get; set; }
        public string Comments { get; set; }
     
    }

    public class ApplicationStatesModel : ApplicationListDto
    {
        public List<ApplicationState> applicationState { get; set; }

    }

}
