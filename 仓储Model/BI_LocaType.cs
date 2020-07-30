namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BI_LocaType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BI_LocaType()
        {
            BI_Location = new HashSet<BI_Location>();
        }

        [Key]
        public int LocalTypeID { get; set; }

        [StringLength(20)]
        public string LocalTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BI_Location> BI_Location { get; set; }
    }
}
