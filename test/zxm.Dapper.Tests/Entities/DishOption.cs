using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zxm.Dapper.Attributes;

namespace zxm.Dapper.Tests.Entities
{
    [Table("DishOptions")]
    public class DishOption
    {
        [Key, Identity]
        public int DishOptionId { get; set; }

        public int DishId { get; set; }

        public string Option { get; set; }
    }
}
