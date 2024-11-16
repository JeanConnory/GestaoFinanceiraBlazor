using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations.Data
{
    /// <inheritdoc />
    public partial class DatabaseV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepeatGroup",
                table: "FinancialTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatGroup",
                table: "FinancialTransactions");
        }
    }
}
