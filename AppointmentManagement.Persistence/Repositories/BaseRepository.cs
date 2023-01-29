using AppointmentManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppointmentManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppointmentManagementDbContext _dbContext;

        public BaseRepository(AppointmentManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync(
            List<Expression<Func<T, bool>>> predicts = null)
        {
            var entities = _dbContext.Set<T>().AsQueryable();

            if (predicts != null)
            {
                foreach (var predict in predicts)
                {
                    entities = entities.Where(predict);
                }
            }

            return await entities.ToListAsync();
        }

        public async Task<T> AddAsync(T Entity)
        {
            await _dbContext.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();

            return Entity;
        }

        public async Task UpdateAsync(T Entity)
        {
            _dbContext.Entry(Entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T Entity)
        {
            _dbContext.Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
