using Application.Currencies.Commands;
using FluentValidation;


public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyRequest>
{
    public CreateCurrencyValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("El código no puede estar vacío");
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre no puede estar vacío");
        RuleFor(x => x.RateToBase).GreaterThan(0).WithMessage("El tasa de cambio debe ser mayor a 0");
    }
}
