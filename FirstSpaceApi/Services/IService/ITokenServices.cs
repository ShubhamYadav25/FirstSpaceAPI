using FirstSpaceApi.Shared.Models;

namespace FirstSpaceApi.Services.IService
{
    public interface ITokenServices
    {
        public TokenResponseVM GetAccessToken(TokenRequestVM tokenRquestVM);
    }
}
