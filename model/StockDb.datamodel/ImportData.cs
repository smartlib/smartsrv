using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class ImportData
    {
        public ImportData()
        {
            ImportDataHistory = new HashSet<ImportDataHistory>();
        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string DataSourceCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string IntervalCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string SymbolCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string TableName { get; set; }

        [InverseProperty("ImportDataNavigation")]
        public virtual ICollection<ImportDataHistory> ImportDataHistory { get; set; }
        [ForeignKey("DataSourceCode")]
        [InverseProperty("ImportData")]
        public virtual DataSource DataSourceCodeNavigation { get; set; }
        [ForeignKey("IntervalCode")]
        [InverseProperty("ImportData")]
        public virtual Interval IntervalCodeNavigation { get; set; }
        [ForeignKey("SymbolCode")]
        [InverseProperty("ImportData")]
        public virtual Symbol SymbolCodeNavigation { get; set; }
    }
}
