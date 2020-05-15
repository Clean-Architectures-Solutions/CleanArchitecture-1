using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using Audit.Domain.Entities;
using MediatR;

namespace Audit.Application.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductType
            {
                Name =  request.Name
            };

            await _context.ProductTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Name;
        }
    }
}