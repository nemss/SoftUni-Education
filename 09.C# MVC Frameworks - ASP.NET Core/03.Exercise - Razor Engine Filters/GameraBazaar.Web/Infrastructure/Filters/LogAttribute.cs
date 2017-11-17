namespace GameraBazaar.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Task.Run(async () =>
            {
                using (var writer = new StreamWriter("logs.txt", true))
                {

                    var dateTime = DateTime.UtcNow;
                    var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
                    var username = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                    var controller = context.Controller.GetType().Name;
                    var action = context.RouteData.Values["action"];

                    var logMessage = $"{dateTime} - {ipAddress} - {username} - {controller}.{action}";

                    if (context.Exception != null)
                    {
                        var exceptionType = context.Exception.GetType().Name;
                        var exceptionMessage = context.Exception.Message;

                        logMessage = $"[!] {logMessage} --> {exceptionType} - {exceptionMessage}";
                    }

                    await writer.WriteLineAsync(logMessage);
                }
            })
            .GetAwaiter()
            .GetResult();
        }
    }
}
