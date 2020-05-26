using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Common.WebApi.Database;
using Common.WebApi.Database.Entities;
using Common.WebApi.Helpers;
using Common.WebApi.Models;
using Common.WebApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Common.WebApi.Services
{
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _applicationDbContext;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _appSettings = appSettings.Value;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public UserModel Authenticate(string username, string password)
        {
            var userEntity = _applicationDbContext.UserEntities.FirstOrDefault(s => s.Username == username);

            if (userEntity == null)
                return null;

            if (!Cryptography.VerifyHashedPassword(userEntity.Password, password))
            {
                return null;
            }

            var userModel = _mapper.Map<UserModel>(userEntity);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userModel.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userModel.Token = tokenHandler.WriteToken(token);


            return userModel;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var userEntities = _applicationDbContext.UserEntities.ToList();

            var userModels = _mapper.Map<List<UserModel>>(userEntities);

            return userModels;
        }

        public UserModel GetById(int id)
        {

            var userEntity = _applicationDbContext.UserEntities.FirstOrDefault(s => s.Id == id);

            var userModel = _mapper.Map<UserModel>(userEntity);

            return userModel;

        }

        public UserModel Create(UserModel userModel)
        {
            var userEntity = new UserEntity()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                RoleId = userModel.Role.Id,
                Password = Cryptography.HashPassword(userModel.Password)

            };

            _applicationDbContext.UserEntities.Add(userEntity);
            _applicationDbContext.SaveChanges();

            userModel.Id = userEntity.Id;
            userModel.Role = new RoleModel()
            {
                Id = userEntity.Role.Id,
                Name = userEntity.Role.Name
            };

            return userModel;
        }

        public UserModel Update(UserModel userModel)
        {
            var userEntity = _mapper.Map<UserEntity>(userModel);

            _applicationDbContext.UserEntities.Update(userEntity);

            _applicationDbContext.SaveChanges();

            return userModel;
        }

        public bool Delete(int id)
        {
            try
            {
                var userEntity = _applicationDbContext.UserEntities.FirstOrDefault(s => s.Id == id);

                _applicationDbContext.UserEntities.Remove(userEntity);

                _applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
