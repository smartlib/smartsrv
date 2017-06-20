using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class Currency
    {
        public Currency()
        {
            SymbolLcurrNavigation = new HashSet<Symbol>();
            SymbolRcurrNavigation = new HashSet<Symbol>();
        }

        [Column(TypeName = "varchar(10)")]
        [Key]
        public string Code { get; set; }

        [InverseProperty("LcurrNavigation")]
        public virtual ICollection<Symbol> SymbolLcurrNavigation { get; set; }
        [InverseProperty("RcurrNavigation")]
        public virtual ICollection<Symbol> SymbolRcurrNavigation { get; set; }
    }
}
