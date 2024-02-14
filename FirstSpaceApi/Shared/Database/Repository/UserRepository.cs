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

        IEnumerable<User> GetUserDetails()
        {
            throw new NotImplementedException("Dont know");
            try
            {
                return _databaseContext.User.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        User GetUserDetailById(string id)
        {
            try
            {
                Guid userId = _sharedService.ConvertStringToGuid(id);
                User? user = _databaseContext.User.Find(userId);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    // TODO : Create Custom Exception
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        User AddUser(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                _databaseContext.User.Add(user);

                _databaseContext.SaveChanges();

                // Get updated user data from db
                // Remove if it cost expensive
                _databaseContext.Entry(user).ReloadAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        User UpdateUser(User user)
        {
            try
            {
                _databaseContext.Entry(user).State = EntityState.Modified;
                _databaseContext.SaveChanges();

                // Updated from db
                _databaseContext.Entry(user).Reload();

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        User DeleteUser(string id)
        {
            try
            {
                Guid userId = _sharedService.ConvertStringToGuid(id);
                User? user = _databaseContext.User.Find(userId);

                if (user != null)
                {
                    _databaseContext.User.Remove(user);
                    _databaseContext.SaveChanges();
                    return user;
                }
                else
                {
                    // TODO : Create Custom Exception
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
