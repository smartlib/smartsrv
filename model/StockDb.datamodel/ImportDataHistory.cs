using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class ImportDataHistory
    {
        public int Id { get; set; }
        public int ImportDataId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ImportData { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTimeFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTimeTo { get; set; }
        public int Count { get; set; }

        [ForeignKey("ImportDataId")]
        [InverseProperty("ImportDataHistory")]
        public virtual ImportData ImportDataNavigation { get; set; }
    }
}
