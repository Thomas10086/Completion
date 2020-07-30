namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            WJ_StockOut = new HashSet<WJ_StockOut>();
            BI_LocalProduct = new HashSet<BI_LocalProduct>();
            BI_ProductCategory = new HashSet<BI_ProductCategory>();
            WJ_Breakage = new HashSet<WJ_Breakage>();
            WJ_Movement = new HashSet<WJ_Movement>();
            WJ_Check = new HashSet<WJ_Check>();
            WJ_StockIn = new HashSet<WJ_StockIn>();
        }

        [Key]
        [StringLength(20)]
        public string UserCode { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }

        [StringLength(20)]
        public string ZName { get; set; }

        [StringLength(20)]
        public string RoleNum { get; set; }

        [StringLength(20)]
        public string DepartNum { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        public DateTime CreateTime { get; set; }

        public int? LoginCount { get; set; }

        public DateTime? UpdateTime { get; set; }

        public short? IsDelete { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public virtual SysDepart SysDepart { get; set; }

        public virtual SysRole SysRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockOut> WJ_StockOut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_LocalProduct> BI_LocalProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_ProductCategory> BI_ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_Breakage> WJ_Breakage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_Movement> WJ_Movement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_Check> WJ_Check { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_StockIn> WJ_StockIn { get; set; }
    }
}
