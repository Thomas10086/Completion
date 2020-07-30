namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_StockOut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WJ_StockOut()
        {
            WJ_StockOutDetails = new HashSet<WJ_StockOutDetails>();
        }

        [Key]
        [StringLength(20)]
        public string StoONum { get; set; }

        [StringLength(20)]
        public string CusNum { get; set; }

        [StringLength(20)]
        public string SnNum { get; set; }

        [StringLength(20)]
        public string Contact { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string OrderNum { get; set; }

        public int? SSNum { get; set; }

        public int? StoOTypeNum { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual BI_CusAddress BI_CusAddress { get; set; }

        public virtual BI_Customer BI_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockOutDetails> WJ_StockOutDetails { get; set; }

        public virtual WJ_StockStatus WJ_StockStatus { get; set; }

        public virtual WJ_StockOutType WJ_StockOutType { get; set; }
    }
}
