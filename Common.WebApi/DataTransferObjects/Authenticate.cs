using System;
using System.ComponentModel.DataAnnotations;

namespace Common.WebApi.DataTransferObjects
{
    public class Authenticate
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
