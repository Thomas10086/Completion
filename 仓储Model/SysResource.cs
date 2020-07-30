namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysResource")]
    public partial class SysResource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysResource()
        {
            SysRelation = new HashSet<SysRelation>();
            SysResource1 = new HashSet<SysResource>();
        }

        [Key]
        [StringLength(20)]
        public string ResNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ResName { get; set; }

        [StringLength(20)]
        public string ParentNum { get; set; }

        public int? IsDelete { get; set; }

        [StringLength(50)]
        public string Url { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysRelation> SysRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysResource> SysResource1 { get; set; }

        public virtual SysResource SysResource2 { get; set; }
    }
}
