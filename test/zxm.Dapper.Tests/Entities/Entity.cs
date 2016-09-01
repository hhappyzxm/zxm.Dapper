using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using zxm.Dapper.Attributes;

namespace zxm.Dapper.Tests.Entities
{
    public class Entity
    {
        [Key, Identity]
        public int Id { get; set; }
    }
}
