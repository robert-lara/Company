using System;
using System.ComponentModel.DataAnnotations;

namespace Common.WebApi.Database.Entities
{
    public class UserEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
