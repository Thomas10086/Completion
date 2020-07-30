namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_CusAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_CusAddress()
        {
            WJ_StockOut = new HashSet<WJ_StockOut>();
        }

        [Key]
        [StringLength(20)]
        public string SnNum { get; set; }

        [StringLength(20)]
        public string CusNum { get; set; }

        [StringLength(20)]
        public string Contact { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int? IsDelete { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual BI_Customer BI_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockOut> WJ_StockOut { get; set; }
    }
}
