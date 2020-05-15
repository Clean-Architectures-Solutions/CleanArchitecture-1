using MediatR;

namespace Audit.Application.Versions.Command.CreateCommand
{
    public class CreateVersionCommand: IRequest<string>
    {
        public string Name { get; set; }
    }
}