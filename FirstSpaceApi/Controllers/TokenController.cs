using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstSpaceApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public ITokenServices _tokenServices;
        public TokenController(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        [HttpPost]
        public TokenResponseVM Post([FromBody] TokenRequestVM login)
        {
            return _tokenServices.GetAccessToken(login);

        }
    }
}
