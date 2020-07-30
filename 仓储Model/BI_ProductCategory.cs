namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_ProductCategory()
        {
            BI_Product = new HashSet<BI_Product>();
        }

        [Key]
        [StringLength(20)]
        public string CateNum { get; set; }

        [StringLength(20)]
        public string CateName { get; set; }

        public int? IsDelete { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_Product> BI_Product { get; set; }
    }
}
