using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using MediatR;
using Application.Addresses.Common;

namespace Application.Addresses.Commands;

public record UpdateAddressCommand(int Id, string Street, string City, string Country, string? ZipCode) : IRequest<AdressResponseDto>;

public class UpdateAddressCommandHandler(AppDbContext context) : IRequestHandler<UpdateAddressCommand, AdressResponseDto>
{
    private readonly AppDbContext _context = context;

    public async Task<AdressResponseDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses.FindAsync([request.Id], cancellationToken);

        if (address == null)
        {
            throw new NotFoundException("Dirección no encontrada");
        }

        address.Street = request.Street;
        address.City = request.City;
        address.Country = request.Country;
        address.ZipCode = request.ZipCode;

        await _context.SaveChangesAsync(cancellationToken);

        return new AdressResponseDto
        {
            Id = address.Id,
            UserId = address.UserId,
            Street = address.Street,
            City = address.City,
            Country = address.Country,
            ZipCode = address.ZipCode
        };
    }
}