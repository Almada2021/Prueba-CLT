using Application.Currencies.Commands.ConvertCurrency;
using FluentValidation;

namespace Application.Currencies.Validators;

public class ConvertCurrencyValidator : AbstractValidator<ConvertCurrencyCommand>
{

    public ConvertCurrencyValidator()
    {
        RuleFor(x => x.FromCurrencyCode)
            .NotEmpty().WithMessage("El código de moneda de origen es requerido.");

        RuleFor(x => x.ToCurrencyCode)
            .NotEmpty().WithMessage("El código de moneda de destino es requerido.");


        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("El monto a convertir debe ser mayor a 0.");
    }
}