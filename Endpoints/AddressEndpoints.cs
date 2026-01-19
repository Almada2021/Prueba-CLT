using MediatR;
using Application.Addresses.Commands;
using FluentValidation;
namespace Endpoints;

public static class AdressEndpoints
{
    public static void MapAddressEndpoints(this IEndpointRouteBuilder app)
    {
        var adressGroup = app.MapGroup("/addresses")
            .WithTags("Addresses");

        adressGroup.MapDelete("/{id}", async (IMediator mediator, int id) =>
        {
            var result = await mediator.Send(new DeleteAddressCommand(id));
            return Results.Ok(result);
        })
        .WithSummary("Elimina una dirección")
        .WithDescription("Elimina una dirección por id")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status404NotFound, "application/problem+json")
        .Produces(StatusCodes.Status401Unauthorized);

        adressGroup.MapPut("/{id}", async (IMediator mediator, int id, UpdateAddressRequest request, IValidator<UpdateAddressRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var command = new UpdateAddressCommand(id, request.Street, request.City, request.Country, request.ZipCode);
            var result = await mediator.Send(command);

            return Results.Ok(result);
        })
        .WithSummary("Actualiza una dirección")
        .WithDescription("Actualiza una dirección por id")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status404NotFound, "application/problem+json")
        .Produces(StatusCodes.Status401Unauthorized);
    }
}