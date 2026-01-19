using Domain.Entities;
using MediatR;
using Infrastructure.Data;
using Application.Currencies;

namespace Application.Currencies.Commands;

public record CreateCurrencyCommand(string Code, string Name, decimal RateToBase) : IRequest<CurrencyResponseDto>;

public class CreateCurrencyCommandHandler(AppDbContext context) : IRequestHandler<CreateCurrencyCommand, CurrencyResponseDto>
{
    private readonly AppDbContext _context = context;

    public async Task<CurrencyResponseDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = new Currency
        {
            Code = request.Code,
            Name = request.Name,
            RateToBase = request.RateToBase
        };
        await _context.Currencies.AddAsync(currency, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new CurrencyResponseDto
        {
            Id = currency.Id,
            Code = currency.Code,
            Name = currency.Name,
            RateToBase = currency.RateToBase
        };
    }
}