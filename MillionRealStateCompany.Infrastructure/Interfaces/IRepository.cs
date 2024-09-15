using MillionRealStateCompany.Shared.Abstrations;
using System.Linq.Expressions;

namespace MillionRealStateCompany.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> expression);

        TEntity GetByCondition(Expression<Func<TEntity, bool>> expression);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
