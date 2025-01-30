using GimpiesBlazor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GimpiesBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<StockType> StockTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.FkRoleId, rp.FkPermissionId });


            // Max lengths
            //modelBuilder.Entity<Account>().Property(a => a.Username).HasMaxLength(50);
            //modelBuilder.Entity<Account>().Property(a => a.Email).HasMaxLength(50);
            //modelBuilder.Entity<Account>().Property(a => a.PasswordHash).HasMaxLength(255);
            //modelBuilder.Entity<Brand>().Property(b => b.Name).HasMaxLength(50);
            //modelBuilder.Entity<Color>().Property(c => c.Name).HasMaxLength(50);
            //modelBuilder.Entity<Permission>().Property(p => p.Name).HasMaxLength(50);
            //modelBuilder.Entity<Role>().Property(r => r.RoleName).HasMaxLength(50);
            //modelBuilder.Entity<Stock>().Property(s => s.Type).HasMaxLength(50);

            // Primary keys
            //modelBuilder.Entity<Stock>().HasKey(s => s.StockId);
            //modelBuilder.Entity<Sale>().HasKey(s => s.SaleId);
            //modelBuilder.Entity<Account>().HasKey(s => s.AccountId);
            //modelBuilder.Entity<Brand>().HasKey(s => s.BrandId);
            //modelBuilder.Entity<Color>().HasKey(s => s.ColorId);
            //modelBuilder.Entity<Permission>().HasKey(p => p.PermissionId);
            //modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            //modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.FkRoleId, rp.FkPermissionId });

            // Foreign keys
            //modelBuilder.Entity<Stock>().HasOne(s => s.Color).WithMany().HasForeignKey(s => s.FkColorId);
            //modelBuilder.Entity<Stock>().HasOne(s => s.Brand).WithMany().HasForeignKey(s => s.FkBrandId);
            //modelBuilder.Entity<Sale>().HasOne(s => s.Account).WithMany().HasForeignKey(s => s.FkAccountId);
            //modelBuilder.Entity<Sale>().HasOne(s => s.Stock).WithMany().HasForeignKey(s => s.FkStockId);
            //modelBuilder.Entity<Account>().HasOne(a => a.Role).WithMany().HasForeignKey(a => a.FkRoleId);
            //modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Role).WithMany(r => r.RolePermissions).HasForeignKey(rp => rp.FkRoleId);
            //modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Permission).WithMany(p => p.RolePermissions).HasForeignKey(rp => rp.FkPermissionId);

            // Precision for decimal
            //modelBuilder.Entity<Stock>().Property(s => s.Price).HasPrecision(18, 2);
            //modelBuilder.Entity<Sale>().Property(s => s.TotalSalePrice).HasPrecision(18, 2);

            // Unique
            modelBuilder.Entity<Account>().HasIndex(a => a.Username).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a => a.Email).IsUnique();
        }
    }
}