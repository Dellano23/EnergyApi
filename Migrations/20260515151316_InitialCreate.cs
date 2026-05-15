using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Energy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipamentoNome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Potencia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UsoMinutoDia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "CustosEquipamento",
                columns: table => new
                {
                    CustoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorKwh = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: false),
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
