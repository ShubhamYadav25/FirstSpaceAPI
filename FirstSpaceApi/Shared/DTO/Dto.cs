using FirstSpaceApi.Shared.Domain.Enums;

namespace FirstSpaceApi.Shared.DTO
{
    public class Dto
    {
        public class UserResponseVM {
            public Guid? UserId { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
            public string FullName { get; set; }
        };

        public class UserRequestVM {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public Role Role = Role.User;
        }

    }
}
