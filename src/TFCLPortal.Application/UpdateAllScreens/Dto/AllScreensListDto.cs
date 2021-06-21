using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AllScreensSaveMethod.Dto;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.BusinessDetails;
using TFCLPortal.BusinessExpenses;
using TFCLPortal.BusinessIncomes;
using TFCLPortal.BusinessPlans;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.CollateralDetails;
using TFCLPortal.ContactDetails;
using TFCLPortal.ExposureDetails;
using TFCLPortal.ForSDES;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.HouseholdIncomesExpenses;
using TFCLPortal.Applications;
using TFCLPortal.OtherDetails;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Preferences;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.LoanEligibilities;
using Abp.UI;
using TFCLPortal.UpdateAllScreens.Dto;
using TFCLPortal.DescripentScreens;
using TFCLPortal.DescripentScreens.Dto;
using System.Linq;
using TFCLPortal.AssociatedIncomeDetails;
using TFCLPortal.NonAssociatedIncomeDetails;
using TFCLPortal.FilesUploads;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.BranchManagerActions.Dto;
using TFCLPortal.FinalWorkflows.Dto;


namespace TFCLPortal.UpdateAllScreens.Dto
{
    public class AllScreensListDto
    {
        public List<PersonalDetailDto> MyProperty { get; set; }
    }
}
