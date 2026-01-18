using MediatR;
using Infrastructure.Data;
using Domain.Exceptions;


namespace Application.Users.Commands.UpdateUserCommand;

public record UpdateUserCommand(
    int Id,
    string Name,
    string Email,
    bool IsActive
) : IRequest<UserResponseDto>;
public class UpdateUserCommandHandler(AppDbContext context) : IRequestHandler<UpdateUserCommand, UserResponseDto>
{
    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([request.Id], cancellationToken) ?? throw new NotFoundException("Usuario no encontrado");

        user.Name = request.Name;
        user.Email = request.Email;
        user.IsActive = request.IsActive;

        await context.SaveChangesAsync(cancellationToken);

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive
        };
    }
}