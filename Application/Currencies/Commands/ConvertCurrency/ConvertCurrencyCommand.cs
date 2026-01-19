using MediatR;

namespace Application.Currencies.Commands.ConvertCurrency;

public record ConvertCurrencyCommand(
    string FromCurrencyCode, 
    string ToCurrencyCode, 
    decimal Amount
) : IRequest<ConvertCurrencyResponse>;

public record ConvertCurrencyResponse(
    string FromCurrency,
    string ToCurrency,
    decimal OriginalAmount,
    decimal ConvertedAmount
);