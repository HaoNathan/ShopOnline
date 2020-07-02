using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShopOnline.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CSContext : DbContext
    {
        public CSContext()
            : base("name=CSContext")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Collect> Collect { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<FirstProductCategory> FirstProductCategory { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<PayType> PayType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductComment> ProductComment { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SecondProductCategory> SecondProductCategory { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<ThirdProductCategory> ThirdProductCategory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDistribution> UserDistribution { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
