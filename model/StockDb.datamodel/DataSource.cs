using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class DataSource
    {
        public DataSource()
        {
            ImportData = new HashSet<ImportData>();
        }

        [Column(TypeName = "varchar(10)")]
        [Key]
        public string Code { get; set; }

        [InverseProperty("DataSourceCodeNavigation")]
        public virtual ICollection<ImportData> ImportData { get; set; }
    }
}
