using Microsoft.EntityFrameworkCore;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Abstrations;
using System.Linq.Expressions;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class Repository<TEntity>(MillionRealStateCompanyContext context) : RepositoryBase<TEntity>(context), IRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Create(TEntity entity)
        {
            var response = DbSet.Add(entity);
            return response.Entity;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
