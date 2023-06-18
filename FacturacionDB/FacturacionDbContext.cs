using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacturacionDB;

public partial class FacturacionDbContext : DbContext
{
    public FacturacionDbContext()
    {
    }

    public FacturacionDbContext(DbContextOptions<FacturacionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<LineaFactura> LineaFacturas { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<ProductoServicio> ProductoServicios { get; set; }

    public virtual DbSet<RegistroPago> RegistroPagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AI06HEJ8;Database=FacturacionDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__EB683FB44EF56E5E");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("Cliente_ID");
            entity.Property(e => e.Dirección)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Teléfono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__EC60A3C5123DB1A5");

            entity.ToTable("Factura");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("Factura_ID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado_Pago");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("date")
                .HasColumnName("Fecha_Emision");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.ImporteTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Importe_Total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Factura__Cliente__3B75D760");
        });

        modelBuilder.Entity<LineaFactura>(entity =>
        {
            entity.HasKey(e => e.LineaFacturaId).HasName("PK__Linea_Fa__ACED14431A7C3F5A");

            entity.ToTable("Linea_Factura");

            entity.Property(e => e.LineaFacturaId)
                .ValueGeneratedNever()
                .HasColumnName("Linea_Factura_ID");
            entity.Property(e => e.Descripción)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");
            entity.Property(e => e.ImporteTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Importe_Total");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Unitario");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

            entity.HasOne(d => d.Factura).WithMany(p => p.LineaFacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__Linea_Fac__Factu__3E52440B");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaFacturas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Linea_Fac__Produ__3F466844");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.MetodoId).HasName("PK__Metodos___CC01DD03902F4F3C");

            entity.ToTable("Metodos_Pago");

            entity.Property(e => e.MetodoId)
                .ValueGeneratedNever()
                .HasColumnName("Metodo_ID");
            entity.Property(e => e.NombreMetodo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Metodo");
        });

        modelBuilder.Entity<ProductoServicio>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__9F1B153D741F1FE8");

            entity.ToTable("Producto_Servicio");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("Producto_ID");
            entity.Property(e => e.Descripción)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Unit");
        });

        modelBuilder.Entity<RegistroPago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Registro__6A1940A1C00F371E");

            entity.ToTable("Registro_Pagos");

            entity.Property(e => e.PagoId)
                .ValueGeneratedNever()
                .HasColumnName("Pago_ID");
            entity.Property(e => e.CantidadPagada)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Cantidad_Pagada");
            entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");
            entity.Property(e => e.FechaPago)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.MetodoId).HasColumnName("Metodo_ID");

            entity.HasOne(d => d.Factura).WithMany(p => p.RegistroPagos)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__Registro___Factu__440B1D61");

            entity.HasOne(d => d.Metodo).WithMany(p => p.RegistroPagos)
                .HasForeignKey(d => d.MetodoId)
                .HasConstraintName("FK__Registro___Metod__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
