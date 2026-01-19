using MediatR;
using Application.Addresses.Commands;

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
    }
}