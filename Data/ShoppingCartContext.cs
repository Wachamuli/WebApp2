#nullable disable
using Microsoft.EntityFrameworkCore;
using CarCrud.Models;

namespace CarCrud.Data
{
    public partial class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
        {
        }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BodyWork)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bodyWork");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Chassis)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("chassis");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Engine)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("engine");

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("height");

                entity.Property(e => e.Kind)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kind");

                entity.Property(e => e.MarkId).HasColumnName("markId");

                entity.Property(e => e.MaxStock).HasColumnName("maxStock");

                entity.Property(e => e.MinStock).HasColumnName("minStock");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberOfPassages).HasColumnName("numberOfPassages");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(260)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Sunroof).HasColumnName("sunroof");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.Tire)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tire");

                entity.Property(e => e.Wheels)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("wheels");

                entity.Property(e => e.Width)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("width");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__car__categoryId__37A5467C");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.MarkId)
                    .HasConstraintName("FK__car__markId__38996AB5");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__car__supplierId__398D8EEE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("mark");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Website)
                    .HasMaxLength(2083)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}