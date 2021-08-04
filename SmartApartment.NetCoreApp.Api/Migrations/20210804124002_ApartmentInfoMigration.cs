using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartment.NetCoreApp.Api.Migrations
{
    public partial class ApartmentInfoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApartmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barcode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApartmentTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentTypes_ApartmentTypeId",
                        column: x => x.ApartmentTypeId,
                        principalTable: "ApartmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApartmentTypes",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(2029), "Duplex" },
                    { 11, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3094), "Townhouse" },
                    { 10, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3091), "Condo" },
                    { 8, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3083), "Mid-rise" },
                    { 7, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3081), "High-rise" },
                    { 9, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3086), "Walk-up" },
                    { 5, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3070), "Micro Apartment" },
                    { 4, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3067), "Loft" },
                    { 3, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3064), "Quadruplex" },
                    { 2, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3016), "Triplex" },
                    { 6, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(3078), "Studio" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "Name", "StateId" },
                values: new object[,]
                {
                    { 45, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1199), "South Bend/Mishawaka", 10 },
                    { 49, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1211), "DFW", 12 },
                    { 48, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1208), "Sioux City", 11 },
                    { 47, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1206), "Des Moines", 11 },
                    { 46, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1203), "Davenport", 11 },
                    { 44, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1196), "Indianapolis", 10 },
                    { 38, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1179), "Savannah", 8 },
                    { 42, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1190), "Evansville", 10 },
                    { 41, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1188), "Springfield", 9 },
                    { 40, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1185), "Moline", 9 },
                    { 39, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1182), "Chicago", 9 },
                    { 50, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1214), "Tyler", 12 },
                    { 37, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1176), "Augusta", 8 },
                    { 43, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1193), "Fort Wayne", 10 },
                    { 51, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1217), "Longview", 12 },
                    { 57, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1233), "Austin", 12 },
                    { 53, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1222), "Victoria", 12 },
                    { 67, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1265), "Wichita Falls", 12 },
                    { 66, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1263), "Harlingen", 12 },
                    { 65, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1258), "Laredo", 12 },
                    { 64, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1255), "Lubbock", 12 },
                    { 63, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1253), "Midland/Odessa", 12 },
                    { 62, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1251), "Amarillo", 12 },
                    { 52, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1219), "Houston", 12 },
                    { 61, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1245), "Abilene", 12 },
                    { 59, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1239), "I-35 Corridor", 12 },
                    { 58, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1236), "San Antonio", 12 },
                    { 36, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1174), "Macon", 8 },
                    { 56, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1231), "Lufkin", 12 },
                    { 55, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1228), "Golden Triangle", 12 },
                    { 54, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1225), "Corpus Christi", 12 },
                    { 60, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1242), "College Station", 12 },
                    { 35, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1171), "Atlanta", 8 },
                    { 34, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1168), "Albany", 8 },
                    { 33, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1162), "Orlando", 7 },
                    { 1, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(9251), "Birmingham", 1 },
                    { 2, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(982), "Hunstville", 1 },
                    { 3, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1052), "Mobile", 1 },
                    { 4, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1056), "Montgomery", 1 },
                    { 5, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1060), "Flagstaff", 2 },
                    { 6, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1070), "Phoenix", 2 },
                    { 7, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1074), "Tucson", 2 },
                    { 8, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1077), "Central Coast", 3 },
                    { 9, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1080), "San Joaquin Valley", 3 },
                    { 10, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1086), "Inland Empire", 3 },
                    { 12, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1092), "San Francisco", 3 },
                    { 13, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1095), "Orange County", 3 },
                    { 14, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1098), "Sacramento", 3 },
                    { 15, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1103), "San Diego", 3 },
                    { 16, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1106), "Bay Area/San Francisco", 3 },
                    { 11, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1089), "Los Angeles", 3 },
                    { 18, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1116), "Colorado Springs", 4 },
                    { 32, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1159), "Tampa", 7 },
                    { 31, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1156), "Miami/Ft. Lauderdale", 7 },
                    { 17, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1109), "Denver", 4 },
                    { 29, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1150), "Jacksonville", 7 },
                    { 28, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1147), "Palm Beach & Boca", 7 },
                    { 27, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1144), "Melbourne & Palm Bay", 7 },
                    { 26, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1141), "Northwest Florida", 7 },
                    { 30, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1153), "Gainesville", 7 },
                    { 24, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1135), "Washington D.C.", 6 },
                    { 23, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1133), "Tolland County", 5 },
                    { 22, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1129), "New Haven County", 5 },
                    { 21, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1126), "Middlesex County", 5 },
                    { 20, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1123), "Hartford", 5 },
                    { 19, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1120), "Fairfield County", 5 },
                    { 25, new DateTime(2021, 8, 4, 13, 40, 1, 777, DateTimeKind.Local).AddTicks(1138), "Southwest Florida", 7 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8422), "Indiana" },
                    { 9, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8418), "Illiois" },
                    { 8, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8416), "Georgia" },
                    { 7, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8414), "Florida" },
                    { 6, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8412), "District of Columbia" },
                    { 3, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8336), "California" },
                    { 4, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8340), "Colorado" },
                    { 2, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8274), "Arizona" },
                    { 1, new DateTime(2021, 8, 4, 13, 40, 1, 772, DateTimeKind.Local).AddTicks(7719), "Alabama" },
                    { 11, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8424), "Iowa" },
                    { 5, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8402), "Connecticut" },
                    { 12, new DateTime(2021, 8, 4, 13, 40, 1, 776, DateTimeKind.Local).AddTicks(8426), "Texas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentTypeId",
                table: "Apartments",
                column: "ApartmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "ApartmentTypes");
        }
    }
}
