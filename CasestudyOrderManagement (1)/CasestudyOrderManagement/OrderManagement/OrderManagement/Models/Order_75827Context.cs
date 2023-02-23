using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrderManagement.Models
{
    public partial class Order_75827Context : DbContext
    {
        public Order_75827Context()
        {
        }

        public Order_75827Context(DbContextOptions<Order_75827Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=Order_75827;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart__ProductId__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart__UserId__2E1BDC42");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.ToTable("Order_items");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_ite__Order__2C3393D0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_ite__Produ__2D27B809");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserId__2B3F6F97");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
