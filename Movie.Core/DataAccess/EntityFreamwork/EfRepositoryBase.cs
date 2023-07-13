using Microsoft.EntityFrameworkCore;
using Movie.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Movie.Core.DataAccess.EntityFreamwork
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addEntity = context.Entry(entity);  //  Entry Sadece Add Methodu ucun yazilir 
            addEntity.State = EntityState.Added;
            context.SaveChanges();

        }
        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updateEntity = context.Update(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var deleteEntity = context.Remove(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> entity)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter != null
                ? context.Set<TEntity>().Where(filter).ToList()
                : context.Set<TEntity>().ToList();

        }
    }
}
