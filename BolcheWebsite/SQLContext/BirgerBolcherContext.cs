using System;
using System.Collections.Generic;
using BolcheWebsite.SQLModels;
using Microsoft.EntityFrameworkCore;

namespace BolcheWebsite.SQLContext;

public partial class BirgerBolcherContext : DbContext
{
    public BirgerBolcherContext()
    {
    }

    public BirgerBolcherContext(DbContextOptions<BirgerBolcherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignedTrait> AssignedTraits { get; set; }

    public virtual DbSet<BolcheTraitName> BolcheTraitNames { get; set; }

    public virtual DbSet<BolcheTyper> BolcheTypers { get; set; }

    public virtual DbSet<BolcheView> BolcheViews { get; set; }

    public virtual DbSet<Bolcher> Bolchers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersWithBluePearl> CustomersWithBluePearls { get; set; }

    public virtual DbSet<CustomersWithOrder> CustomersWithOrders { get; set; }

    public virtual DbSet<HundredGramPri> HundredGramPris { get; set; }

    public virtual DbSet<NettoPri> NettoPris { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<ShippingInfo> ShippingInfos { get; set; }

    public virtual DbSet<TotalPri> TotalPris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BolcherConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignedTrait>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.BolcheTypeId).HasColumnName("BolcheTypeID");

            entity.HasOne(d => d.Bolche).WithMany()
                .HasForeignKey(d => d.BolcheId)
                .HasConstraintName("FK__AssignedT__Bolch__3D5E1FD2");

            entity.HasOne(d => d.BolcheType).WithMany()
                .HasForeignKey(d => d.BolcheTypeId)
                .HasConstraintName("FK__AssignedT__Bolch__3E52440B");
        });

        modelBuilder.Entity<BolcheTraitName>(entity =>
        {
            entity.HasKey(e => e.TraitNameId).HasName("PK__BolcheTr__757A478A3278BCBF");

            entity.Property(e => e.TraitNameId).HasColumnName("TraitNameID");
            entity.Property(e => e.TraitNames).HasMaxLength(255);
        });

        modelBuilder.Entity<BolcheTyper>(entity =>
        {
            entity.HasKey(e => e.BolcheTypeId).HasName("PK__BolcheTy__32E53EF6ED3D6529");

            entity.ToTable("BolcheTyper");

            entity.Property(e => e.BolcheTypeId).HasColumnName("BolcheTypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TraitNameId).HasColumnName("TraitNameID");

            entity.HasOne(d => d.TraitName).WithMany(p => p.BolcheTypers)
                .HasForeignKey(d => d.TraitNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BolcheTyp__Trait__398D8EEE");
        });

        modelBuilder.Entity<BolcheView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BolcheView");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.Farve).HasMaxLength(255);
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Smag).HasMaxLength(255);
            entity.Property(e => e.Styrke).HasMaxLength(255);
            entity.Property(e => e.Surhed).HasMaxLength(255);
            entity.Property(e => e.Vægt).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Bolcher>(entity =>
        {
            entity.HasKey(e => e.BolcheId).HasName("PK__Bolcher__2BA201E09FE7CDB6");

            entity.ToTable("Bolcher");

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD79704FE745E");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");

            entity.HasOne(d => d.Bolche).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BolcheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__BolcheID__412EB0B6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B89DE3DBF1");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E2245E20C").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.ShippingInfoId).HasColumnName("ShippingInfoID");

            entity.HasOne(d => d.ShippingInfo).WithMany(p => p.Customers)
                .HasForeignKey(d => d.ShippingInfoId)
                .HasConstraintName("FK__Customers__Shipp__46E78A0C");
        });

        modelBuilder.Entity<CustomersWithBluePearl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustomersWithBluePearls");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<CustomersWithOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustomersWithOrders");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<HundredGramPri>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("HundredGramPris");

            entity.Property(e => e.Output).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<NettoPri>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NettoPris");

            entity.Property(e => e.Output).HasColumnType("numeric(13, 3)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF9BB070ED");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasPrecision(3);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__49C3F6B7");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1C2C2CB12");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Cart).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__CartI__4D94879B");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__4CA06362");
        });

        modelBuilder.Entity<ShippingInfo>(entity =>
        {
            entity.HasKey(e => e.ShippingInfoId).HasName("PK__Shipping__A72E5D95065F3223");

            entity.ToTable("ShippingInfo");

            entity.Property(e => e.ShippingInfoId).HasColumnName("ShippingInfoID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
        });

        modelBuilder.Entity<TotalPri>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TotalPris");

            entity.Property(e => e.Output).HasColumnType("numeric(17, 5)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
