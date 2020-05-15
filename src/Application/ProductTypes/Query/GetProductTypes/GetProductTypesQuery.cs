using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Audit.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Audit.Application.ProductTypes.Query.GetProductTypes
{
    public class GetProductTypesQuery: IRequest<ProductTypeVm>
    {
            
    }

    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, ProductTypeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductTypeVm> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return new ProductTypeVm
            {
                Lists =
                    await _context.ProductTypes
                        .ProjectTo<ProductTypeDto>(_mapper.ConfigurationProvider)
                        .OrderBy(x => x.Name)
                        .ToListAsync(cancellationToken)
            };
        }
    }
}