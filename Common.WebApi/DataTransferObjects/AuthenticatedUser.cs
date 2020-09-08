using System;
namespace Common.WebApi.DataTransferObjects
{
    public class AuthenticatedUser
    {
        public int UserId { get; set; }
        public string Token { get; set; }

    }
}
