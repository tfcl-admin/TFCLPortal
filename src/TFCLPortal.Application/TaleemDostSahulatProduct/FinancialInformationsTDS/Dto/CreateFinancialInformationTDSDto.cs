using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS.Dto
{
    [AutoMapTo(typeof(FinancialInformationTDS))]
    public  class CreateFinancialInformationTDSDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int MonthlyBISales { get; set; }
        public int MonthlyBIOtherBusinessIncomes { get; set; }
        public int TotalBusinessIncomes { get; set; }
        public int NetBusinessIncomes { get; set; }
        public int MonthlyBEPurchases { get; set; }
        public int MonthlyBELoanInstallmentPayments { get; set; }
        public int MonthlyBERentAmount { get; set; }
        public int MonthlyBESalaryWages { get; set; }
        public int MonthlyBEUtilities { get; set; }
        public int MonthlyBETransportCarriage { get; set; }
        public int MonthlyBERepairMaintinance { get; set; }
        public int MonthlyBEEntertainment { get; set; }
        public int MonthlyBEOtherBusinessExpenses { get; set; }
        public int MonthlyBEProvisionOfExpenses10 { get; set; }
        public int TotalBusinessExpenses { get; set; }
        public int MonthlyHINetBusinessIncome { get; set; }
        public int MonthylyHIRentalIncome { get; set; }
        public int MonthlyHISalaryPensionIncome { get; set; }
        public int MonthlyHIaFmilyIncome { get; set; }
        public int MonthlyHIAnyOtherIncome { get; set; }
        public int TotalHousholdIncome { get; set; }
        public int NetHouseholdDisposableIncome { get; set; }
        public int MonthlyHEHouseRent { get; set; }
        public int MonthlyHELiving { get; set; }
        public int MonthlyHEUtiliities { get; set; }
        public int MonthlyHELoanInstallmentPayment { get; set; }
        public int MonthlyHECommitteeInstalment { get; set; }
        public int MonthlyHEEducational { get; set; }
        public int OtherHouseholdExpenses { get; set; }
        public int ProvisionalHouseholdExpenses { get; set; }
        public int TotalHouseholdExpenses { get; set; }
        public int MonthlyLoanInstalment { get; set; }
        public int InstalmentRatio { get; set; }
    }
}
