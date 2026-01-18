using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Middleware;
using Application.Users.Commands;
using Application.Users;
using Infrastructure.Data;
using Application.Users.Queries;

var builder = WebApplication.CreateBuilder(args);

// DB
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

// USERS ROUTES

var usersGroup = app.MapGroup("/users")
    .WithTags("Users");
usersGroup.MapPost("/", async (CreateUserRequest request, IMediator mediator, IValidator<CreateUserRequest> validator) =>
{

    var validationResult = await validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var command = new CreateUserCommand(request.Name, request.Email, request.Password);
    var user = await mediator.Send(command);

    return Results.Created($"/users/{user.Id}", user);
}).WithSummary("Registrar un nuevo usuario")
.WithDescription("Crea un usuario con contraseña hasheada. El email debe ser único en la base de datos.")
.Produces<UserResponseDto>(StatusCodes.Status201Created)
.ProducesValidationProblem()
.Produces<HttpValidationProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json")
.Produces(StatusCodes.Status401Unauthorized);

// DELETE USER
usersGroup.MapDelete("/{id}", async (int id, IMediator mediator) =>
{
    var command = new DeleteUserCommand(id);
    var user = await mediator.Send(command);
    return Results.Ok(user);
})
.WithSummary("Eliminar un usuario")
.WithDescription("Elimina un usuario por su ID.")
.Produces<UserResponseDto>(StatusCodes.Status200OK)
.Produces<HttpValidationProblemDetails>(StatusCodes.Status404NotFound, "application/problem+json")
.Produces(StatusCodes.Status401Unauthorized);
;

// GET ALL USERS with is Active filter query isActive
usersGroup.MapGet("/", async (IMediator mediator) =>
{
    var query = new GetAllUsersQuery();
    var users = await mediator.Send(query);
    return Results.Ok(users);

});

// usersGroup.MapGet("/{id}", async (int id, IMediator mediator) =>
// {
//     var query = new GetUserByIdQuery(id);
//     var user = await mediator.Send(query);
//     return Results.Ok(user);
// });




app.Run();
