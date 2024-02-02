using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DatabaseContext _databaseContext;
        public readonly ISharedService _sharedService;
        public UserRepository(DatabaseContext databaseContext, ISharedService sharedService)
        {
            _databaseContext = databaseContext;
            _sharedService = sharedService;
        }

        public IEnumerable<User> GetUserDetails()
        {
            try
            {
                return _databaseContext.User.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUserDetailById(string id)
        {
            try
            {
                Guid userId = _sharedService.ConvertStringToGuid(id);
                User? user = _databaseContext.User.Find(userId);
                if (user != null)
                {
                    return user;
                } else
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

        public User AddUser(User user)
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
            } catch (Exception ex) 
            {
                throw;
            }
        }
        public User UpdateUser(User user)
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
        public User DeleteUser(string id)
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
