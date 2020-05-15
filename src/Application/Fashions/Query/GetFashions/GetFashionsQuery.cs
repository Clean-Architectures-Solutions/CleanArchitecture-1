using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.Fashions.Query.GetFashions
{
    public class GetFashionsQuery: IRequest<FashionVM>
    {
        
    }

    public class GetFashionsQueryHandler : IRequestHandler<GetFashionsQuery, FashionVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFashionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FashionVM> Handle(GetFashionsQuery request, CancellationToken cancellationToken)
        {
            return new FashionVM
            {
                Lists = await _context.Fashions
                    .ProjectTo<FashionDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x=>x.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}