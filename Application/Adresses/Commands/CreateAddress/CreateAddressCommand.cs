using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using MediatR;
using Application.Adresses.Common;
namespace Application.Adresses.Commands;

public record CreateAdressCommand(int UserId, string Street, string City, string Country, string? ZipCode) : IRequest<AdressResponseDto>;

public class CreateAdressCommandHandler(AppDbContext context) : IRequestHandler<CreateAdressCommand, AdressResponseDto>
{
    private readonly AppDbContext _context = context;

    public async Task<AdressResponseDto> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
    {
        // Verificar si el usuario existe
        var user = await _context.Users.FindAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("Usuario no encontrado");
        }
        var adress = new Address
        {
            UserId = request.UserId,
            Street = request.Street,
            City = request.City,
            Country = request.Country,
            ZipCode = request.ZipCode,
        };
        _context.Addresses.Add(adress);
        await _context.SaveChangesAsync(cancellationToken);
        return new AdressResponseDto
        {
            Id = adress.Id,
            UserId = adress.UserId,
            Street = adress.Street,
            City = adress.City,
            Country = adress.Country,
            ZipCode = adress.ZipCode
        };
    }
}