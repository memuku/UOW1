using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using UOWW.Core.Interfaces;


namespace UOWW.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PMSDbContext _context;
        protected DbSet<T> dbSet;
        private PMSDbContext context;
        private ILogger logger;
        protected readonly ILogger _logger;

        public GenericRepository(
            PMSDbContext context,
            ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }

        public GenericRepository(PMSDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var t = await dbSet.FindAsync(id);

            if (t != null)
            {
                dbSet.Remove(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
