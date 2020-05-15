using System.Data;
using MediatR;

namespace Audit.Application.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommand: IRequest<string>
    {
        public string Name { get; set; }
    }
}