using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.EmploymentDetails.Dto
{
    [AutoMapTo(typeof(EmploymentDetail))]
    public class CreateEmploymentDetailInput
    {
        public List<EditEmploymentDetailinput> CreateEmploymentInput { get; set; }
    }
}
