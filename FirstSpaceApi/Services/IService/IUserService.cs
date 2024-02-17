﻿using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstSpaceApi.Services.IService
{
    public interface IUserService
    {
        IEnumerable<UserResponseVM> GetAllUser(bool trackChanges);

        UserResponseVM GetUserByID(Guid id, bool trackChanges);

        UserResponseVM CreateUser(UserRequestVM user);

    }
}
