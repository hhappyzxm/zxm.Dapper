using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MicroOrm.Dapper.Repositories.Attributes;

namespace zxm.Dapper.Tests.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key, Identity]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
 