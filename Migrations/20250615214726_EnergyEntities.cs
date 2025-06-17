using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Energy.Migrations
{
    /// <inheritdoc />
    public partial class EnergyEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EquipamentoNome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Potencia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UsoMinutoDia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "CustosEquipamento",
                columns: table => new
                {
                    CustoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ValorKwh = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    EquipamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CustoEquipamentoDia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CustoEquipamentoMensal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustosEquipamento", x => x.CustoId);
                    table.ForeignKey(
                        name: "FK_CustosEquipamento_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustosEquipamento_EquipamentoId",
                table: "CustosEquipamento",
                column: "EquipamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustosEquipamento");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
