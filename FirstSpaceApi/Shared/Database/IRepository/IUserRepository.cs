using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.Database.IRepository.IUserRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);

        Task<User> GetUserByIDAsync(Guid id, bool trackChanges);
        
        void CreateUser(User user);

        void DeleteUser(User user);
    }
}
                         