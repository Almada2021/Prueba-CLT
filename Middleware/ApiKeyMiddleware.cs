namespace Middleware;

public class ApiKeyMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    private const string APIKEYNAME = "X-API-KEY";

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {

        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("API Key no proporcionada.");
            return;
        }

        var apiKey = configuration.GetValue<string>("ApiKey");

        if (!apiKey!.Equals(extractedApiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("API Key no válida.");
            return;
        }
        await _next(context);
    }
}