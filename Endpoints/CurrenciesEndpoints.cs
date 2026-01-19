using MediatR;
using Application.Currencies.Commands;
using FluentValidation;
using Application.Currencies;
using Application.Currencies.Queries;
namespace Endpoints;

public static class CurrenciesEndpoints
{
    public static void MapCurrenciesEndpoints(this WebApplication app)
    {
        var currenciesRoute = app.MapGroup("/currencies").WithTags("Currencies");
        currenciesRoute.MapGet("", async (IMediator mediator) =>
        {
            var query = new GetAllCurrenciesQuery();
            var currencies = await mediator.Send(query);
            return Results.Ok(new { currencies });
        })
        .WithSummary("Obtener todas las monedas")
        .WithDescription("Obtiene todas las monedas registradas en el sistema.")
        .Produces<CurrencyResponseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        ;

        currenciesRoute.MapPost("", async (CreateCurrencyRequest request, IMediator mediator, IValidator<CreateCurrencyRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            var command = new CreateCurrencyCommand(request.Code, request.Name, request.RateToBase);
            var currency = await mediator.Send(command);
            return Results.Created($"/currencies/{currency.Id}", currency);
        })
        .WithSummary("Crear una nueva moneda")
        .WithDescription("Crea una moneda con los datos proporcionados.")
        .Produces<CurrencyResponseDto>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json")
        .Produces(StatusCodes.Status401Unauthorized)
        ;

        // app.MapPost("/currency/convert", async (IMediator mediator, ConvertCurrencyCommand command) =>
        // {
        //     var result = await mediator.Send(command);
        //     return Results.Ok(result);
        // });
    }
}
