namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_Supplier()
        {
            WJ_StockIn = new HashSet<WJ_StockIn>();
        }

        [Key]
        [StringLength(20)]
        public string SupNum { get; set; }

        public int? SupTypeID { get; set; }

        [StringLength(50)]
        public string SupName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? IsDelete { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual BI_SupType BI_SupType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockIn> WJ_StockIn { get; set; }
    }
}
