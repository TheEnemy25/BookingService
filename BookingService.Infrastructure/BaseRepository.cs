using Ardalis.Specification;
using BookingService.Domain.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BookingService.Infrastructure
{
    public class BaseRepository<TEntity>
    : RepositoryBase<TEntity>,
        IBaseRepository<TEntity>
        where TEntity : class
    {
        internal readonly BookingServiceContext _context;
        internal readonly DbSet<TEntity> _entitySet;

        public BaseRepository(BookingServiceContext appContext) : base(appContext)
        {
            _context = appContext;
            _entitySet = appContext.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(object ids)
        {
            return await _context.FindAsync<TEntity>(ids);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntry = await _context.AddAsync<TEntity>(entity);
            return createdEntry.Entity;
        }

        public void UpdateAsync(TEntity entity)
        {
            _entitySet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToRemove = await _context.FindAsync<TEntity>(id);

            if (entityToRemove != null)
            {
                _entitySet.Remove(entityToRemove);
            }
        }

        public async Task<TEntity?> GetSingleAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetManyAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_entitySet, specification);
        }
    }
}