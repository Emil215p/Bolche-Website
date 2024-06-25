using System;
using System.Collections.Generic;
using BolcheWebsite.SQLModels;
using Microsoft.EntityFrameworkCore;

namespace BolcheWebsite.SQLContext;

public partial class BolcherContext : DbContext
{
    public BolcherContext()
    {
    }

    public BolcherContext(DbContextOptions<BolcherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignedTrait> AssignedTraits { get; set; }

    public virtual DbSet<BolcheTraitName> BolcheTraitNames { get; set; }

    public virtual DbSet<BolcheTyper> BolcheTypers { get; set; }

    public virtual DbSet<BolcheView> BolcheViews { get; set; }

    public virtual DbSet<BolcheViewMediocre> BolcheViewMediocres { get; set; }

    public virtual DbSet<BolcheViewMid> BolcheViewMids { get; set; }

    public virtual DbSet<Bolcher> Bolchers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DebugBolcheView> DebugBolcheViews { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ShippingInfo> ShippingInfos { get; set; }

    public virtual DbSet<Test1> Test1s { get; set; }

    public virtual DbSet<Test2> Test2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.15.83;Initial Catalog=Bolcher;User ID=emil215p;Password=Syddanskzgyyfmgy!12;Trust Server Certificate=True");

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
            entity.HasKey(e => e.TraitNameId).HasName("PK__BolcheTr__757A478A09311987");

            entity.Property(e => e.TraitNameId).HasColumnName("TraitNameID");
            entity.Property(e => e.TraitNames).HasMaxLength(255);
        });

        modelBuilder.Entity<BolcheTyper>(entity =>
        {
            entity.HasKey(e => e.BolcheTypeId).HasName("PK__BolcheTy__32E53EF6D74A63C3");

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
            entity.Property(e => e.Smag).HasMaxLength(255);
            entity.Property(e => e.Styrke).HasMaxLength(255);
            entity.Property(e => e.Surhed).HasMaxLength(255);
        });

        modelBuilder.Entity<BolcheViewMediocre>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BolcheViewMediocre");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.BolcheTrait)
                .HasMaxLength(4000)
                .HasColumnName("Bolche Trait");
        });

        modelBuilder.Entity<BolcheViewMid>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BolcheViewMid");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.BolcheTrait)
                .HasMaxLength(255)
                .HasColumnName("Bolche Trait");
        });

        modelBuilder.Entity<Bolcher>(entity =>
        {
            entity.HasKey(e => e.BolcheId).HasName("PK__Bolcher__2BA201E04217194F");

            entity.ToTable("Bolcher");

            entity.Property(e => e.BolcheId).HasColumnName("BolcheID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7972D93B07E");

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
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B894B1A0F4");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E3DA75836").IsUnique();

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

        modelBuilder.Entity<DebugBolcheView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DebugBolcheView");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.BolcheType)
                .HasMaxLength(255)
                .HasColumnName("Bolche Type");
            entity.Property(e => e.TraitNames).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF65A43A2E");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasPrecision(3);
            entity.Property(e => e.ShippingInfoId).HasColumnName("ShippingInfoID");

            entity.HasOne(d => d.Cart).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__CartID__37A5467C");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__36B12243");

            entity.HasOne(d => d.ShippingInfo).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Shipping__38996AB5");
        });

        modelBuilder.Entity<ShippingInfo>(entity =>
        {
            entity.HasKey(e => e.ShippingInfoId).HasName("PK__Shipping__A72E5D952AC5C2FE");

            entity.ToTable("ShippingInfo");

            entity.Property(e => e.ShippingInfoId).HasColumnName("ShippingInfoID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
        });

        modelBuilder.Entity<Test1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Test 1");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.BolcheTrait)
                .HasMaxLength(255)
                .HasColumnName("Bolche Trait");
            entity.Property(e => e.TraitName2)
                .HasMaxLength(255)
                .HasColumnName("Trait Name 2");
        });

        modelBuilder.Entity<Test2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Test2");

            entity.Property(e => e.BolcheNavn)
                .HasMaxLength(255)
                .HasColumnName("Bolche Navn");
            entity.Property(e => e.BolcheTrait)
                .HasMaxLength(4000)
                .HasColumnName("Bolche Trait");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
