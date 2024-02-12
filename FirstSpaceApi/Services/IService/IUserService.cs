using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Services.IService
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUser(bool trackChanges);

    }
}
