namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_StockOutDetails
    {
        [Key]
        public int SODNum { get; set; }

        [StringLength(20)]
        public string SnNum { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(20)]
        public string LocalNum { get; set; }

        [StringLength(20)]
        public string StoONum { get; set; }

        [StringLength(20)]
        public string ProductLot { get; set; }

        public double? Num { get; set; }

        public virtual BI_Location BI_Location { get; set; }

        public virtual BI_Product BI_Product { get; set; }

        public virtual WJ_StockOut WJ_StockOut { get; set; }
    }
}
