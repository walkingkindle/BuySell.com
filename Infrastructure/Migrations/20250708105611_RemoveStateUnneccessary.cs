using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStateUnneccessary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_ShippingAddressId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "Listings",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ShippingAddressId",
                table: "Listings",
                newName: "IX_Listings_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Listings",
                newName: "ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_AddressId",
                table: "Listings",
                newName: "IX_Listings_ShippingAddressId");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_ShippingAddressId",
                table: "Listings",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
