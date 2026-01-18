namespace Application.Users.Commands.UpdateUserCommand;

public class UpdateUserRequets
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required bool IsActive { get; set; }
}