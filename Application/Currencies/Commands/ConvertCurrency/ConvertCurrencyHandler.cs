using MediatR;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Exceptions;

namespace Application.Currencies.Commands.ConvertCurrency;

public class ConvertCurrencyHandler(AppDbContext context) : IRequestHandler<ConvertCurrencyCommand, ConvertCurrencyResponse>
{
    private readonly AppDbContext _context = context;

    public async Task<ConvertCurrencyResponse> Handle(ConvertCurrencyCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar ambas monedas en la DB
        var fromCurrency = await _context.Currencies
            .FirstOrDefaultAsync(c => c.Code == request.FromCurrencyCode, cancellationToken);

        var toCurrency = await _context.Currencies
            .FirstOrDefaultAsync(c => c.Code == request.ToCurrencyCode, cancellationToken);


        if (fromCurrency == null || toCurrency == null)
        {
            throw new NotFoundException("Una o ambas monedas no existen.");
        }

        // 3. Lógica de conversión usando RateToBase
        // Paso A: Convertir el monto original a la "Moneda Base" (Multiplicar)
        decimal montoBase = request.Amount * fromCurrency.RateToBase;

        // Paso B: Convertir de la "Moneda Base" a la moneda destino (Dividir)
        decimal convertedAmount = montoBase / toCurrency.RateToBase;

        return new ConvertCurrencyResponse(
            fromCurrency.Code,
            toCurrency.Code,
            request.Amount,
            convertedAmount
        );
    }
}