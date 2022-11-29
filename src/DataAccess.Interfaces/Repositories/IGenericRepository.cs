namespace DataAccess.Interfaces.Repositories
{

    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetAll(CancellationToken cancellationToken = default);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Update(List<TEntity> entities);

        void Save();
    }
}