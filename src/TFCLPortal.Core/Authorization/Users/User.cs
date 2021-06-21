﻿using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace TFCLPortal.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "TFCL@2020";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
        public string IMEI { get; set; }
        public int? BranchId { get; set; }
    }
}
