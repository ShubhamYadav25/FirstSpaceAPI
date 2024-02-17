using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public readonly DatabaseContext _databaseContext;
        public readonly ISharedService _sharedService;
        public UserRepository(DatabaseContext databaseContext, ISharedService sharedService) : base(databaseContext)
        {
            _databaseContext = databaseContext;
            _sharedService = sharedService;
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges) =>
                FindAll(trackChanges)
               .OrderBy(c => c.CreatedDate)
               .ToList();

        public User GetUserByID(Guid id, bool trackChanges)
        {
            return FindByCondition(c => c.UserId.Equals(id), trackChanges).SingleOrDefault();
        }

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user) => Delete(user);

        
    }
}
