using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Movies.Models.Common;
using Movies.Models.Settings;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Movies.Api.Filters
{
    public class UserActivityLogFilter : ActionFilterAttribute
    {
        public string Module { get; set; }
        public string Activity { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TO DO : add appsettings
            var options = filterContext.HttpContext.RequestServices.GetService<IOptions<MovieAppSettings>>();
            IMovieAppContext movieAppContext = filterContext.HttpContext.RequestServices.GetService<IMovieAppContext>();

            // TO DO : uncomment this after adding it to appsettings
            //if(options.Value.EnableAuditLogs)
            if(true)
            {
                var nameClaim = filterContext?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "sub" || c.Type.Contains("name"));

                //var connectionString = movieAppContext.CustomerInfo.DatabaseConnectionString;
                var connectionString = movieAppContext?.CustomerInfo?.DatabaseConnectionString ?? string.Empty;
                var ipAddress = Convert.ToString(filterContext.HttpContext.Connection.RemoteIpAddress);

                Task.Run(() =>
                {
                    LogUserActivities(filterContext.ActionArguments, Module, Activity, nameClaim?.Value ?? "Unknown User",
                                      connectionString, filterContext.HttpContext.Request.QueryString.Value, ipAddress);
                });
            }

            base.OnActionExecuting(filterContext);
        }

        private static void LogUserActivities(IDictionary<string, object> actionArguments, string module, string activity, 
                                              string username, string connectionString, string queryString, string ipAddress)
        {
            var metaInfo = string.Empty;

            //var columnOptions = new ColumnOptions();
            //columnOptions.Store.Remove(StandardColumn.Properties);
            //columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            //columnOptions.Store.Remove(StandardColumn.Level);
            //columnOptions.Store.Remove(StandardColumn.Exception);
            //columnOptions.Store.Remove(StandardColumn.Id);

            //columnOptions.AdditionalColumns = new List<SqlColumn>
            //{
            //    new SqlColumn() { ColumnName = "Id", PropertyName = "Id", DataType = System.Data.SqlDbType.UniqueIdentifier},
            //    new SqlColumn() { ColumnName = "Username", PropertyName = "Username", DataType = System.Data.SqlDbType.NVarChar },
            //    new SqlColumn() { ColumnName = "Activity", PropertyName = "Activity", DataType = System.Data.SqlDbType.NVarChar },
            //    new SqlColumn() { ColumnName = "Module", PropertyName = "Module", DataType = System.Data.SqlDbType.NVarChar },
            //    new SqlColumn() { ColumnName = "IpAddress", PropertyName = "IpAddress", DataType = System.Data.SqlDbType.NVarChar },
            //    new SqlColumn() { ColumnName = "MetaInfo", PropertyName = "MetaInfo", DataType = System.Data.SqlDbType.NVarChar }
            //};

            //var logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .Enrich.WithMachineName()
            //                .AuditTo.MSSqlServer(connectionString,
            //                                     new MSSqlServerSinkOptions
            //                                     {
            //                                         TableName = "UserEventLogs",
            //                                         AutoCreateSqlTable = true,
            //                                     }, columnOptions: columnOptions).CreateLogger();

            var log = new LogUserActivity()
            {
                UserName = username,
                Module = module,
                Activity = activity
            };

            Log.Information("[User Activity Logs] {Id} {Username} {Module} {Activity} {IPAddress} {MetaInfo}",
                                Guid.NewGuid(), log.UserName, log.Module, log.Activity, ipAddress, metaInfo);

            //logger.Information("[User Activity Logs] {Id} {Username} {Module} {Activity} {IPAddress} {MetaInfo}",
            //                    Guid.NewGuid() ,log.UserName, log.Module, log.Activity, ipAddress, metaInfo);
        }

        private struct LogUserActivity
        {
            public string UserName { get; set;}
            public string Module { get; set;}
            public string Activity { get; set;}
        }
    }
}
