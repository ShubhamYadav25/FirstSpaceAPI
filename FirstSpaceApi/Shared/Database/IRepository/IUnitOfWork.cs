namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task SaveChangeAsync();
    }
} 
