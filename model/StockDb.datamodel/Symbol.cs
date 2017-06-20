using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class Symbol
    {
        [Column(TypeName = "varchar(20)")]
        [Key]
        public string Code { get; set; }
        [Required]
        [Column("LCurr", TypeName = "varchar(10)")]
        public string Lcurr { get; set; }
        [Required]
        [Column("RCurr", TypeName = "varchar(10)")]
        public string Rcurr { get; set; }

        [ForeignKey("Lcurr")]
        [InverseProperty("SymbolLcurrNavigation")]
        public virtual Currency LcurrNavigation { get; set; }
        [ForeignKey("Rcurr")]
        [InverseProperty("SymbolRcurrNavigation")]
        public virtual Currency RcurrNavigation { get; set; }
    }
}
