namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysDepart")]
    public partial class SysDepart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysDepart()
        {
            Admin = new HashSet<Admin>();
        }

        [Key]
        [StringLength(20)]
        public string DepartNum { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartName { get; set; }

        public int IsDelete { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admin { get; set; }
    }
}
