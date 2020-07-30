namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_Product()
        {
            BI_LocalProduct = new HashSet<BI_LocalProduct>();
            WJ_CheckDetails = new HashSet<WJ_CheckDetails>();
            WJ_MovementDetails = new HashSet<WJ_MovementDetails>();
            WJ_BreakageDetails = new HashSet<WJ_BreakageDetails>();
            WJ_StockInDetails = new HashSet<WJ_StockInDetails>();
            WJ_StockOutDetails = new HashSet<WJ_StockOutDetails>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string SnNum { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public double? MinNum { get; set; }

        public double? MaxNum { get; set; }

        public double? InPrice { get; set; }

        public double? OutPrice { get; set; }

        [StringLength(200)]
        public string Size { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string MeasureNum { get; set; }

        [StringLength(20)]
        public string CusNum { get; set; }

        [StringLength(20)]
        public string CateNum { get; set; }

        public virtual BI_Customer BI_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_LocalProduct> BI_LocalProduct { get; set; }

        public virtual BI_Measure BI_Measure { get; set; }

        public virtual BI_ProductCategory BI_ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_CheckDetails> WJ_CheckDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_MovementDetails> WJ_MovementDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_BreakageDetails> WJ_BreakageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockInDetails> WJ_StockInDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockOutDetails> WJ_StockOutDetails { get; set; }
    }
}
