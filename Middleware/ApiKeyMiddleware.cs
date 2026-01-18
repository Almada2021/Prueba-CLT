namespace Middleware;

public class ApiKeyMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    private const string APIKEYNAME = "X-API-KEY";

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        var path = context.Request.Path;

        // EXCEPCIÓN CRÍTICA: Dejar pasar las rutas de documentación y el JSON de metadatos
        if (path.StartsWithSegments("/swagger") ||
            path.StartsWithSegments("/openapi") ||
            path.Value!.Contains("swagger.json"))
        {
            await _next(context);
            return;
        }

        // Validación de API Key
        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("API Key no proporcionada.");
            return;
        }

        var apiKey = configuration.GetValue<string>("ApiKey");

        if (string.IsNullOrEmpty(apiKey) || !apiKey.Equals(extractedApiKey.ToString()))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("API Key no válida.");
            return;
        }

        await _next(context);
    }
}