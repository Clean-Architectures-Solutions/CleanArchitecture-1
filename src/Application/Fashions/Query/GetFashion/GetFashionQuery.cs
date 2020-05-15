using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using Audit.Application.Fashions.Query.GetFashions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.Fashions.Query.GetFashion
{
    public class GetFashionQuery: IRequest<FashionDto>
    {
        public Guid Id { get; set; }
    }

    public class GetFashionQueryHandler : IRequestHandler<GetFashionQuery, FashionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFashionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FashionDto> Handle(GetFashionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Fashions
                .ProjectTo<FashionDto>(_mapper.ConfigurationProvider)
                .Where(w => w.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}