using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Shared.Abstrations;
using System.Runtime.CompilerServices;

namespace MillionRealStateCompany.Infrastructure
{
    public sealed class UnitOfWork(MillionRealStateCompanyContext context, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var rowsAffected = await context.SaveChangesAsync(cancellationToken);

                logger.LogInformation("----- Row(s) affected: {RowsAffected}", rowsAffected);

                return rowsAffected;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                logger.LogError(ex, "error confirming data");
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error confirming data");
                throw;
            }
        }

        public async Task BeginTransactionAsync()
        {
            try
            {
                _transaction = await context.Database.BeginTransactionAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generating the transaction");
                throw;
            }

        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
                _transaction?.Dispose();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error confirming data");
                throw;
            }

        }

        public async Task RollBackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
                _transaction?.Dispose();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error confirming data");
                throw;
            }
        }



        #region IDisposable

        private bool _disposed;

        ~UnitOfWork() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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
