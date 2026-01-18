using Application.Users.Commands;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data Source=PruebaTecnica.db")
);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequest>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();
// verify is not production?
if (app.Environment.IsDevelopment())
{
    // Show swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Logger.LogInformation("Server Running on PORT:");
app.MapGet("/", () => "Hello World!");


app.MapPost("/users", async (CreateUserRequest request, IMediator mediator, IValidator<CreateUserRequest> validator) =>
{

    var validationResult = await validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var command = new CreateUserCommand(request.Name, request.Email, request.Password);
    var user = await mediator.Send(command);

    return Results.Created($"/users/{user.Id}", user);
});
app.Run();
