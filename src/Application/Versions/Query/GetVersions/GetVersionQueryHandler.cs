using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.Versions.Query.GetVersions
{
    public class GetVersionQueryHandler : IRequestHandler<GetVersionsQuery, VersionVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVersionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VersionVM> Handle(GetVersionsQuery request, CancellationToken cancellationToken)
        {
            return new VersionVM
            {
                Lists = await _context.Versions
                    .ProjectTo<VersionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}