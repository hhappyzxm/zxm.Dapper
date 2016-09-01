using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zxm.Dapper.Attributes;

namespace zxm.Dapper.Tests.Entities
{
    [Table("DishImages")]
    public class DishImage
    {
        [Key, Identity]
        public int DishImageId { get; set; }

        public int DishId { get; set; }

        public string Image { get; set; }
    }
}
