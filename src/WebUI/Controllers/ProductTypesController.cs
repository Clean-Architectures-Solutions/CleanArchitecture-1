using System.Threading.Tasks;
using Audit.Application.ProductTypes.Commands.CreateProductType;
using Audit.Application.ProductTypes.Query.GetProductTypes;
using Microsoft.AspNetCore.Mvc;

namespace Audit.WebUI.Controllers
{
    public class ProductTypesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateProductTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<ProductTypeVm>> Get()
        {
            return await Mediator.Send(new GetProductTypesQuery());
        }
    }
}