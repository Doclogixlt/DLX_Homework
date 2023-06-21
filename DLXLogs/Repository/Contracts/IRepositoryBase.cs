namespace Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Get();
        Task Add(T entity);
    }
}
