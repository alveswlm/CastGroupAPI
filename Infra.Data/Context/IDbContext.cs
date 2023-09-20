using Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<ContaEntity> Contas { get; set; }
    }
}