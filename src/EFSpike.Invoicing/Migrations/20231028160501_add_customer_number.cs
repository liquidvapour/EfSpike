using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSpike.Invoicing.Migrations
{
    /// <inheritdoc />
    public partial class add_customer_number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "Invoices");
        }
    }
}
