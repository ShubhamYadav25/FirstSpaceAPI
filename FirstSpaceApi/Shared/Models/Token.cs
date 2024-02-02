namespace FirstSpaceApi.Shared.Models
{
    public class Token
    {
    }

    public class TokenRequestVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponseVM
    {
        public string Token { get; set; }
    }
}
