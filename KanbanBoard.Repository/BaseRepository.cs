using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(T t)
        {
            await _dbContext
                .Set<T>()
                .AddAsync(t);

            await _dbContext
                .SaveChangesAsync();

            return t.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindAsync(id);
            if (entity != null)
            {
                entity.Status = false;
                await UpdateAsync();
            }
            else
            {
                throw new InvalidOperationException("$Not found");
            }
        }

        public async Task<T?> FindAsync(int id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task<ICollection<T>> ListAsync()
        {
            return await _dbContext
                .Set<T>()
                .Where(t => t.Status == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync()
        {
            try
            { 
            await _dbContext
                .SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
    }
}
