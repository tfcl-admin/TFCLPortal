using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.SchoolNonFinancials.Dto
{
    [AutoMapFrom(typeof(SchoolNonFinancial))]
    public class SchoolNonFinancialListDto : EntityDto
    {

        public int ApplicationId { get; set; }
        public int BuildingCondition { get; set; }
        public string BuildingConditionName { get; set; }
        public string PowerBackup { get; set; }
        public string FirstAid { get; set; }
        public string AyasPresent { get; set; }
        public string SeperateWashrooms { get; set; }
        public string ProperLighting { get; set; }
        public string CleanWater { get; set; }
        public string FunctionalComputerLab { get; set; }
        public string SchoolManagementSystem { get; set; }
        public string SchoolDecor { get; set; }
        public string LearningAid { get; set; }
        public string TeacherTrainings { get; set; }
        public string ChildProtection { get; set; }
        public string EmergencyExits { get; set; }
        public string SecurityGuards { get; set; }
        public string HealthEnvironment { get; set; }
        public int FinancialRecords { get; set; }
        public string FinancialRecordsName { get; set; }
        public string BusinessSuccession { get; set; }
        public int BusinessRadius { get; set; }
        public string BusinessRadiusName { get; set; }
        public int TransactionHistory { get; set; }
        public int DropoutStudents { get; set; }
        public int OtherPaymentBehaviour { get; set; }
        public string OtherPaymentBehaviourName { get; set; }
        public string TransactionHistoryName { get; set; }


    }
}
