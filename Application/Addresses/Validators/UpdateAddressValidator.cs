using Application.Addresses.Commands;
using FluentValidation;

namespace Application.Addresses.Validators;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Street).NotEmpty().WithMessage("La calle es requerida");
        RuleFor(x => x.City).NotEmpty().WithMessage("La ciudad es requerida");
        RuleFor(x => x.Country).NotEmpty().WithMessage("El país es requerido");
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("El código postal es requerido");
    }
}