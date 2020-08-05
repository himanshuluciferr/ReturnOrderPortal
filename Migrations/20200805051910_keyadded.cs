using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReturnOrderPortal.Migrations
{
    public partial class keyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessDb",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessingCharge = table.Column<int>(nullable: false),
                    PackagingAndDeliveryCharge = table.Column<int>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDb", x => x.RequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessDb");
        }
    }
}
