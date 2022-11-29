using System.Threading.Tasks;

namespace WebApi.Repositories
{

    public interface IGenericRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        
        Task<TEntity> FindAsync(long id);

        Task<bool> TryAddAsync(TEntity entity);
    }
}