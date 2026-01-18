using MediatR;
using FluentValidation;
using Application.Users.Commands;
using Application.Users.Queries;
using Application.Users;
using Application.Users.Commands.UpdateUserCommand;

namespace Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var usersGroup = app.MapGroup("/users")
            .WithTags("Users");

        // POST USER
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

        // GET ALL USERS 
        usersGroup.MapGet("/", async (IMediator mediator) =>
        {
            var query = new GetAllUsersQuery();
            var users = await mediator.Send(query);
            return Results.Ok(new { users });

        })
        .WithSummary("Obtener todos los usuarios")
        .WithDescription("Obtiene todos los usuarios.")
        .Produces<UserResponseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);

        // GET BY ID
        usersGroup.MapGet("/{id}", async (int id, IMediator mediator) =>
        {
            var query = new GetUserByIdQuery(id);
            var user = await mediator.Send<UserResponseDto>(query!);
            return Results.Ok(user);
        }).WithSummary("Obtener un usuario por su ID")
        .WithDescription("Obtiene un usuario por su ID.")
        .Produces<UserResponseDto>(StatusCodes.Status200OK)
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status404NotFound, "application/problem+json")
        .Produces(StatusCodes.Status401Unauthorized);


        // PUT
        usersGroup.MapPut("/{id}", async (int id, UpdateUserRequest request, IMediator mediator, IValidator<UpdateUserRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var command = new UpdateUserCommand(id, request.Name!, request.Email!, request.IsActive!);
            var result = await mediator.Send(command);

            return Results.Ok(result);
        })
        .WithSummary("Actualizar un usuario")
        .Produces<UserResponseDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized);
    }
}