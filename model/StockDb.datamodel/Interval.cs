using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public partial class Interval
    {
        [Column(TypeName = "varchar(10)")]
        [Key]
        public string Code { get; set; }
        public long TimeSpan { get; set; }
        public double? Seconds { get; set; }
        public double? Minutes { get; set; }
        public double? Hours { get; set; }
        public double? Days { get; set; }
        public double? Weeks { get; set; }
        public double? Months { get; set; }
        public double? Years { get; set; }
    }
}
