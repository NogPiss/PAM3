using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 127, 39, 155, 101, 69, 231, 60, 151, 248, 233, 107, 70, 229, 73, 2, 172, 120, 8, 3, 215, 17, 174, 121, 3, 64, 254, 83, 238, 132, 192, 197, 114, 1, 77, 19, 234, 54, 36, 248, 191, 161, 227, 187, 105, 172, 7, 111, 86, 39, 22, 65, 98, 36, 230, 46, 117, 37, 254, 78, 99, 193, 129, 29, 168 }, new byte[] { 210, 51, 167, 114, 164, 36, 165, 187, 80, 133, 187, 250, 103, 123, 185, 154, 126, 51, 137, 244, 102, 124, 253, 68, 205, 96, 58, 68, 126, 178, 250, 255, 73, 163, 131, 122, 107, 205, 135, 58, 175, 115, 239, 122, 162, 189, 32, 46, 9, 9, 112, 82, 74, 35, 119, 142, 159, 128, 218, 162, 104, 254, 84, 45, 42, 10, 195, 0, 249, 100, 33, 221, 228, 250, 162, 228, 215, 167, 31, 185, 237, 68, 0, 22, 214, 2, 48, 246, 250, 97, 16, 129, 16, 15, 71, 245, 102, 216, 229, 66, 90, 187, 42, 166, 134, 31, 173, 41, 96, 15, 200, 154, 104, 195, 161, 71, 185, 143, 75, 46, 240, 55, 3, 87, 174, 156, 161, 141 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 31, 217, 250, 60, 215, 68, 185, 78, 164, 85, 105, 71, 126, 84, 50, 11, 127, 55, 37, 177, 233, 53, 102, 124, 4, 195, 219, 220, 234, 165, 19, 27, 240, 221, 173, 216, 50, 86, 220, 111, 241, 64, 203, 170, 52, 226, 247, 218, 54, 201, 152, 32, 96, 195, 237, 135, 103, 203, 249, 108, 165, 77, 214 }, new byte[] { 200, 9, 57, 96, 173, 90, 100, 105, 194, 107, 201, 174, 189, 6, 47, 59, 223, 66, 103, 17, 129, 197, 54, 44, 152, 21, 34, 106, 43, 114, 162, 31, 105, 48, 3, 193, 228, 135, 14, 227, 125, 10, 222, 189, 179, 107, 66, 149, 6, 223, 54, 106, 69, 122, 31, 145, 96, 48, 206, 165, 91, 36, 225, 26, 248, 155, 54, 107, 152, 250, 169, 229, 9, 45, 38, 243, 190, 22, 228, 226, 151, 174, 218, 112, 209, 78, 0, 155, 214, 94, 185, 189, 22, 69, 38, 35, 154, 160, 59, 191, 4, 88, 126, 42, 53, 167, 47, 128, 163, 107, 225, 44, 49, 126, 20, 61, 151, 183, 71, 39, 185, 92, 10, 252, 184, 172, 14, 71 } });
        }
    }
}
