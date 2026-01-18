using System.ComponentModel.DataAnnotations;
namespace Application.Users.Commands;

// Como isActive por defecto es true, no se incluye en el request 

// Data Transfer Object de user o Usuario
public class CreateUserRequest
{
    [Required]
    [MinLength(1)]
    public required string Name { get; set; }
    [Required]
    [EmailAddress]
    [MinLength(5)]
    public required string Email { get; set; }
    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}