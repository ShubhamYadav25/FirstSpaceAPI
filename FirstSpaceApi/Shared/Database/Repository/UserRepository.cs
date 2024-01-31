using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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

        public User GetUserDetailById(int id)
        {
            try
            {
                User? user = _databaseContext.User.Find(id);
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
                 _databaseContext.User.AddAsync(user);
                
                _databaseContext.SaveChanges();

                // Get updated user data from db
                // Remove if it cost expensive
                //await _databaseContext.Entry(user).ReloadAsync();
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
                User? user = _databaseContext.User.Find(id);
                
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
