using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(DatabaseContext databaseContext, ISharedService sharedService)
        {
            _databaseContext = databaseContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(databaseContext, sharedService));
            
        }

        public IUserRepository UserRepository => _userRepository.Value;

        void IUnitOfWork.SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
