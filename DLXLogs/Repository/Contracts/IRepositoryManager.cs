namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        ILogRepository Log { get; }
        Task SaveAsync();
    }
}
