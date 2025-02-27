namespace Src.EndPoints.MVC.HomeService.MiddleWare
{
    public class ExceptionHandlingMiddleWare
    {

            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionHandlingMiddleWare> _logger;

            public ExceptionHandlingMiddleWare(RequestDelegate next, ILogger<ExceptionHandlingMiddleWare> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,ex.Message);
                    if (httpContext.Request.Path.StartsWithSegments("/Admin"))
                    {
                    httpContext.Response.Redirect("/Admin/Error");
                    }
                    else
                    {  
                    httpContext.Response.Redirect("/Home/Error");
                    }
                }

            }
    }
}
