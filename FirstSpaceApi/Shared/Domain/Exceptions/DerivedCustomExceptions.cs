using FirstSpaceApi.Shared.Domain.Constants;

namespace FirstSpaceApi.Shared.Domain.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid userId) : base(string.Format(Messages.UserNotFound, userId))
        { }
    }

}
