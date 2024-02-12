using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IFSLoggerServices logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUser(bool trackChanges)
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAllUsers(trackChanges);
                //var userDto = users.Select(c => new UserDto(c.UserId, c.FirstName, c.LastName, c.MiddleName ?? "", c.UserName, c.Email,c.Password, c.Role, string.Join(c.FirstName, ' ',c.MiddleName, c.LastName) ));
                var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
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
