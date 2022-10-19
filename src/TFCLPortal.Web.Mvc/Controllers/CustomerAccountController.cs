using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Abp.AspNetCore.Mvc.Controllers;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.FileTypes;
using TFCLPortal.Web.Models.UploadFiles;
using Microsoft.AspNetCore.Http;
using TFCLPortal.CustomerAccounts.Dto;
using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.CoApplicantDetails;
using System.Collections.Generic;
using TFCLPortal.Transactions;
using TFCLPortal.Transactions.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using Abp.Domain.Repositories;
using TFCLPortal.Branches;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.AuthorizeInstallmentPayments;

namespace TFCLPortal.Web.Controllers
{
    public class CustomerAccountController : AbpController
    {
        private readonly ICustomerAccountAppService _CustomerAccountAppService;
        private readonly ITransactionAppService _TransactionAppService;
        private readonly IRepository<Applicationz> _ApplicationzRepository;
        private readonly IRepository<Branch> _BranchRepository;
        private readonly IRepository<Transaction> _TransactionRepository;
        private readonly IRepository<CustomerAccount> _CustomerAccountRepository;
        private readonly IRepository<AuthorizeInstallmentPayment> _AuthorizeInstallmentPaymentRepository;
        public CustomerAccountController(IRepository<AuthorizeInstallmentPayment> AuthorizeInstallmentPaymentRepository,IRepository<Applicationz> ApplicationzRepository, IRepository<CustomerAccount> CustomerAccountRepository, IRepository<Transaction> TransactionRepository, IRepository<Branch> BranchRepository, ITransactionAppService TransactionAppService, ICustomerAccountAppService CustomerAccountAppService, IHostingEnvironment env, IFileTypeAppService fileTypeAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _AuthorizeInstallmentPaymentRepository = AuthorizeInstallmentPaymentRepository;
            _ApplicationzRepository = ApplicationzRepository;
            _CustomerAccountRepository = CustomerAccountRepository;
            _TransactionRepository = TransactionRepository;
            _BranchRepository = BranchRepository;
            _TransactionAppService = TransactionAppService;
            _CustomerAccountAppService = CustomerAccountAppService;
        }
        public ActionResult Index()
        {
            var getCustomerAccounts = _CustomerAccountAppService.GetAllCustomerAccounts();
            return View(getCustomerAccounts);
        }

        public IActionResult ViewTransactions(int accountId)
        {
            List<TransactionListDto> transactions = new List<TransactionListDto>();
            if (accountId != 0)
            {
                transactions = _TransactionAppService.GetTransactionByAccountId(accountId);
            }
            ViewBag.AccountId = accountId;

            var appDetails = _CustomerAccountAppService.GetApplicationDetailsByAccountId(accountId);
            var acc = _CustomerAccountAppService.GetCustomerAccountById(accountId);
            ApplicationListDto latestLoan = new ApplicationListDto();
            if (appDetails.Count > 0)
            {
                latestLoan = appDetails[appDetails.Count - 1];
                ViewBag.ApplicationId = latestLoan.Id;
                ViewBag.ClientID = latestLoan.ClientID;
                ViewBag.Balance = acc.Balance;
                ViewBag.ClientName = latestLoan.ClientName;
                ViewBag.SchoolName = latestLoan.SchoolName;
                ViewBag.CNICNo = latestLoan.CNICNo;
                ViewBag.Branch = _BranchRepository.Get(latestLoan.FK_branchid) == null ? "" : _BranchRepository.Get(latestLoan.FK_branchid).BranchCode;
                ViewBag.AppStatus = latestLoan.ScreenStatus;
            }

            return View(transactions);
        }

