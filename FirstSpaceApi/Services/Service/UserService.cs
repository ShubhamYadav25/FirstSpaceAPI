using AutoMapper;
using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Domain.Exceptions;
using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;

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

        public async Task<IEnumerable<UserResponseVM>> GetAllUser(bool trackChanges)
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAllUsersAsync(trackChanges);
                //var userDto = users.Select(c => new UserDto(c.UserId, c.FirstName, c.LastName, c.MiddleName ?? "", c.UserName, c.Email,c.Password, c.Role, string.Join(c.FirstName, ' ',c.MiddleName, c.LastName) ));
                var userDto = _mapper.Map<IEnumerable<UserResponseVM>>(users);
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetAllUser)} service method { ex}");
                throw;
            }
        }

        public async Task<UserResponseVM> GetUserByID(Guid id, bool trackChanges)
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetUserByIDAsync(id, trackChanges);
                if(users == null)   
                {
                    throw new UserNotFoundException(id);
                }
                var userVM = _mapper.Map<UserResponseVM>(users);
                return userVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserResponseVM> CreateUser(UserRequestVM user)
        {
            var userentity = _mapper.Map<User>(user);

            _unitOfWork.UserRepository.CreateUser(userentity);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<UserResponseVM>(userentity);
        }

        public async Task DeleteUser(Guid userId, bool trackChanges)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIDAsync(userId, false);

            if(user == null)
            {
                throw new UserNotFoundException(userId);
            }

            _unitOfWork.UserRepository.DeleteUser(user);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateUser(Guid userId, UserRequestVM userToUpdate, bool trackChanges)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIDAsync(userId, false);

            if( user == null)
            {
                throw new UserNotFoundException(userId);
            }

            _mapper.Map(userToUpdate, user);
            await _unitOfWork.SaveChangeAsync();
        }

    }

}
