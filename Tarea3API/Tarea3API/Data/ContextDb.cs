using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Tarea3API.Models;


namespace Tarea3API.Data
{
    public partial class ContextDb : DbContext
    {
        public ContextDb() 
        { 
        }
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("name=SQLServerConnection");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedor__08A0EBDE3D5422F1");
                entity.ToTable("Proveedor");
            });


            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductoId).HasName("PK__Producto__5F8383560E8BF52B");

                entity.ToTable("Producto");

                entity.Property(e => e.FechaCaducidad).HasColumnType("date");
                entity.Property(e => e.FechaFabricacion).HasColumnType("date");
                entity.Property(e => e.FechaIngreso).HasColumnType("date");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(p => p.Proveedor).WithMany(p=> p.Productos)
                .HasForeignKey(b => b.ProveedorId)
                .HasConstraintName("FK__Producto__Proveedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
