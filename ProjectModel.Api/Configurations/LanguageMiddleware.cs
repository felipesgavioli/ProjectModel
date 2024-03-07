using System.Globalization;

public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var languageHeader = context.Request.Headers["language"];

        if (!string.IsNullOrEmpty(languageHeader))
        {
            var culture = new CultureInfo(languageHeader);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        await _next(context);
    }
}

public static class LanguageMiddlewareExtensions
{
    public static IApplicationBuilder UseLanguageMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LanguageMiddleware>();
    }
}