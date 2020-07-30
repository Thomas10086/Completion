namespace 仓储Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Completion : DbContext
    {
        public Completion()
            : base("name=Completion")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<BI_CusAddress> BI_CusAddress { get; set; }
        public virtual DbSet<BI_Customer> BI_Customer { get; set; }
        public virtual DbSet<BI_LocalProduct> BI_LocalProduct { get; set; }
        public virtual DbSet<BI_Location> BI_Location { get; set; }
        public virtual DbSet<BI_LocaType> BI_LocaType { get; set; }
        public virtual DbSet<BI_Measure> BI_Measure { get; set; }
        public virtual DbSet<BI_Product> BI_Product { get; set; }
        public virtual DbSet<BI_ProductCategory> BI_ProductCategory { get; set; }
        public virtual DbSet<BI_Storage> BI_Storage { get; set; }
        public virtual DbSet<BI_Supplier> BI_Supplier { get; set; }
        public virtual DbSet<BI_SupType> BI_SupType { get; set; }
        public virtual DbSet<SysDepart> SysDepart { get; set; }
        public virtual DbSet<SysRelation> SysRelation { get; set; }
        public virtual DbSet<SysResource> SysResource { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<WJ_Breakage> WJ_Breakage { get; set; }
        public virtual DbSet<WJ_BreakageDetails> WJ_BreakageDetails { get; set; }
        public virtual DbSet<WJ_BreakageType> WJ_BreakageType { get; set; }
        public virtual DbSet<WJ_Check> WJ_Check { get; set; }
        public virtual DbSet<WJ_CheckDetails> WJ_CheckDetails { get; set; }
        public virtual DbSet<WJ_Movement> WJ_Movement { get; set; }
        public virtual DbSet<WJ_MovementDetails> WJ_MovementDetails { get; set; }
        public virtual DbSet<WJ_MovementType> WJ_MovementType { get; set; }
        public virtual DbSet<WJ_StockIn> WJ_StockIn { get; set; }
        public virtual DbSet<WJ_StockInDetails> WJ_StockInDetails { get; set; }
        public virtual DbSet<WJ_StockInType> WJ_StockInType { get; set; }
        public virtual DbSet<WJ_StockOut> WJ_StockOut { get; set; }
        public virtual DbSet<WJ_StockOutDetails> WJ_StockOutDetails { get; set; }
        public virtual DbSet<WJ_StockOutType> WJ_StockOutType { get; set; }
        public virtual DbSet<WJ_StockStatus> WJ_StockStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.ZName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.DepartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.BI_LocalProduct)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<BI_CusAddress>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.CusName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Customer>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BI_LocalProduct>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_LocalProduct>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<BI_LocalProduct>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_LocalProduct>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<BI_LocalProduct>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Location>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Location>()
                .Property(e => e.LocalName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Location>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Location>()
                .HasMany(e => e.BI_LocalProduct)
                .WithRequired(e => e.BI_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BI_LocaType>()
                .Property(e => e.LocalTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Measure>()
                .Property(e => e.MeasureNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Measure>()
                .Property(e => e.MeasureName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.MeasureNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .Property(e => e.CateNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.BI_LocalProduct)
                .WithRequired(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.WJ_CheckDetails)
                .WithOptional(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode });

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.WJ_MovementDetails)
                .WithOptional(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode });

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.WJ_BreakageDetails)
                .WithOptional(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode });

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.WJ_StockInDetails)
                .WithOptional(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode });

            modelBuilder.Entity<BI_Product>()
                .HasMany(e => e.WJ_StockOutDetails)
                .WithOptional(e => e.BI_Product)
                .HasForeignKey(e => new { e.SnNum, e.BarCode });

            modelBuilder.Entity<BI_ProductCategory>()
                .Property(e => e.CateNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_ProductCategory>()
                .Property(e => e.CateName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_ProductCategory>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<BI_ProductCategory>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Storage>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Storage>()
                .Property(e => e.StorageName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Storage>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.SupNum)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.SupName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Supplier>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BI_SupType>()
                .Property(e => e.SupTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepart>()
                .Property(e => e.DepartNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepart>()
                .Property(e => e.DepartName)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepart>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SysRelation>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysRelation>()
                .Property(e => e.ResNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysRelation>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ResNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ResName)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ParentNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .HasMany(e => e.SysRelation)
                .WithRequired(e => e.SysResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SysResource>()
                .HasMany(e => e.SysResource1)
                .WithOptional(e => e.SysResource2)
                .HasForeignKey(e => e.ParentNum);

            modelBuilder.Entity<SysRole>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysRole>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<SysRole>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SysRole>()
                .HasMany(e => e.SysRelation)
                .WithRequired(e => e.SysRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WJ_Breakage>()
                .Property(e => e.BreNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Breakage>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Breakage>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Breakage>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageDetails>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageDetails>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageDetails>()
                .Property(e => e.BreNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageDetails>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_BreakageType>()
                .Property(e => e.BreTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Check>()
                .Property(e => e.CheckNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Check>()
                .Property(e => e.CheckType)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Check>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Check>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Check>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_CheckDetails>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_CheckDetails>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_CheckDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_CheckDetails>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Movement>()
                .Property(e => e.MovNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Movement>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Movement>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_Movement>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementDetails>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementDetails>()
                .Property(e => e.MovNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementDetails>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementDetails>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_MovementType>()
                .Property(e => e.MovTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.StoINum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.SupNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockIn>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInDetails>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInDetails>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInDetails>()
                .Property(e => e.StoINum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInDetails>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockInType>()
                .Property(e => e.StoITypeName)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.StoONum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOut>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutDetails>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutDetails>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutDetails>()
                .Property(e => e.StoONum)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutDetails>()
                .Property(e => e.ProductLot)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockOutType>()
                .Property(e => e.StoOTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<WJ_StockStatus>()
                .Property(e => e.SSName)
                .IsUnicode(false);
        }
    }
}
