using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Abp;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.Threading;
using Abp.Timing;
using Abp.UI;
using Abp.Web.Models;
using Abp.Zero.Configuration;
using TFCLPortal.Authorization;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.Identity;
using TFCLPortal.MultiTenancy;
using TFCLPortal.Sessions;
using TFCLPortal.Web.Models.Account;
using TFCLPortal.Web.Views.Shared.Components.TenantChange;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net;
using TFCLPortal.Web.Models.Users;
using TFCLPortal.Users.Dto;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TFCLPortal.Users;

namespace TFCLPortal.Web.Controllers
{
    public class AccountController : TFCLPortalControllerBase
    {
        private readonly UserManager _userManager;
        private readonly TenantManager _tenantManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly LogInManager _logInManager;
        private readonly SignInManager _signInManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly ISessionAppService _sessionAppService;
        private readonly ITenantCache _tenantCache;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IHostingEnvironment _env;
        private readonly IUserAppService _userAppService;
        public AccountController(
            IUserAppService userAppService,
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            TenantManager tenantManager,
            IUnitOfWorkManager unitOfWorkManager,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            LogInManager logInManager,
            SignInManager signInManager,
            UserRegistrationManager userRegistrationManager,
            ISessionAppService sessionAppService,
            ITenantCache tenantCache,
            INotificationPublisher notificationPublisher,
            IHostingEnvironment env)
        {
           _userAppService = userAppService;
            _userManager = userManager;
            _multiTenancyConfig = multiTenancyConfig;
            _tenantManager = tenantManager;
            _unitOfWorkManager = unitOfWorkManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _logInManager = logInManager;
            _signInManager = signInManager;
            _userRegistrationManager = userRegistrationManager;
            _sessionAppService = sessionAppService;
            _tenantCache = tenantCache;
            _notificationPublisher = notificationPublisher;
            _env = env;
        }

        #region Login / Logout

        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetAppHomeUrl();
            }
           
