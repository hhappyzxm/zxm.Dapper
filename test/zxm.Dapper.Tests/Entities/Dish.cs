using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zxm.Dapper.Attributes.Joins;
using zxm.Dapper.Attributes.LogicalDelete;
using zxm.Dapper.Attributes;
namespace zxm.Dapper.Tests.Entities
{
    [Table("Dishes")]
    public class Dish
    {
        [Key, Identity]
        public int DishId { get; set; }

        public string Name { get; set; }

        [LeftJoin("DishImages", "DishId", "DishId")]
        public IList<DishImage> DishImages { get; set; }

        [LeftJoin("DishOptions", "DishId", "DishId")]
        public IList<DishOption> DishOptions { get; set; }
    }
}
