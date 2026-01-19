using MediatR;
namespace Application.Currencies.Queries;

public record GetAllCurrenciesQuery() : IRequest<List<CurrencyResponseDto>>;
