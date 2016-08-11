using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;

namespace zxm.Dapper.Tests.Entities
{
    [Table("Users")]
    public class User
    {
        [Key, Identity]
        public int Id { get; set; }

        public string Name { get; set; }

        [Status, Deleted]
        public bool Deleted { get; set; }
    }
}
