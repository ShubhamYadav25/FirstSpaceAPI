using FirstSpaceApi.Shared.Models;
using FirstSpaceApi.Shared.ViewModels;
using static FirstSpaceApi.Shared.DTO.Dto;
using static FirstSpaceApi.Shared.ViewModels.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Services.IService
{
    public interface IUserService
    {
        Task<(IEnumerable<UserResponseVM> users, MetaData metaData)> GetAllUser(UserPagingVM userPagingVM, bool trackChanges);

        Task<UserResponseVM> GetUserByID(Guid id, bool trackChanges);

        Task<UserResponseVM> CreateUser(UserRequestVM user);

        Task DeleteUser(Guid userId, bool trackChanges);

        public Task UpdateUser(Guid userId, UserRequestVM userToUpdate, bool trackChanges);
    }
}
