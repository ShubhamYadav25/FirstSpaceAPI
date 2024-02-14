using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Services.IService
{
    public interface IUserService
    {
        IEnumerable<UserVM> GetAllUser(bool trackChanges);

        UserVM GetUserByID(Guid id, bool trackChanges);

    }
}
