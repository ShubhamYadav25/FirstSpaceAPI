namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
} 
