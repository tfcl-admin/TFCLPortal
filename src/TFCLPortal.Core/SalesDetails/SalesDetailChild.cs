using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.SalesDetails
{
    [Table("SalesDetailChild")]
    public class SalesDetailChild : FullAuditedEntity<Int32>
    {
        public int Fk_SalesDetailId { get; set; }

        public string BusinessName { get; set; }

        //SeasonalSales
        public DateTime AnalysisMonth { get; set; }

        public DateTime? Month1 { get; set; }
        public string Month1Sales { get; set; }

        public DateTime? Month2 { get; set; }
        public string Month2Sales { get; set; }

        public DateTime? Month3 { get; set; }
        public string Month3Sales { get; set; }

        public DateTime? Month4 { get; set; }
        public string Month4Sales { get; set; }

        public DateTime? Month5 { get; set; }
        public string Month5Sales { get; set; }

        public DateTime? Month6 { get; set; }
        public string Month6Sales { get; set; }

        public DateTime? Month7 { get; set; }
        public string Month7Sales { get; set; }

        public DateTime? Month8 { get; set; }
        public string Month8Sales { get; set; }

        public DateTime? Month9 { get; set; }
        public string Month9Sales { get; set; }

        public DateTime? Month10 { get; set; }
        public string Month10Sales { get; set; }

        public DateTime? Month11 { get; set; }
        public string Month11Sales { get; set; }

        public DateTime? Month12 { get; set; }
        public string Month12Sales { get; set; }

        public string PerMonthAvgSeasonalSale { get; set; }

        //ProductWiseSales
        public string TotalMonthlyProductWiseSale { get; set; }


        //DailySales
        public string DailySalesAmount { get; set; }
        public string NoOfWorkingDays { get; set; }
        public string WeeklySales { get; set; }
        public string MonthlySales { get; set; }

        //Accumulative
        public string SalesToBeConsideredThreeLower { get; set; }
        public string IncomeEfficiency { get; set; }
        public string SalesToBeConsidered { get; set; }

    }
}
