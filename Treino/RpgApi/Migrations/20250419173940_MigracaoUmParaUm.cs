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
                name: "Victorias",
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
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Victorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 24, 127, 202, 131, 114, 92, 205, 32, 57, 244, 24, 195, 1, 93, 111, 36, 47, 38, 183, 116, 55, 117, 123, 223, 34, 64, 135, 223, 67, 219, 131, 213, 162, 199, 10, 234, 224, 232, 119, 78, 44, 252, 136, 13, 117, 219, 131, 193, 30, 115, 122, 178, 167, 145, 72, 170, 178, 26, 41, 2, 251, 1, 204, 168 }, new byte[] { 68, 64, 112, 188, 204, 80, 16, 127, 212, 32, 0, 255, 41, 129, 165, 103, 110, 81, 4, 253, 214, 58, 172, 249, 127, 25, 112, 121, 193, 247, 29, 217, 23, 198, 177, 154, 233, 232, 107, 239, 6, 51, 163, 207, 145, 3, 42, 245, 115, 155, 179, 238, 33, 245, 12, 61, 28, 149, 133, 17, 106, 138, 137, 193, 7, 124, 42, 225, 145, 32, 157, 132, 178, 56, 107, 65, 33, 159, 5, 193, 102, 87, 221, 13, 175, 3, 200, 155, 147, 13, 104, 52, 61, 153, 188, 159, 201, 75, 216, 148, 221, 99, 237, 78, 213, 201, 23, 174, 120, 186, 245, 76, 135, 68, 51, 137, 80, 14, 225, 228, 12, 3, 245, 97, 15, 176, 176, 162 } });

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
                name: "Victorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 82, 152, 70, 214, 27, 141, 196, 145, 24, 146, 116, 64, 121, 62, 21, 254, 212, 66, 123, 115, 221, 174, 210, 206, 42, 89, 46, 151, 237, 208, 93, 172, 185, 238, 135, 61, 40, 208, 156, 163, 233, 237, 75, 45, 4, 92, 122, 221, 138, 92, 206, 214, 40, 7, 109, 217, 193, 108, 174, 44, 76, 175, 51, 104 }, new byte[] { 174, 183, 187, 215, 199, 28, 139, 252, 66, 238, 112, 171, 26, 209, 70, 43, 110, 219, 190, 48, 1, 133, 216, 116, 249, 89, 88, 67, 50, 169, 176, 6, 112, 42, 202, 239, 2, 191, 249, 20, 219, 251, 103, 169, 140, 173, 250, 168, 144, 195, 102, 16, 4, 215, 13, 5, 145, 91, 186, 63, 127, 215, 44, 190, 78, 190, 148, 211, 79, 167, 14, 29, 201, 118, 90, 231, 57, 181, 163, 150, 251, 148, 12, 18, 159, 242, 117, 56, 183, 35, 94, 216, 176, 219, 53, 108, 197, 17, 46, 216, 100, 157, 57, 2, 17, 113, 109, 145, 152, 23, 29, 215, 198, 109, 146, 177, 250, 66, 44, 220, 69, 73, 78, 147, 82, 219, 29, 58 } });
        }
    }
}
