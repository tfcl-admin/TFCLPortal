using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchools;

namespace TFCLPortal.PurchaseDetails.Dto
{
    [AutoMapTo(typeof(PurchaseDetailChild))]
    public class CreatePurchaseDetailChildDto
    {
        public int Fk_PurchaseDetailId { get; set; }

        public string BusinessName { get; set; }

        //SeasonalPurchases
        public DateTime AnalysisMonth { get; set; }

        public DateTime? Month1 { get; set; }
        public string Month1Purchases { get; set; }

        public DateTime? Month2 { get; set; }
        public string Month2Purchases { get; set; }

        public DateTime? Month3 { get; set; }
        public string Month3Purchases { get; set; }

        public DateTime? Month4 { get; set; }
        public string Month4Purchases { get; set; }

        public DateTime? Month5 { get; set; }
        public string Month5Purchases { get; set; }

        public DateTime? Month6 { get; set; }
        public string Month6Purchases { get; set; }

        public DateTime? Month7 { get; set; }
        public string Month7Purchases { get; set; }

        public DateTime? Month8 { get; set; }
        public string Month8Purchases { get; set; }

        public DateTime? Month9 { get; set; }
        public string Month9Purchases { get; set; }

        public DateTime? Month10 { get; set; }
        public string Month10Purchases { get; set; }

        public DateTime? Month11 { get; set; }
        public string Month11Purchases { get; set; }

        public DateTime? Month12 { get; set; }
        public string Month12Purchases { get; set; }

        public string PerMonthAvgPurchase { get; set; }

        //ProductWisePurchases
        public string TotalMonthlyPurchase { get; set; }


        //TranchePurchases
        public string DailyPurchasesAmount { get; set; }
        public string DailyPurchaseFrequency { get; set; }
        public string DailyTotal { get; set; }

        public string WeeklyPurchasesAmount { get; set; }
        public string WeeklyPurchaseFrequency { get; set; }
        public string WeeklyTotal { get; set; }

        public string FortnightlyPurchasesAmount { get; set; }
        public string FortnightlyPurchaseFrequency { get; set; }
        public string FortnightlyTotal { get; set; }

        public string MonthlyPurchasesAmount { get; set; }
        public string MonthlyPurchaseFrequency { get; set; }
        public string MonthlyTotal { get; set; }

        public string QuaterlyPurchasesAmount { get; set; }
        public string QuaterlyPurchaseFrequency { get; set; }
        public string QuaterlyTotal { get; set; }

        public string SemiAnnuallyPurchasesAmount { get; set; }
        public string SemiAnnuallyPurchaseFrequency { get; set; }
        public string SemiAnnuallyTotal { get; set; }

        public string AnnuallyPurchasesAmount { get; set; }
        public string AnnuallyPurchaseFrequency { get; set; }
        public string AnnuallyTotal { get; set; }

        public string TotalMonthlyPurchaseTranche { get; set; }

        //Accumulative
        public string PurchaseToBeConsidered { get; set; }
        public List<CreatePurchaseDetailGrandChildDto> PurchaseDetailGrandChild { get; set; }
    }
}
