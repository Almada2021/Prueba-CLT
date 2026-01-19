using Application.Addresses.Commands;
using FluentValidation;

public class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
{
    public CreateAddressValidator()
    {

        RuleFor(address => address.Street)
            .NotEmpty().WithMessage("La calle es requerida")
            .MinimumLength(1).WithMessage("La calle debe tener por lo menos un caracter");

        RuleFor(address => address.City)
            .NotEmpty().WithMessage("La ciudad es requerida")
            .MinimumLength(1).WithMessage("La ciudad debe tener por lo menos un caracter");

        RuleFor(address => address.Country)
            .NotEmpty().WithMessage("El país es requerido")
            .MinimumLength(1).WithMessage("El país debe tener por lo menos un caracter");

        RuleFor(address => address.ZipCode)
            .MinimumLength(1).WithMessage("El código postal debe tener por lo menos un caracter")
            .MaximumLength(10).WithMessage("El código postal no debe exceder los 10 caracteres")
            .When(address => address.ZipCode != null);
    }
}