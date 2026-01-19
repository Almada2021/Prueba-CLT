using MediatR;
using Infrastructure.Data;
using Domain.Exceptions;
using Application.Addresses.Common;

namespace Application.Addresses.Commands;

public record DeleteAddressCommand(int Id) : IRequest<AdressResponseDto>;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, AdressResponseDto>
{
    private readonly AppDbContext _context;

    public DeleteAddressCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AdressResponseDto> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses.FindAsync(request.Id);
        if (address == null)
        {
            throw new NotFoundException("Direccion no encontrada");
        }

        _context.Addresses.Remove(address);
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