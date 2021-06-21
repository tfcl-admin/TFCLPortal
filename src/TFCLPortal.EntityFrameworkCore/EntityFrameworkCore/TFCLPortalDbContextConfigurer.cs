using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TFCLPortal.EntityFrameworkCore
{
    public static class TFCLPortalDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TFCLPortalDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TFCLPortalDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
