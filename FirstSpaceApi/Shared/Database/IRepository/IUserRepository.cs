using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.Database.IRepository.IUserRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);

    }
}
                         