namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_Check
    {
        [Key]
        [StringLength(20)]
        public string CheckNum { get; set; }

        [StringLength(20)]
        public string CheckType { get; set; }

        public int? SSNum { get; set; }

        [StringLength(20)]
        public string OrderNum { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual WJ_StockStatus WJ_StockStatus { get; set; }
    }
}
