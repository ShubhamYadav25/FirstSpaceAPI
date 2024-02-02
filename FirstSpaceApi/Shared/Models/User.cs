using FirstSpaceApi.Shared.Domain.Enums;

namespace FirstSpaceApi.Shared.Models
{
    public class User : BaseEntity
    {
        private Role _role = Role.User;
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }

        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { 
            get { return _role; }
            set {  _role = value; }
        }
    }
}
