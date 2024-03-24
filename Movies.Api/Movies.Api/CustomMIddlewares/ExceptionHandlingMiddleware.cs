using Newtonsoft.Json;
using System.Net;

namespace Movies.Api.CustomMIddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,
                                           ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";  
            var response =  context.Response;
            Object error;

            switch (exception)
            {
                case HttpRequestException ex:
                    context.Response.StatusCode = (int)ex.StatusCode;
                    error = new
                    {
                        Source = ex.Source != null ? $"{ex.Source.Replace("Movies.", "")}Level" : "Application Level",
                        Type = ex.GetType().Name,
                        StatusCode = ex.StatusCode != null ? (int)ex.StatusCode : response.StatusCode,
                        Message = ex.Message
                    };
                    break;


                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error = new
                    {
                        Level = exception.Source != null ? $"{exception.Source.Replace("Movies.", "")} Level Exception" : "Application Level",
                        Type = exception.GetType().Name,
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = exception.Message,
                    };
                    break;
            }

            _logger.LogError($"Exception : {exception.Message} and Inner Exception : {(exception.InnerException != null ? exception.InnerException.Message : "-")}. StackTrace : {exception.StackTrace ?? "-"}");

            var result = JsonConvert.SerializeObject(error);
            await context.Response.WriteAsync(result);
        }
    }
}
