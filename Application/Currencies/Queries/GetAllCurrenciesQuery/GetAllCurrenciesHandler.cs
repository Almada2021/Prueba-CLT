using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Currencies.Queries;

public class GetAllCurrenciesQueryHandler(AppDbContext context) : IRequestHandler<GetAllCurrenciesQuery, List<CurrencyResponseDto>>
{
    private readonly AppDbContext _context = context;

    public async Task<List<CurrencyResponseDto>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Currencies
              .AsNoTracking()
              .Select(currency => new CurrencyResponseDto
              {
                  Id = currency.Id,
                  Name = currency.Name,
                  Code = currency.Code,
                  RateToBase = currency.RateToBase
              })
              .ToListAsync(cancellationToken);
    }
}