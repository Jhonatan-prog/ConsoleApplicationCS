﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.Data;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("app.Models.Empresa", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Codigo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("app.Models.Factura", b =>
                {
                    b.Property<long>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Numero"));

                    b.Property<long>("CodigoCliente")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Numero");

                    b.HasIndex("CodigoCliente");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("app.Models.Persona", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Codigo"));

                    b.Property<long>("ClienteCodigo")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("ClienteCodigo");

                    b.ToTable("Persona");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("app.Models.Producto", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Codigo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("app.Models.ProductosPorFactura", b =>
                {
                    b.Property<long>("NumeroFactura")
                        .HasColumnType("bigint");

                    b.Property<long>("CodigoProducto")
                        .HasColumnType("bigint");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.HasKey("NumeroFactura", "CodigoProducto");

                    b.HasIndex("CodigoProducto");

                    b.ToTable("ProductosPorFactura");
                });

            modelBuilder.Entity("app.Models.Vendedor", b =>
                {
                    b.Property<long>("Codigo")
                        .HasColumnType("bigint");

                    b.Property<int>("Carnet")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Vendedor", (string)null);
                });

            modelBuilder.Entity("app.Models.Cliente", b =>
                {
                    b.HasBaseType("app.Models.Persona");

                    b.Property<long?>("CodigoEmpresa")
                        .HasColumnType("bigint");

                    b.Property<float>("Credito")
                        .HasColumnType("real");

                    b.HasIndex("CodigoEmpresa");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("app.Models.Factura", b =>
                {
                    b.HasOne("app.Models.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("CodigoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("app.Models.Persona", b =>
                {
                    b.HasOne("app.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("app.Models.ProductosPorFactura", b =>
                {
                    b.HasOne("app.Models.Producto", "Producto")
                        .WithMany("ProductosPorFacturas")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Factura", "Factura")
                        .WithMany("ProductosPorFacturas")
                        .HasForeignKey("NumeroFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("app.Models.Vendedor", b =>
                {
                    b.HasOne("app.Models.Persona", "Persona")
                        .WithOne("Vendedor")
                        .HasForeignKey("app.Models.Vendedor", "Codigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("app.Models.Cliente", b =>
                {
                    b.HasOne("app.Models.Persona", null)
                        .WithOne()
                        .HasForeignKey("app.Models.Cliente", "Codigo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("app.Models.Empresa", "Empresa")
                        .WithMany("Clientes")
                        .HasForeignKey("CodigoEmpresa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("app.Models.Empresa", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("app.Models.Factura", b =>
                {
                    b.Navigation("ProductosPorFacturas");
                });

            modelBuilder.Entity("app.Models.Persona", b =>
                {
                    b.Navigation("Vendedor")
                        .IsRequired();
                });

            modelBuilder.Entity("app.Models.Producto", b =>
                {
                    b.Navigation("ProductosPorFacturas");
                });

            modelBuilder.Entity("app.Models.Cliente", b =>
                {
                    b.Navigation("Facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
