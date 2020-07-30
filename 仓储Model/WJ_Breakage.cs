namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_Breakage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WJ_Breakage()
        {
            WJ_BreakageDetails = new HashSet<WJ_BreakageDetails>();
        }

        [Key]
        [StringLength(20)]
        public string BreNum { get; set; }

        public int? BreTypeNum { get; set; }

        public int? SSNum { get; set; }

        [StringLength(20)]
        public string OrderNum { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_BreakageDetails> WJ_BreakageDetails { get; set; }

        public virtual WJ_BreakageType WJ_BreakageType { get; set; }

        public virtual WJ_StockStatus WJ_StockStatus { get; set; }
    }
}
