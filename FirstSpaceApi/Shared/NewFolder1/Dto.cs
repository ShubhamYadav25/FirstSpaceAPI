using FirstSpaceApi.Shared.Domain.Enums;

namespace FirstSpaceApi.Shared.DTO
{
    public class Dto
    {
        public record UserDto(
            Guid? UserId, string FirstName, string MiddleName, 
            string LastName, string UserName, string Email, 
            string password, Role role, string FullName
        );

    }
}
