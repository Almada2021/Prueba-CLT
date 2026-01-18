using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Domain.Exceptions;

namespace Application.Users.Commands;

public record DeleteUserCommand(int Id) : IRequest<UserResponseDto>;

public class DeleteUserCommandCommandHandler(AppDbContext context) : IRequestHandler<DeleteUserCommand, UserResponseDto>
{
    private readonly AppDbContext _context = context;

    public async Task<UserResponseDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // Delete user
        User? user = _context.Users.Find(request.Id) ?? throw new NotFoundException("Usuario no encontrado");
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive,
        };
    }
}