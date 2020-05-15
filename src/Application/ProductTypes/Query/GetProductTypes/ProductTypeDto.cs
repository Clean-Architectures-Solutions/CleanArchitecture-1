using System;
using Audit.Application.Common.Mappings;
using Audit.Domain.Entities;

namespace Audit.Application.ProductTypes.Query.GetProductTypes
{
    public class ProductTypeDto : IMapFrom<ProductType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}