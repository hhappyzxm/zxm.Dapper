﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zxm.Dapper.Tests.Entities
{
    [Table("Images")]
    public class Image : Entity
    {
        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
 