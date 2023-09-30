using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBProducts.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateIsRemovedRecordsBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemovedRecord",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemovedRecord",
                table: "Products");
        }
    }
}
