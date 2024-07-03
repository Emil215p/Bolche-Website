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
                .HasConstraintName("FK__AssignedT__Bolch__2A4B4B5E");

            entity.HasOne(d => d.BolcheType).WithMany()
                .HasForeignKey(d => d.BolcheTypeId)
                .HasConstraintName("FK__AssignedT__Bolch__2B3F6F97");
        });

        modelBuilder.Entity<BolcheTraitName>(entity =>
        {
            entity.HasKey(e => e.TraitNameId).HasName("PK__BolcheTr__757A478ADB0E7043");

            entity.Property(e => e.TraitNameId).HasColumnName("TraitNameID");
            entity.Property(e => e.TraitNames).HasMaxLength(255);
        });

        modelBuilder.Entity<BolcheTyper>(entity =>
        {
            entity.HasKey(e => e.BolcheTypeId).HasName("PK__BolcheTy__32E53EF696BF2406");

            entity.ToTable("BolcheTyper");

            entity.Property(e => e.BolcheTypeId).HasColumnName("BolcheTypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TraitNameId).HasColumnName("TraitNameID");

            entity.HasOne(d => d.TraitName).WithMany(p => p.BolcheTypers)
                .HasForeignKey(d => d.TraitNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BolcheTyp__Trait__267ABA7A");
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
            entity.HasKey(e => e.BolcheId).HasName("PK__Bolcher__2BA201E09CA4A5B9");

            entity.ToTable("Bolcher");

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD79758685016");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");

            entity.HasOne(d => d.Bolche).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BolcheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__BolcheID__2E1BDC42");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B82B625A14");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E3B262A89").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.ShippingInfoId).HasColumnName("ShippingInfoID");

            entity.HasOne(d => d.ShippingInfo).WithMany(p => p.Customers)
                .HasForeignKey(d => d.ShippingInfoId)
                .HasConstraintName("FK__Customers__Shipp__33D4B598");
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
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF79026504");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasPrecision(3);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__36B12243");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A13E6203A9");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Cart).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__CartI__3A81B327");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__398D8EEE");
        });

        modelBuilder.Entity<ShippingInfo>(entity =>
        {
            entity.HasKey(e => e.ShippingInfoId).HasName("PK__Shipping__A72E5D95187236BF");

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
