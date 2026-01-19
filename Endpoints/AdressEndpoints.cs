// using MediatR;
// using FluentValidation;
// using Application.Adresses.Commands;
// using Application.Adresses.Common;

namespace Endpoints;

public static class AdressEndpoints
{
    public static void MapAdressEndpoints(this IEndpointRouteBuilder app)
    {
        var adressGroup = app.MapGroup("/adresses")
            .WithTags("Adresses");
    }
}