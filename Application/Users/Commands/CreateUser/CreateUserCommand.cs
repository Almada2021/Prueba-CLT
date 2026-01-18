using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Infrastructure.lib;

namespace Application.Users.Commands;

public record CreateUserCommand(string Name, string Email, string Password) : IRequest<UserResponseDto>;

public class CreateUserCommandHandler(AppDbContext context) : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private readonly AppDbContext _context = context;

    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // HASH Password don't store plain text :)
        var passwordHash = PasswordHasher.HashPassword(request.Password);

        // Verify if user already exists
        var userExists = _context.Users.Any(u => u.Email == request.Email);
        if (userExists)
        {
            throw new Exception("Usuario ya existe");
        }
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = passwordHash,
            IsActive = true
        };
        // Save the user using private hashed password
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        // Return the created user entity
        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive
        };
    }
}