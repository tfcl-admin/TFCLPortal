using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Authorization;
using TFCLPortal.Controllers;
using TFCLPortal.Users;
using TFCLPortal.Web.Models.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.DynamicDropdowns.Genders;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Branches;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using TFCLPortal.Authorization.Users;
using Abp.Runtime.Security;

namespace TFCLPortal.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users, PermissionNames.Pages_BM)]
    public class UsersController : TFCLPortalControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;

        private readonly IBranchDetailAppService _branchDetailAppService;

        public UsersController(UserManager userManager, IUserAppService userAppService, IBranchDetailAppService branchDetailAppService)
        {
            _userAppService = userAppService;
            _branchDetailAppService = branchDetailAppService;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;

            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };
            ViewBag.Branches = new SelectList(_branchDetailAppService.GetBranchListDetail(), "Id", "BranchName");
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            model.BranchId = model.User.BranchId;
            //var BodyStyles = _branchDetailAppService.GetBranchListDetail();
            //var brnch = BodyStyles.Select(m => new SelectListItem
            //{
            //    Value = m.Id.ToString(),
            //    Text = m.BranchName,
            //    Selected = User.Equals(m.Id.ToString())

            //});
            // ViewBag.Branches = BodyStyles;
            ViewBag.Branches = new SelectList(_branchDetailAppService.GetBranchListDetail(), "Id", "BranchName");

            return View("_EditUserModal", model);
        }
        //public string ResetAndroidID(long userId)
        //{
        //    try
        //    {
        //        //var user = _userAppService.Get(new EntityDto<long>(userId));
        //        var user = _userAppService.GetAllUsers().Where(x => x.Id == userId).SingleOrDefault();
        //        user.IMEI = "";
        //        _userAppService.Update(user);
        //        CurrentUnitOfWork.SaveChanges();
        //        return "Android ID reset successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Android ID reset Unsuccessfull : " + ex.Message.ToString();

        //    }
        //}

        //[HttpPost]
        //public string getPass(long userId)
        //{
        //    try
        //    {
        //        //var user = _userAppService.Get(new EntityDto<long>(userId));
        //        //string DefaultPassPhrase = "gsKxGZ012HLL3MI5";

        //        var user = _userManager.GetUserByIdAsync(userId);
        //        ////var user = _userAppService.GetAllUsers().Where(x => x.Id == userId).SingleOrDefault();
        //        //return Base64Decode(user.Result.Password);
        //        ////return SimpleStringCipher.Instance.Decrypt(user.Result.Password,DefaultPassPhrase);


        //        //_________________________________________________________________________________________-

        //        string decryptpassword = user.Result.GetHashCode(user;

        //        string UserPassword = base64Decode(decryptpassword);

        //        return UserPassword;

        //    }
        //    catch (Exception ex)
        //    {
        //        return "Unsuccessfull : " + ex.Message.ToString();

        //    }
        //}

        [HttpPost]
        public async Task<JsonResult> ResetPasswordAsync(string password, int UserId)
        {
            var isEmailExist = _userManager.Users.Where(x => x.Id == UserId).FirstOrDefault();

            if (isEmailExist == null)
            {
                return Json("User does not Exist");
            }
            var result = await _userManager.ChangePasswordAsync(isEmailExist, password);
            //Alerts.Success("Password has been changed succesfully", "Test Alert");

            if (result.Succeeded)
            {
                return Json("Password has been changed succesfully");
            }
            else
            {
                return Json(result.Errors);
            }


        }

        //public static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
    }
}
