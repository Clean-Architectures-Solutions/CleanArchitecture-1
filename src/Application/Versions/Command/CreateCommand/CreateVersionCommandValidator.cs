using FluentValidation;

namespace Audit.Application.Versions.Command.CreateCommand
{
    public class CreateVersionCommandValidator: AbstractValidator<CreateVersionCommand>
    {
        public CreateVersionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Can not be empty string.")
                .NotNull()
                .WithMessage("Can not be null")
                .MaximumLength(150)
                .WithMessage("Maximum number of characters are 150.");
        }
    }
}