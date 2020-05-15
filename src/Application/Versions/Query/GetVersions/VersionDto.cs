using Audit.Application.Common.Mappings;
using Audit.Domain.Entities;

namespace Audit.Application.Versions.Query.GetVersions
{
    public class VersionDto: IMapFrom<Version>
    {
        public string Name { get; set; }
    }
}