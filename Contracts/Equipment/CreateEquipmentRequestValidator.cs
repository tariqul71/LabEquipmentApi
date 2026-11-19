using FluentValidation;

namespace LabEquipmentApi.Contracts.Equipment;

public class CreateEquipmentRequestValidator
    : AbstractValidator<CreateEquipmentRequest>
{
    public CreateEquipmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Room)
            .NotEmpty()
            .MaximumLength(20);
    }
}
