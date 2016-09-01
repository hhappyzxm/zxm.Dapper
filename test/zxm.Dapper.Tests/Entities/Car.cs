using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zxm.Dapper.Tests.Entities
{
    [Table("Cars")]
    public class Car : Entity
    {
        public int UserId { get; set; }

        public string CarName { get; set; }
    }
}
