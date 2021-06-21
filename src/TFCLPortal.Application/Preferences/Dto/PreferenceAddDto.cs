using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Preferences.Dto
{
    [AutoMapTo(typeof(Preference))]
    public class PreferenceAddDto
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string PresentAddress { get; set; }
        public string KnowApplicantSince { get; set; }
        public string Comments { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string CommentsBox { get; set; }

        //New
        public int? RelationshipWithApplicant { get; set; }
        public string RelationshipWithApplicantOthers { get; set; }
        public string BusinessName { get; set; }

    }
}
