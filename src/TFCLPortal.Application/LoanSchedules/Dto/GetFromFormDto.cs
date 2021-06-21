using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.LoanSchedules.Dto
{

    public class GetFromFormDto
    {

        public int ApplicationId { get; set; }
        public string ScheduleNo { get; set; }
        public string RevisionNo { get; set; }
        public DateTime RevisionDate { get; set; }
        public string ScheduleType { get; set; }
        public DateTime DisbursmentDate { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime LastInstallmentDate { get; set; }
        public int GraceDays { get; set; }
        public string IRR { get; set; }
        public string InstallmentAmount { get; set; }
        public string YearlyMarkup { get; set; }
        public string PerDayMarkup { get; set; }

        //New
        public int BranchManagerId { get; set; }
        public string IRR_Full { get; set; }
        public int SdeId { get; set; }
        public string BranchName { get; set; }
        public string Markup { get; set; }
        public string LoanAmount { get; set; }
        public string Tenure { get; set; }
        public List<tranchList> listForTranches { get; set; }

        public bool isDeferrment{ get; set; }
        public DateTime DefermentStartDate { get; set; }
        public int DefermentMonths { get; set; }
        public DateTime DefermentEndDate { get; set; }

    }

    public class tranchList
    {
        public int tranchId { get; set; }
        public DateTime StartDate { get; set; }
        public string Amount { get; set; }
        public double Irr { get; set; }
        public int tranchTenure { get; set; }
        public double tranchInstallment { get; set; }
        public double DailyMarkup { get; set; }
    }

    public class signatories
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
