using System;
using System.Threading.Tasks;
using Audit.Application.Versions.Command.CreateCommand;
using Audit.Application.Versions.Query.GetVersions;
using Microsoft.AspNetCore.Mvc;

namespace Audit.WebUI.Controllers
{
    public class VersionsController: ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateVersionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<VersionVM>> Get()
        {
            return await Mediator.Send(new GetVersionsQuery());
        }
    }
}