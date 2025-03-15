using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinylStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addrolesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemEntity_Orders_OrderId",
                table: "OrderItemEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemEntity_VinylPlates_VinylPlateId",
                table: "OrderItemEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_RoleId",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleEntity_RoleEntity_RoleId",
                table: "UserRoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleEntity",
                table: "RoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemEntity",
                table: "OrderItemEntity");

            migrationBuilder.RenameTable(
                name: "RoleEntity",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "OrderItemEntity",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemEntity_VinylPlateId",
                table: "OrderItems",
                newName: "IX_OrderItems_VinylPlateId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemEntity_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_VinylPlates_VinylPlateId",
                table: "OrderItems",
                column: "VinylPlateId",
                principalTable: "VinylPlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_Roles_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleEntity_Roles_RoleId",
                table: "UserRoleEntity",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_VinylPlates_VinylPlateId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_Roles_RoleId",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleEntity_Roles_RoleId",
                table: "UserRoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "RoleEntity");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItemEntity");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_VinylPlateId",
                table: "OrderItemEntity",
                newName: "IX_OrderItemEntity_VinylPlateId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItemEntity",
                newName: "IX_OrderItemEntity_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleEntity",
                table: "RoleEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemEntity",
                table: "OrderItemEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemEntity_Orders_OrderId",
                table: "OrderItemEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemEntity_VinylPlates_VinylPlateId",
                table: "OrderItemEntity",
                column: "VinylPlateId",
                principalTable: "VinylPlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_RoleEntity_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId",
                principalTable: "RoleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleEntity_RoleEntity_RoleId",
                table: "UserRoleEntity",
                column: "RoleId",
                principalTable: "RoleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
