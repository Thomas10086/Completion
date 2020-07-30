namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_LocalProduct
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string LocalNum { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ProductLot { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string SnNum { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string BarCode { get; set; }

        public double? Num { get; set; }

        [Required]
        [StringLength(20)]
        public string UserCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual BI_Location BI_Location { get; set; }

        public virtual BI_Product BI_Product { get; set; }
    }
}
