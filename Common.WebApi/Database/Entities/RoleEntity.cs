using System;
using System.ComponentModel.DataAnnotations;

namespace Common.WebApi.Database.Entities
{
    public class RoleEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }
}
