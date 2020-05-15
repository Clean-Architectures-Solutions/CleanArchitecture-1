using System;
using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using Audit.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Maximum length for the name of product type is 50 chars")
                .NotEmpty().WithMessage("The name can not be empty string")
                .NotNull().WithMessage("The name can not be null")
                .MustAsync(IsUnique).WithMessage("The specified name already exist");
        }

        private async Task<bool> IsUnique(string name, CancellationToken cancellationToken)
        {
            return await _context.ProductTypes
                .AllAsync(x => x.Name.ToLower() != name.ToLower());
        }
    }
}