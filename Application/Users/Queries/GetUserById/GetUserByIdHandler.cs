using Domain.Exceptions;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Users.Queries;

public class GetUsersByIdQueryHandler(AppDbContext context) : IRequestHandler<GetUserByIdQuery, UserResponseDto?>
{
    public async Task<UserResponseDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {

        var user = await context.Users
            .AsNoTracking()
            .Where(u => u.Id == request.Id)
            .Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
            })
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Usuario no encontrado");
        return user;
    }
}