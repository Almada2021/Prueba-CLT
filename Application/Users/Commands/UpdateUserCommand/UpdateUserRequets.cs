namespace Application.Users.Commands.UpdateUserCommand;

public class UpdateUserRequest
{
    /// <example>Pablo</example>
    public required string Name { get; set; }
    /// <example>[EMAIL_ADDRESS]</example>
    public required string Email { get; set; }
    /// <example>true</example>
    public required bool IsActive { get; set; }
}