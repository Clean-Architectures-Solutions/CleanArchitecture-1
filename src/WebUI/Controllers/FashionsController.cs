using System;
using System.Threading.Tasks;
using Audit.Application.Fashions.Command.CreateFashion;
using Audit.Application.Fashions.Query.GetFashion;
using Audit.Application.Fashions.Query.GetFashions;
using Audit.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Audit.WebUI.Controllers
{
    
    public class FashionsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateFashionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<FashionVM>> Get()
        {
            return await Mediator.Send(new GetFashionsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FashionDto>> Get(Guid id)
        {
            return await Mediator.Send(new GetFashionQuery()
            {
                Id =  id
            });
        }
    }
}