        public IActionResult ViewAllTransactions(DateTime? startdate,DateTime? enddate, int? authorizationstatus)
        {
            var transactions = _TransactionAppService.GetTransactionListDetail();
            if (transactions != null)
            {
                transactions = transactions.FindAll(x => x.Type == "Credit");

                if(startdate!=null)
                {
                    transactions = transactions.FindAll(x => x.CreationTime >= (DateTime)startdate);
                }
                if (enddate != null)
                {
                    transactions = transactions.FindAll(x => x.CreationTime <= (DateTime)enddate);
                }
                if(authorizationstatus!=null)
                {
                    if(authorizationstatus==1)
                    {
                        transactions = transactions.FindAll(x => x.isAuthorized == true);
                    }
                    else if (authorizationstatus == 0)
                    {
                        transactions = transactions.FindAll(x => x.isAuthorized == false);
                    }
                    else if (authorizationstatus == -1)
                    {
                        transactions = transactions.FindAll(x => x.isAuthorized == null);
                    }
                }

                foreach (var transaction in transactions)
                {
                    if (transaction.ApplicationId != 0)
                    {
                        var app = _ApplicationzRepository.Get(transaction.ApplicationId);
                        transaction.ClientID = app.ClientID;
                        transaction.Branch = app.BranchCode;
                    }
                }
            }

            return View(transactions);
        }
        public IActionResult CreditForm(int accountId)
        {

            List<TransactionListDto> transactions = new List<TransactionListDto>();
            if (accountId != 0)
            {
                transactions = _TransactionAppService.GetTransactionByAccountId(accountId);
            }
            ViewBag.AccountId = accountId;

            var appDetails = _CustomerAccountAppService.GetApplicationDetailsByAccountId(accountId);
            ApplicationListDto latestLoan = new ApplicationListDto();
            if (appDetails.Count > 0)
            {
                latestLoan = appDetails[appDetails.Count - 1];
                ViewBag.ClientID = latestLoan.ClientID;
                ViewBag.ApplicationId = latestLoan.Id;
                ViewBag.ClientName = latestLoan.ClientName;
                ViewBag.SchoolName = latestLoan.SchoolName;
                ViewBag.CNICNo = latestLoan.CNICNo;
                ViewBag.Branch = _BranchRepository.Get(latestLoan.FK_branchid) == null ? "" : _BranchRepository.Get(latestLoan.FK_branchid).BranchCode;
                ViewBag.AppStatus = latestLoan.ScreenStatus;

                var apps = _ApplicationzRepository.GetAllList(x => x.CNICNo == latestLoan.CNICNo && x.ScreenStatus == "Disbursed");
                ViewBag.AppsList = new SelectList(apps, "Id", "ClientID");

            }

            var acc = _CustomerAccountAppService.GetCustomerAccountById(accountId);
            if (acc != null)
            {
                ViewBag.Bal = acc.Balance;
                ViewBag.ModificationDate = acc.LastModificationTime == null ? acc.CreationTime : acc.LastModificationTime;
            }



            return View();
        }

        public IActionResult Credit(CreateTransactionDto transaction)
        {
            transaction.BalAfter = transaction.BalBefore + transaction.Amount;
            transaction.Type = "Credit";
            _TransactionAppService.CreateTransaction(transaction);
            return RedirectToAction("ViewTransactions", "CustomerAccount", new { accountid = transaction.Fk_AccountId });
        }

        public IActionResult TransactionAuthorization()
        {
            var schedules = _TransactionAppService.GetUnAuthTransactionListDetail();
            var authPayments = _AuthorizeInstallmentPaymentRepository.GetAllList(x => x.isAuthorized == null);
            var apps = _ApplicationzRepository.GetAllList();
            if (schedules != null)
            {
                foreach (var transaction in schedules.ToArray())
                {
                    if (transaction.ApplicationId != 0)
                    {
                        var getpayments = authPayments.Find(x => x.ApplicationId == transaction.ApplicationId);
                        if(getpayments==null)
                        {
                            var app = apps.Find(x=>x.Id==transaction.ApplicationId);
                            transaction.ClientID = app.ClientID;
                            transaction.Branch = app.BranchCode;
                        }
                        else
                        {
                            schedules.Remove(transaction);
                        }
                    }
                }

            }

            return View(schedules);
        }

        public IActionResult AuthorizeTransaction(int id, bool authorize)
        {
            _TransactionAppService.AuthorizeTransaction(id, authorize);
            return RedirectToAction("TransactionAuthorization", "CustomerAccount");
        }
    }
}
