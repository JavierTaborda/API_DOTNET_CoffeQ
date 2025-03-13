using System;
using System.Collections.Generic;
using API_CoffeQ.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CoffeQ.Context;

public partial class CafetinContext : DbContext
{
    public CafetinContext()
    {
    }

    public CafetinContext(DbContextOptions<CafetinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__Clientes__71ABD0A7D589E87F");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Cedula, "UQ__Clientes__B4ADFE38E7C34326").IsUnique();

            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Consumos__206D9CC6B0020933");

            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.IdOrderDetail).HasName("PK__PagosPro__19F35CBCCEE1E778");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DatePaid).HasColumnType("datetime");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("PK__Pagos__F00B6158B78EAFFA");

            entity.ToTable("Payment");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.Ref)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_Payment_Order");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.IdPermission);

            entity.Property(e => e.IdPermission).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Producto__A430AE8315E10B65");

            entity.ToTable("Product");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
