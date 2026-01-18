using Application.Users.Commands;
using FluentValidation;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacío");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("El email es requerido")
            .EmailAddress().WithMessage("Formato de email inválido");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("La contraseña es requerida")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");
    }
}