using FirstSpaceApi.Shared.Models;
using FirstSpaceApi.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static FirstSpaceApi.Shared.Database.IRepository.IUserRepository;
using static FirstSpaceApi.Shared.ViewModels.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Shared.Database.IRepository
{
    public interface IUserRepository
    {
        Task<PagedList<User>> GetAllUsersAsync(UserPagingVM userPagingVM,bool trackChanges);

        Task<User> GetUserByIDAsync(Guid id, bool trackChanges);
        
        void CreateUser(User user);

        void DeleteUser(User user);
    }
}
                            