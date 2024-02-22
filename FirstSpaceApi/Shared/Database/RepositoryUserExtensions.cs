using FirstSpaceApi.Shared.Models;

namespace FirstSpaceApi.Shared.Database
{
    public static class RepositoryUserExtensions
    {

        // QUERIES 


        // Searching 
        public static IQueryable<User> Search(this IQueryable<User> user, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return user;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return user.Where(e => e.UserName.ToLower().Contains(lowerCaseTerm));
        }

    }
}
    