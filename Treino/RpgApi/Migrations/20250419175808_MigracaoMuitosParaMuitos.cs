using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotiar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 244, 88, 49, 205, 90, 5, 95, 10, 18, 156, 158, 119, 193, 17, 140, 152, 176, 208, 73, 149, 232, 174, 125, 52, 55, 243, 66, 105, 134, 120, 222, 142, 3, 177, 30, 249, 109, 154, 124, 143, 254, 178, 143, 94, 188, 153, 48, 61, 234, 70, 213, 173, 134, 215, 120, 229, 124, 235, 34, 121, 218, 212, 98, 56 }, new byte[] { 27, 223, 244, 225, 252, 204, 175, 245, 104, 192, 228, 150, 73, 43, 125, 41, 193, 171, 4, 203, 87, 50, 137, 167, 184, 91, 185, 186, 120, 57, 152, 170, 109, 152, 196, 169, 156, 114, 203, 156, 119, 169, 21, 209, 71, 105, 137, 82, 236, 149, 226, 235, 75, 240, 251, 230, 253, 190, 52, 168, 251, 142, 248, 243, 4, 203, 54, 183, 133, 34, 111, 240, 133, 122, 17, 246, 64, 239, 32, 180, 233, 154, 22, 40, 50, 231, 250, 170, 240, 169, 130, 27, 171, 42, 73, 35, 44, 167, 123, 142, 205, 28, 192, 33, 43, 226, 115, 254, 108, 184, 248, 27, 125, 60, 196, 72, 124, 248, 168, 239, 176, 57, 254, 2, 196, 213, 209, 131 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 24, 127, 202, 131, 114, 92, 205, 32, 57, 244, 24, 195, 1, 93, 111, 36, 47, 38, 183, 116, 55, 117, 123, 223, 34, 64, 135, 223, 67, 219, 131, 213, 162, 199, 10, 234, 224, 232, 119, 78, 44, 252, 136, 13, 117, 219, 131, 193, 30, 115, 122, 178, 167, 145, 72, 170, 178, 26, 41, 2, 251, 1, 204, 168 }, new byte[] { 68, 64, 112, 188, 204, 80, 16, 127, 212, 32, 0, 255, 41, 129, 165, 103, 110, 81, 4, 253, 214, 58, 172, 249, 127, 25, 112, 121, 193, 247, 29, 217, 23, 198, 177, 154, 233, 232, 107, 239, 6, 51, 163, 207, 145, 3, 42, 245, 115, 155, 179, 238, 33, 245, 12, 61, 28, 149, 133, 17, 106, 138, 137, 193, 7, 124, 42, 225, 145, 32, 157, 132, 178, 56, 107, 65, 33, 159, 5, 193, 102, 87, 221, 13, 175, 3, 200, 155, 147, 13, 104, 52, 61, 153, 188, 159, 201, 75, 216, 148, 221, 99, 237, 78, 213, 201, 23, 174, 120, 186, 245, 76, 135, 68, 51, 137, 80, 14, 225, 228, 12, 3, 245, 97, 15, 176, 176, 162 } });
        }
    }
}
