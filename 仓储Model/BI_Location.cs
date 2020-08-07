namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_Location()
        {
            BI_LocalProduct = new HashSet<BI_LocalProduct>();
            WJ_MovementDetails = new HashSet<WJ_MovementDetails>();
            WJ_StockOutDetails = new HashSet<WJ_StockOutDetails>();
            WJ_BreakageDetails = new HashSet<WJ_BreakageDetails>();
            WJ_CheckDetails = new HashSet<WJ_CheckDetails>();
            WJ_StockInDetails = new HashSet<WJ_StockInDetails>();
        }

        [Key]
        [StringLength(20)]
        public string LocalNum { get; set; }

        [StringLength(20)]
        public string LocalName { get; set; }

        public int? LocalTypeID { get; set; }

        [StringLength(20)]
        public string StorageNum { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        [StringLength(2)]
        public char? IsForbid { get; set; }

        public int? IsDefault { get; set; }

        public int? IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_LocalProduct> BI_LocalProduct { get; set; }

        public virtual BI_LocaType BI_LocaType { get; set; }

        public virtual BI_Storage BI_Storage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_MovementDetails> WJ_MovementDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockOutDetails> WJ_StockOutDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_BreakageDetails> WJ_BreakageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_CheckDetails> WJ_CheckDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockInDetails> WJ_StockInDetails { get; set; }
    }
}
