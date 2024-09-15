using Microsoft.EntityFrameworkCore.Storage;

namespace MillionRealStateCompany.Shared.Abstrations
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);


    }
}
