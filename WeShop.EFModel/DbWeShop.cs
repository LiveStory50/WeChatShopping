namespace WeShop.EFModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbWeShop : DbContext
    {
        public DbWeShop()
            : base("name=DbWeShop")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChis { get; set; }
        public virtual DbSet<OrderBillFath> OrderBillFaths { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProPhoto> ProPhotoes { get; set; }
        public virtual DbSet<ProReview> ProReviews { get; set; }
        public virtual DbSet<RevPhoto> RevPhotoes { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Sort> Sorts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Account>()
                .Property(e => e.BillCode)
                .IsFixedLength();

            modelBuilder.Entity<Banner>()
                .Property(e => e.Memo)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.OpenId)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderBillFaths)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CusId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ProReviews)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShoppingCarts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notice>()
                .Property(e => e.PostUserId)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.ProCode)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.UnitPrice)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.SunPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.IsReview)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.OrderPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.ExpressPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.SumPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderBillFath>()
                .HasMany(e => e.OrderBillChis)
                .WithRequired(e => e.OrderBillFath)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.OrderBillFaths)
                .WithRequired(e => e.Payment1)
                .HasForeignKey(e => e.Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.SellPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.CostPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderBillChis)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProPhotoes)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProReviews)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShoppingCarts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stocks)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sorts)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProSort").MapLeftKey("ProCode").MapRightKey("SortCode"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProTag").MapLeftKey("ProCode").MapRightKey("TagId"));

            modelBuilder.Entity<ProPhoto>()
                .Property(e => e.ProCode)
                .IsFixedLength();

            modelBuilder.Entity<ProPhoto>()
                .Property(e => e.ImgUrl)
                .IsFixedLength();

            modelBuilder.Entity<ProReview>()
                .Property(e => e.ProCode)
                .IsFixedLength();

            modelBuilder.Entity<ProReview>()
                .Property(e => e.Body)
                .IsFixedLength();

            modelBuilder.Entity<ProReview>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<ProReview>()
                .Property(e => e.Rate)
                .IsFixedLength();

            modelBuilder.Entity<ProReview>()
                .HasMany(e => e.RevPhotoes)
                .WithRequired(e => e.ProReview)
                .HasForeignKey(e => e.RevId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevPhoto>()
                .Property(e => e.No)
                .IsFixedLength();

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.ProCode)
                .IsFixedLength();

            modelBuilder.Entity<Sort>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Stock>()
                .Property(e => e.ProCode)
                .IsFixedLength();

            modelBuilder.Entity<Stock>()
                .Property(e => e.BillCode)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
