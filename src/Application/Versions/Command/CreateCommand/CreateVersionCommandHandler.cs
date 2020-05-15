using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using Audit.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Audit.Application.Versions.Command.CreateCommand
{
    public class CreateVersionCommandHandler: IRequestHandler<CreateVersionCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateVersionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Version
            {
                Name = request.Name
            };

            await _context.Versions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Name;
        }
    }
}