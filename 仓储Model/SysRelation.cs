namespace 仓储Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysRelation")]
    public partial class SysRelation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string RoleNum { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ResNum { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual SysResource SysResource { get; set; }

        public virtual SysRole SysRole { get; set; }
    }
}
