using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS.Dto
{
    [AutoMapFrom(typeof(SalesPurchaseTDS))]
    public class SalesPurchaseTDSListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int NoOfMonthsNormalMonthSales { get; set; }
        public int NoOfMonthsLowMonthSales { get; set; }
        public int NoOfMonthsPeakMonthSales { get; set; }
        public int MonthlySalesNormalMonthSales { get; set; }
        public int MonthlySalesLowMonthSales { get; set; }
        public int MonthlySalesPeakMonthSales { get; set; }
        public int TotalSalesNormalMonthSales { get; set; }
        public int TotalSalesLowMonthSales { get; set; }
        public int TotalSalesPeakMonthSales { get; set; }
        public int TotalAnnualSales { get; set; }
        public int PerMonthAverageSales { get; set; }
        public int TotalDailySales { get; set; }
        public int TotalNoOfDaysRemainsOpenPerWeek { get; set; }
        public int totalWeeklySales { get; set; }
        public int TotalMonthlySales { get; set; }
        public int TotalSalesConsideredLowerofTwo { get; set; }
        public int DailyPurchasesAmount { get; set; }
        public int DailyPurchasesTotal { get; set; }
        public int WeeklyPurchasesAmount { get; set; }
        public int WeeklyPurchasesTotal { get; set; }
        public int FortnightlyPurchasesAmount { get; set; }
        public int FortnightlyPurchasesTotal { get; set; }
        public int MonthlyPurchasesTotal { get; set; }
        public int MonthlyPurchasesAmount { get; set; }
        public int QuaterlyPurchasesAmount { get; set; }
        public int QuaterlyPurchasesTotal { get; set; }
        public int SemiAnnualPurchasesAmount { get; set; }
        public int SemiAnnualPurchasesTotal { get; set; }
        public int AnnualPurchasesAmount { get; set; }
        public int AnnualPurchasesTotal { get; set; }
        public int TotalPurchases { get; set; }
    }
}
