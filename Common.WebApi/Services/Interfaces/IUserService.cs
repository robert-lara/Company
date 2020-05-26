using System;
using System.Collections.Generic;
using Common.WebApi.Models;

namespace Common.WebApi.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(UserModel userModel);
        UserModel Update(UserModel userModel);
        bool Delete(int id);
    }
}
