using System;
using Audit.Application.Common.Mappings;
using Audit.Domain.Entities;

namespace Audit.Application.Fashions.Query.GetFashions
{
    public class FashionDto: IMapFrom<Fashion>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}