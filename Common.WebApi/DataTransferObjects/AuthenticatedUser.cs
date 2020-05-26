using System;
namespace Common.WebApi.DataTransferObjects
{
    public class AuthenticatedUser
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
