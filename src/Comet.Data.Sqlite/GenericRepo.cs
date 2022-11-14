using Comet.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Comet.Sqlite 
{
    public class GenericRepo<T> : IGenericRepo<T> where T : EntityBase
    {
        protected readonly CometRSMSqlLiteContext _dbContext;
        public GenericRepo(CometRSMSqlLiteContext dbContext)

        {
            _dbContext = dbContext;
        }

        public virtual async Task<int> Create(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            //entity.CreatedBy = ActiveDevice;
            //entity.ModifiedBy = ActiveDevice;
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<int> Update(T entity)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            //entity.ModifiedBy = ActiveDevice;
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

    }
}