            return View(new LoginFormViewModel
            {
                ReturnUrl = returnUrl,
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                IsSelfRegistrationAllowed = IsSelfRegistrationEnabled(),
                MultiTenancySide = AbpSession.MultiTenancySide
            });
        }

        //[HttpPost]
        //[UnitOfWork]
        //public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        //{
        //    returnUrl = NormalizeReturnUrl(returnUrl);
        //    if (!string.IsNullOrWhiteSpace(returnUrlHash))
        //    {
        //        returnUrl = returnUrl + returnUrlHash;
        //    }

        //    var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, GetTenancyNameOrNull());

        //    await _signInManager.SignInAsync(loginResult.Identity, loginModel.RememberMe);
        //    await UnitOfWorkManager.Current.SaveChangesAsync();

        //    return Json(new AjaxResponse { TargetUrl = returnUrl });
        //}

        [HttpPost]
        [UnitOfWork]
        public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, GetTenancyNameOrNull());
            TempData["userId"]=loginResult.User.Id;
            await _signInManager.SignInAsync(loginResult.Identity, loginModel.RememberMe);
            await UnitOfWorkManager.Current.SaveChangesAsync();


            return Json(new AjaxResponse { TargetUrl = returnUrl });

            //if (returnUrl == "/Dashboard/Dashboard")
            //{
            //    return RedirectToAction("Dashboard", "Dashboard");

            //}
            //else
            //{
            //    return RedirectToAction("Account", "login");

            //}

        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        #endregion

        #region Register

        public ActionResult Register()
        {
            return RegisterView(new RegisterViewModel());
        }

        private ActionResult RegisterView(RegisterViewModel model)
        {
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return View("Register", model);
        }

        private bool IsSelfRegistrationEnabled()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return false; // No registration enabled for host users!
            }

            return true;
        }

        [HttpPost]
        [UnitOfWork]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                ExternalLoginInfo externalLoginInfo = null;
                if (model.IsExternalLogin)
                {
                    externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
                    if (externalLoginInfo == null)
                    {
                        throw new Exception("Can not external login!");
                    }

                    model.UserName = model.EmailAddress;
                    model.Password = Authorization.Users.User.CreateRandomPassword();
                }
                else
                {
                    if (model.UserName.IsNullOrEmpty() || model.Password.IsNullOrEmpty())
                    {
                        throw new UserFriendlyException(L("FormIsNotValidMessage"));
                    }
                }

                var user = await _userRegistrationManager.RegisterAsync(
                    model.Name,
                    model.Surname,
                    model.EmailAddress,
                    model.UserName,
                    model.Password,
                    true,
                    model.BranchId,
                    model.IMEI
                );

                // Getting tenant-specific settings
                var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

                if (model.IsExternalLogin)
                {
                    Debug.Assert(externalLoginInfo != null);

                    if (string.Equals(externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email), model.EmailAddress, StringComparison.OrdinalIgnoreCase))
                    {
                        user.IsEmailConfirmed = true;
                    }

                    user.Logins = new List<UserLogin>
                    {
                        new UserLogin
                        {
                            LoginProvider = externalLoginInfo.LoginProvider,
                            ProviderKey = externalLoginInfo.ProviderKey,
                            TenantId = user.TenantId
                        }
                    };
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();

                Debug.Assert(user.TenantId != null);

                var tenant = await _tenantManager.GetByIdAsync(user.TenantId.Value);

                // Directly login if possible
                if (user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin))
                {
                    AbpLoginResult<Tenant, User> loginResult;
                    if (externalLoginInfo != null)
                    {
                        loginResult = await _logInManager.LoginAsync(externalLoginInfo, tenant.TenancyName);
                    }
                    else
                    {
                        loginResult = await GetLoginResultAsync(user.UserName, model.Password, tenant.TenancyName);
                    }

                    if (loginResult.Result == AbpLoginResultType.Success)
                    {
                        await _signInManager.SignInAsync(loginResult.Identity, false);
                        return Redirect(GetAppHomeUrl());
                    }

                    Logger.Warn("New registered user could not be login. This should not be normally. login result: " + loginResult.Result);
                }

                return View("RegisterResult", new RegisterResultViewModel
                {
                    TenancyName = tenant.TenancyName,
                    NameAndSurname = user.Name + " " + user.Surname,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    IsEmailConfirmed = user.IsEmailConfirmed,
                    IsActive = user.IsActive,
                    IsEmailConfirmationRequiredForLogin = isEmailConfirmationRequiredForLogin
                });
            }
            catch (UserFriendlyException ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                return View("Register", model);
            }
        }

        #endregion

        #region External Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(
                "ExternalLoginCallback",
                "Account",
                new
                {
                    ReturnUrl = returnUrl
                });

            return Challenge(
                // TODO: ...?
                // new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
                // {
                //     Items = { { "LoginProvider", provider } },
                //     RedirectUri = redirectUrl
                // },
                provider
            );
        }

        [UnitOfWork]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl, string remoteError = null)
        {
            returnUrl = NormalizeReturnUrl(returnUrl);

            if (remoteError != null)
            {
                Logger.Error("Remote Error in ExternalLoginCallback: " + remoteError);
                throw new UserFriendlyException(L("CouldNotCompleteLoginOperation"));
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                Logger.Warn("Could not get information from external login.");
                return RedirectToAction(nameof(Login));
            }

            await _signInManager.SignOutAsync();

            var tenancyName = GetTenancyNameOrNull();

            var loginResult = await _logInManager.LoginAsync(externalLoginInfo, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    await _signInManager.SignInAsync(loginResult.Identity, false);
                    return Redirect(returnUrl);
                case AbpLoginResultType.UnknownExternalLogin:
                    return await RegisterForExternalLogin(externalLoginInfo);
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                        loginResult.Result,
                        externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email) ?? externalLoginInfo.ProviderKey,
                        tenancyName
                    );
            }
        }

        private async Task<ActionResult> RegisterForExternalLogin(ExternalLoginInfo externalLoginInfo)
        {
            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            var nameinfo = ExternalLoginInfoHelper.GetNameAndSurnameFromClaims(externalLoginInfo.Principal.Claims.ToList());

            var viewModel = new RegisterViewModel
            {
                EmailAddress = email,
                Name = nameinfo.name,
                Surname = nameinfo.surname,
                IsExternalLogin = true,
                ExternalLoginAuthSchema = externalLoginInfo.LoginProvider
            };

            if (nameinfo.name != null &&
                nameinfo.surname != null &&
                email != null)
            {
                return await Register(viewModel);
            }

            return RegisterView(viewModel);
        }

        [UnitOfWork]
        protected virtual async Task<List<Tenant>> FindPossibleTenantsOfUserAsync(UserLoginInfo login)
        {
            List<User> allUsers;
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                allUsers = await _userManager.FindAllAsync(login);
            }

            return allUsers
                .Where(u => u.TenantId != null)
                .Select(u => AsyncHelper.RunSync(() => _tenantManager.FindByIdAsync(u.TenantId.Value)))
                .ToList();
        }

        #endregion

        #region Helpers

        public ActionResult RedirectToAppHome()
        {
            return RedirectToAction("Dashboard", "Dashboard");
        }

        public string GetAppHomeUrl()
        {
            return Url.Action("Dashboard", "Dashboard");
        }

        #endregion

        #region Change Tenant

        public async Task<ActionResult> TenantChangeModal()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            return View("/Views/Shared/Components/TenantChange/_ChangeModal.cshtml", new ChangeModalViewModel
            {
                TenancyName = loginInfo.Tenant?.TenancyName
            });
        }

        #endregion

        #region Common

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = GetAppHomeUrl;
            }

            if (returnUrl.IsNullOrEmpty())
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }

        #endregion

        #region Etc

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [AbpMvcAuthorize]
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                    "App.SimpleMessage",
                    new MessageNotificationData(message),
                    severity: NotificationSeverity.Info,
                    userIds: new[] { defaultTenantAdmin, hostAdmin }
                 );

            return Content("Sent notification: " + message);
        }

        #endregion


        
        public string PopulateBody(string Name)
        {
            string body = string.Empty;

            string filePath = "ResetPassword.html";

            var Fileuploadpath = Path.Combine(_env.WebRootPath, "Formula");

            bool exists = System.IO.Directory.Exists(Fileuploadpath);
            if (!exists)
                System.IO.Directory.CreateDirectory(Fileuploadpath);


            var pathHtmlFile = Path.Combine(Fileuploadpath, filePath);
            try
            { 
                string EmailPath = pathHtmlFile;
                using (StreamReader reader = new StreamReader(@EmailPath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{link}", Name);
             
            }
            catch (Exception ex)
            {

            }
            return body;
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            var uid = TempData["userId"];
            if (uid== null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.userid = uid;
            }
            return View();
        }


        public ActionResult ResetPassword(string baseString)
        {
            string haxString = Base64Decode(baseString);

            var splitArray = haxString.Split("$$$");

            int userid = Convert.ToInt32(splitArray[0]);
            var ExpireTime = Convert.ToDateTime(splitArray[1]);
            var minuts = (ExpireTime - DateTime.Now).TotalMinutes;
            if (minuts > 0)
            {
                TempData["userId"] = userid;
                TempData.Keep();
            }
            else
            {
                var result = "Link has been Expired,try with new one";
                return View(result);
            }
            ViewBag.userid = TempData["userId"];
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> ResetPasswordAsync(string password,int UserId)
        {
           var isEmailExist = _userManager.Users.Where(x => x.Id == UserId).FirstOrDefault();

            if (isEmailExist == null)
            {
                return Json("User does not Exist");
            }
           var result=  await _userManager.ChangePasswordAsync(isEmailExist, password);
            //Alerts.Success("Password has been changed succesfully", "Test Alert");
            
            if(result.Succeeded)
            {
                return Json("Password has been changed succesfully");
            }
            else
            {
                return Json("Error");
            }


        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        [HttpPost]
        public JsonResult SendEmail(string Email)
        {
            //bool isresult = false;
            var isEmailExist = _userManager.Users.Where(x=>x.EmailAddress== Email).FirstOrDefault();
            if (isEmailExist==null)
            {
                return Json("email does not exist");
            }
            string mailBodyhtml = "";
            var userId = isEmailExist.Id;
            var current = DateTime.Now.AddMinutes(30);

            var haxString = userId + "$$$" + current;

            haxString= Base64Encode(haxString);

            try
            {
                string rootPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                string pathsecond = "Account/ResetPassword?baseString=" + haxString;
                string basepath = rootPath + "/" + pathsecond;
                mailBodyhtml = PopulateBody(basepath);
                sendMailForResetPassword(Email, mailBodyhtml);
            }
            catch (Exception ex)
            {
                return Json("SMTP server requires a secure connection for client : "+ ex);
            }
            //ViewBag.Message = "Link has been sent to your email";
            //return RedirectToAction("login", "Account");
            return Json("Link has been sent to your email");
        }

        private bool sendMailForResetPassword(string mailTo, string mailBodyhtml)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            bool isresult = false;
            message.From = new MailAddress("taleemfinance738@gmail.com");
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            bool isCorrect = rx.IsMatch(mailTo);
            if (isCorrect)
            {
                MailAddress copy = new MailAddress("taleemfinance738@gmail.com");
                message.CC.Add(copy);
                message.To.Add(new MailAddress(mailTo));
                // message.To.Add(new MailAddress("ammarsaeed1059@gmail.com"));
                message.Subject = "Forget Password";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = mailBodyhtml;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("taleemfinance738@gmail.com", "Admin12@");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                isresult = true;

            }
            else
            {
                isresult = false;
            }

            return isresult;

        }

       
    }
}
