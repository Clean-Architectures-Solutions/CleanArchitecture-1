using System;
using MediatR;

namespace Audit.Application.Fashions.Command.CreateFashion
{
    public class CreateFashionCommand: IRequest<string>
    {
        public string Name { get; set; }
    }
}