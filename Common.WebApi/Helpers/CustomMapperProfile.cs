using System;
using AutoMapper;
using Common.WebApi.Database.Entities;
using Common.WebApi.DataTransferObjects;
using Common.WebApi.Models;

namespace Common.WebApi.Helpers
{
    public class CustomMapperProfile:Profile
    {
        public CustomMapperProfile()
        {
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
        }
    }
}
