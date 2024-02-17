﻿using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public readonly DatabaseContext _databaseContext;
        public readonly ISharedService _sharedService;
        public UserRepository(DatabaseContext databaseContext, ISharedService sharedService) : base(databaseContext)
        {
            _databaseContext = databaseContext;
            _sharedService = sharedService;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
                await FindAll(trackChanges)
               .OrderBy(c => c.CreatedDate)
               .ToListAsync();

        public async Task<User> GetUserByIDAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(c => c.UserId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user) => Delete(user);

        
    }
}
