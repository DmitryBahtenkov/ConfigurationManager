using AspNetCoreHero.ToastNotification.Abstractions;
using ConfigurationManager.Framework.Exceptions;

namespace ConfigurationManager.WebApp.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IToastifyService toastifyService)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (BusinessException ex)
        {
            toastifyService.Error(ex.Message);
        }
        catch (Exception exception)
        {
            toastifyService.Error(exception.ToString());
        }
    }
}