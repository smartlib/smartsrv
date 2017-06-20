using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class DataSource
    {
        [Column(TypeName = "varchar(10)")]
        [Key]
        public string Code { get; set; }
    }
}
