using Application.Addresses.Common;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Addresses.Queries;

public class GetAllAddressesByUserIdHandler : IRequestHandler<GetAllAddressesByUserIdQuery, List<AdressResponseDto>>
{
    private readonly AppDbContext _context;

    public GetAllAddressesByUserIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AdressResponseDto>> Handle(GetAllAddressesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var addresses = await _context.Addresses
            .Where(a => a.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        return [.. addresses.Select(address => new AdressResponseDto
        {
            Id = address.Id,
            UserId = address.UserId,
            City = address.City,
            ZipCode = address.ZipCode,
            Country = address.Country,
            Street = address.Street
        })];
    }
}