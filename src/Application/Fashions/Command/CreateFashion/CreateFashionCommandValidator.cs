using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.Fashions.Command.CreateFashion
{
    public class CreateFashionCommandValidator: AbstractValidator<CreateFashionCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateFashionCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .MaximumLength(120)
                .NotEmpty()
                .NotNull()
                .MustAsync(FashionExist).WithMessage("The specified fashion name already exists.");
        }

        private async Task<bool> FashionExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Fashions
                .AllAsync(x => x.Name.ToLower() != name.ToLower());
        }
    }
}