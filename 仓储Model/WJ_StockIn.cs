namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_StockIn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WJ_StockIn()
        {
            WJ_StockInDetails = new HashSet<WJ_StockInDetails>();
        }

        [Key]
        [StringLength(20)]
        public string StoINum { get; set; }

        [StringLength(20)]
        public string SupNum { get; set; }

        [StringLength(20)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string OrderNum { get; set; }

        public int? StoITypeNum { get; set; }

        public int? SSNum { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual BI_Supplier BI_Supplier { get; set; }

        public virtual WJ_StockStatus WJ_StockStatus { get; set; }

        public virtual WJ_StockInType WJ_StockInType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockInDetails> WJ_StockInDetails { get; set; }
    }
}
