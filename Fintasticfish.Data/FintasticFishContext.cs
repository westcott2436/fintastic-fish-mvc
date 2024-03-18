﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FintasticFish.Data.Entities;

namespace FintasticFish.Data;

public partial class FintasticFishContext : DbContext
{
    public FintasticFishContext()// Work around for creating controllers.
    {
            
    }

    public FintasticFishContext(DbContextOptions<FintasticFishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<AggressionLevel> AggressionLevels { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersAddress> CustomersAddresses { get; set; }

    public virtual DbSet<Fish> Fishes { get; set; }

    public virtual DbSet<FishesFood> FishesFoods { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodType> FoodTypes { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrdersFish> OrdersFishes { get; set; }

    public virtual DbSet<OrdersFood> OrdersFoods { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierType> SupplierTypes { get; set; }

    public virtual DbSet<WaterType> WaterTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Street1)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Street2)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_AddressTypes");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Countries");

            entity.HasOne(d => d.State).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_States");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<AggressionLevel>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<CustomersAddress>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Address).WithMany()
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomersAddresses_Addresses");

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomersAddresses_Customers");
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Image).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Species)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.AggressionLevel).WithMany(p => p.Fish)
                .HasForeignKey(d => d.AggressionLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fishes_AggressionLevels");

            entity.HasOne(d => d.Country).WithMany(p => p.Fish)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fishes_Countries");

            entity.HasOne(d => d.Measurement).WithMany(p => p.Fish)
                .HasForeignKey(d => d.MeasurementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fishes_Measurements");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Fish)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fishes_Suppliers");

            entity.HasOne(d => d.WaterType).WithMany(p => p.Fish)
                .HasForeignKey(d => d.WaterTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fishes_WaterType");
        });

        modelBuilder.Entity<FishesFood>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Fish).WithMany()
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FishesFoods_Fishes");

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FishesFoods_Foods");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.FoodType).WithMany(p => p.Foods)
                .HasForeignKey(d => d.FoodTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Foods_FoodTypes");

            entity.HasOne(d => d.Mearsurement).WithMany(p => p.Foods)
                .HasForeignKey(d => d.MearsurementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Foods_Measurements");
        });

        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Addresses");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customers");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderStatuses1");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<OrdersFish>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Fish).WithMany()
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersFishes_Fishes");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersFishes_Order");
        });

        modelBuilder.Entity<OrdersFood>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersFoods_Foods");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersFoods_Order");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.ContactName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Notes)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Website)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suppliers_Countries");

            entity.HasOne(d => d.SupplierType).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suppliers_Suppliers");
        });

        modelBuilder.Entity<SupplierType>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<WaterType>(entity =>
        {
            entity.ToTable("WaterType");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}