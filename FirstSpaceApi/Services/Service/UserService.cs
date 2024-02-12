using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Services.Service
{
    internal sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFSLoggerServices _logger;
        public UserService(IUnitOfWork unitOfWork, IFSLoggerServices logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IEnumerable<UserDto> GetAllUser(bool trackChanges)
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAllUsers(trackChanges);
                var userDto = users.Select(c => new UserDto(c.UserId, c.FirstName, c.LastName, c.MiddleName ?? "", c.UserName, c.Email,c.Password, c.Role, string.Join(c.FirstName, ' ',c.MiddleName, c.LastName) ));
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetAllUser)} service method { ex}");
                throw;
            }
        }
    }

}
