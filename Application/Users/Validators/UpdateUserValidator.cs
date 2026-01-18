using FluentValidation;
using Application.Users.Commands.UpdateUserCommand;

namespace Application.Users.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequets>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es requerido para la actualización");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El email es requerido")
            .EmailAddress().WithMessage("Formato de email inválido");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("El estado IsActive es obligatorio");
    }
}