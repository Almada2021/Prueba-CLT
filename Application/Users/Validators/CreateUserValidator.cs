using Application.Users.Commands;
using FluentValidation;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacío")
            .MinimumLength(1).WithMessage("El nombre debe tener por lo menos un caracter");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("El email es requerido")
            .EmailAddress().WithMessage("Formato de email inválido");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("La contraseña es requerida")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");
    }
}