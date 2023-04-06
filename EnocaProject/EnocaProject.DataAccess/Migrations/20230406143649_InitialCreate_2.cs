using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnocaProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierConfigurationId",
                table: "Carriers");

            migrationBuilder.RenameColumn(
                name: "CarrierConfigurationId",
                table: "CarrierConfigurations",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarrierConfigurations",
                newName: "CarrierConfigurationId");

            migrationBuilder.AddColumn<int>(
                name: "CarrierConfigurationId",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
