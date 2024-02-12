using AutoMapper;
using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;

namespace FirstSpaceApi.Services.Service
{
    public class ServiceProvider : FirstSpaceApi.Services.IService.IServiceProvider
    {
        private readonly Lazy<IUserService> _userService;
        private readonly IFSLoggerServices _logger;


        public ServiceProvider(IUnitOfWork unitOfWork, IFSLoggerServices logger, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(unitOfWork, logger, mapper));
        }

        public IUserService UserService => _userService.Value;

    }
}
