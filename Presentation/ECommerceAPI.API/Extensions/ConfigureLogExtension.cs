using ECommerceAPI.API.Configurations.ColumnWriters;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using Serilog.Core;
using Serilog.Context;

namespace ECommerceAPI.API.Extensions
{
    public static class ConfigureLogExtension
    {
        public static void AddSeriLog(this WebApplicationBuilder builder)
        {
            SqlColumn sqlColumn = new()
            {
                ColumnName = "UserName",
                DataType = System.Data.SqlDbType.NVarChar,
                PropertyName = "UserName",
                DataLength = 50,
                AllowNull = true
            };
            ColumnOptions columnOpt = new ();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);
            columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.MSSqlServer(
                connectionString: builder.Configuration.GetConnectionString("SqlServer"),
                 sinkOptions: new MSSqlServerSinkOptions
                 {
                     AutoCreateSqlTable = true,
                     TableName = "logs",
                 },
                 appConfiguration: null,
                 columnOptions: columnOpt
                )
                .Enrich.FromLogContext()
                .Enrich.With<CustomUserNameColumn>()
                .MinimumLevel.Information()
                .CreateLogger();
            builder.Host.UseSerilog(log);
        }

        public static void AddUserNameToSeriLogDatabase(this WebApplication builder)
        {
            builder.Use(async (context, next) =>
            {
                var username = context.User?.Identity.IsAuthenticated != null || true ? context.User.Identity.Name : null;
                LogContext.PushProperty("user_name", username);
                await next();
            });
        }
    }
}
