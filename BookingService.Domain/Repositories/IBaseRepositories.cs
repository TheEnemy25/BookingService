using Ardalis.Specification;

namespace BookingService.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
      where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(object id);
        Task<TEntity> CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity?> GetSingleAsync(ISpecification<TEntity> specification);
        Task<ICollection<TEntity>> GetManyAsync(ISpecification<TEntity> specification);
    }
}
