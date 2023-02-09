using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Campañas.Models;

public partial class CampañasContext : DbContext
{
    public CampañasContext()
    {
    }

    public CampañasContext(DbContextOptions<CampañasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PDerogadoModel> PDerogado { get; set; }

    public virtual DbSet<PContratoModel> PContrato { get; set; }

    public virtual DbSet<PAjustadoModel> PAjustado { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("pk_idCliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apPaterno");
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("pk_id");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApMaterno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apMaterno");
            entity.Property(e => e.ApPaterno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apPaterno");
            entity.Property(e => e.Contra)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contra");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("pk_idMarca");

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cliente_Marca");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Empleado_Marca");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("pk_idMovimiento");

            entity.ToTable("Movimiento");

            entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");
            entity.Property(e => e.Concepto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.Factura)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("factura");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Gasto)
                .HasColumnType("money")
                .HasColumnName("gasto");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.Impuestos)
                .HasColumnType("money")
                .HasColumnName("impuestos");
            entity.Property(e => e.Mes)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mes");
            entity.Property(e => e.NotaCredito)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("notaCredito");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Empleado_Movimiento");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Marca_Movimiento");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pago_Movimiento");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("pk_idPago");

            entity.ToTable("Pago");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
