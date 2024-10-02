using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Credito = table.Column<float>(type: "real", nullable: false),
                    CodigoEmpresa = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Cliente_Empresa_CodigoEmpresa",
                        column: x => x.CodigoEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    CodigoCliente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Cliente",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteCodigo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Persona_Cliente_ClienteCodigo",
                        column: x => x.ClienteCodigo,
                        principalTable: "Cliente",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosPorFactura",
                columns: table => new
                {
                    NumeroFactura = table.Column<long>(type: "bigint", nullable: false),
                    CodigoProducto = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPorFactura", x => new { x.NumeroFactura, x.CodigoProducto });
                    table.ForeignKey(
                        name: "FK_ProductosPorFactura_Factura_NumeroFactura",
                        column: x => x.NumeroFactura,
                        principalTable: "Factura",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosPorFactura_Producto_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Producto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Carnet = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Vendedor_Persona_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Persona",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CodigoEmpresa",
                table: "Cliente",
                column: "CodigoEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_CodigoCliente",
                table: "Factura",
                column: "CodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ClienteCodigo",
                table: "Persona",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPorFactura_CodigoProducto",
                table: "ProductosPorFactura",
                column: "CodigoProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Persona_Codigo",
                table: "Cliente",
                column: "Codigo",
                principalTable: "Persona",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Empresa_CodigoEmpresa",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Persona_Codigo",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "ProductosPorFactura");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
