using Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Audit.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Fashion> Fashions { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }

        DbSet<Version> Versions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
