using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.StudentDetails
{
    [Table("StudentDetail")]
    public class StudentDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string StudentName { get; set; }
        public string ParentName { get; set; }
        public string CNIC { get; set; }
        public DateTime? CNICExpiry { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Gender { get; set; }
        public string Age { get; set; }
        public string RelationWithClient { get; set; }
        public int MaritalStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public string EIName { get; set; }
        public string StudentID { get; set; }
        public string EnrolledDegree { get; set; }
        public string Others { get; set; }
        public string FinalSemester { get; set; }
        public string LastSemester { get; set; }

        public string FeeRequiredForSemesterNo { get; set; }
        public string PhoneNumber { get; set; }

    }
}