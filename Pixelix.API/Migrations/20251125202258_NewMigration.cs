using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelix.API.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "079aed2f-290b-43f0-bdc1-141cb617cf37", "AQAAAAIAAYagAAAAEEyhX5eklTEETnuPbB7ZfCJ4b+NEYHsPruCfwarNb9QhMOyaQAHo6PzugpB/cpa3Vw==", "630b7df1-269b-45fc-a331-f66eed07788f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d733cab8-c493-4a26-900f-95603de5037f", "AQAAAAIAAYagAAAAECtgZwlHcghcQxQ5IgQbFg5MzRKvHKkRX9lxNdQu8w0a5ievHrk6C54JNxiDvHKFGg==", "74a8f4b6-6b3f-436a-b391-df608ca4dd04" });
        }
    }
}
