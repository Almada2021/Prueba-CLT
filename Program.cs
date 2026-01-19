using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Middleware;
using Application.Users.Commands;
using Infrastructure.Data;
using Endpoints;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=PruebaTecnica.db")
);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequest>();

builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0;

    options.AddOperationTransformer((operation, context, cancellationToken) =>
    {
        operation.Parameters ??= [];

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-API-KEY",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema { Type = JsonSchemaType.String },
            Description = "Introduce tu API Key"
        });

        return Task.CompletedTask;
    });
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
// Swagger
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
        options.RoutePrefix = "swagger";
    });
}
app.UseMiddleware<ApiKeyMiddleware>();

app.Logger.LogInformation("Server Running on PORT: 5165");

app.MapGet("/", () => "Hello World!");
app.MapUserEndpoints();
app.MapAddressEndpoints();
app.MapCurrenciesEndpoints();
app.Run();