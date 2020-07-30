namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WJ_Movement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WJ_Movement()
        {
            WJ_MovementDetails = new HashSet<WJ_MovementDetails>();
        }

        [Key]
        [StringLength(20)]
        public string MovNum { get; set; }

        public int? SSNum { get; set; }

        [StringLength(20)]
        public string OrderNum { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        public int? MovTypeNum { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(20)]
        public string Remark { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual WJ_MovementType WJ_MovementType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WJ_MovementDetails> WJ_MovementDetails { get; set; }

        public virtual WJ_StockStatus WJ_StockStatus { get; set; }
    }
}
