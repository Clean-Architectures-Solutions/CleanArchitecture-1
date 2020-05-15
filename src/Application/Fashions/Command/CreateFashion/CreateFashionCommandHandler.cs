using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using Audit.Domain.Entities;
using MediatR;

namespace Audit.Application.Fashions.Command.CreateFashion
{
    public class CreateFashionCommandHandler : IRequestHandler<CreateFashionCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateFashionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateFashionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Fashion
            {
                Name = request.Name
            };

            await _context.Fashions.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Name;
        }
    }
}