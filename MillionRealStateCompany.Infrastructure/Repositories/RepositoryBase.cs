using Microsoft.EntityFrameworkCore;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity>(MillionRealStateCompanyContext context) : IDisposable where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

        #region IDisposable

        private bool _disposed;

        ~RepositoryBase() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                context.Dispose();

            _disposed = true;
        }

        #endregion
    }
}
