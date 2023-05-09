using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebappIdentity_del2.Context;

namespace WebappIdentity_del2.Helpers.Repositories
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        #region Constructors and private fields
        private readonly ApplicationContext _context;

        protected Repo(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return entity;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }
    }
}
