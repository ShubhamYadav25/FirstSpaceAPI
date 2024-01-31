using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.Database.IRepository.IUserRepository;

namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUserDetails();
        public User GetUserDetailById(int id);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(string id);
    }
}
