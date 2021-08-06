using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartment.NetCoreApp.Api.Migrations
{
    public partial class ApartmentsDataMigration : Migration
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
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Apartments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApartmentTypes",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(1484), "Duplex" },
                    { 11, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2154), "Townhouse" },
                    { 10, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2152), "Condo" },
                    { 8, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2146), "Mid-rise" },
                    { 7, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2144), "High-rise" },
                    { 9, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2148), "Walk-up" },
                    { 5, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2080), "Micro Apartment" },
                    { 4, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2078), "Loft" },
                    { 3, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2075), "Quadruplex" },
                    { 2, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2052), "Triplex" },
                    { 6, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2141), "Studio" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "Name", "StateId" },
                values: new object[,]
                {
                    { 45, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(906), "South Bend/Mishawaka", 10 },
                    { 49, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(913), "DFW", 12 },
                    { 48, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(911), "Sioux City", 11 },
                    { 47, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(909), "Des Moines", 11 },
                    { 46, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(907), "Davenport", 11 },
                    { 44, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(904), "Indianapolis", 10 },
                    { 38, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(893), "Savannah", 8 },
                    { 42, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(901), "Evansville", 10 },
                    { 41, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(899), "Springfield", 9 },
                    { 40, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(897), "Moline", 9 },
                    { 39, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(896), "Chicago", 9 },
                    { 50, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(914), "Tyler", 12 },
                    { 37, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(891), "Augusta", 8 },
                    { 43, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(902), "Fort Wayne", 10 },
                    { 51, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(916), "Longview", 12 },
                    { 57, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(926), "Austin", 12 },
                    { 53, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(920), "Victoria", 12 },
                    { 67, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(945), "Wichita Falls", 12 },
                    { 66, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(943), "Harlingen", 12 },
                    { 65, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(940), "Laredo", 12 },
                    { 64, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(938), "Lubbock", 12 },
                    { 63, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(937), "Midland/Odessa", 12 },
                    { 62, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(935), "Amarillo", 12 },
                    { 52, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(918), "Houston", 12 },
                    { 61, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(933), "Abilene", 12 },
                    { 59, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(930), "I-35 Corridor", 12 },
                    { 58, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(928), "San Antonio", 12 },
                    { 36, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(890), "Macon", 8 },
                    { 56, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(925), "Lufkin", 12 },
                    { 55, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(923), "Golden Triangle", 12 },
                    { 54, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(921), "Corpus Christi", 12 },
                    { 60, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(931), "College Station", 12 },
                    { 35, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(888), "Atlanta", 8 },
                    { 34, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(886), "Albany", 8 },
                    { 33, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(883), "Orlando", 7 },
                    { 1, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9652), "Birmingham", 1 },
                    { 2, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(781), "Hunstville", 1 },
                    { 3, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(814), "Mobile", 1 },
                    { 4, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(817), "Montgomery", 1 },
                    { 5, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(818), "Flagstaff", 2 },
                    { 6, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(824), "Phoenix", 2 },
                    { 7, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(826), "Tucson", 2 },
                    { 8, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(828), "Central Coast", 3 },
                    { 9, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(831), "San Joaquin Valley", 3 },
                    { 10, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(834), "Inland Empire", 3 },
                    { 12, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(838), "San Francisco", 3 },
                    { 13, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(841), "Orange County", 3 },
                    { 14, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(842), "Sacramento", 3 },
                    { 15, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(844), "San Diego", 3 },
                    { 16, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(847), "Bay Area/San Francisco", 3 },
                    { 11, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(836), "Los Angeles", 3 },
                    { 18, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(853), "Colorado Springs", 4 },
                    { 32, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(881), "Tampa", 7 },
                    { 31, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(880), "Miami/Ft. Lauderdale", 7 },
                    { 17, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(849), "Denver", 4 },
                    { 29, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(876), "Jacksonville", 7 },
                    { 28, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(874), "Palm Beach & Boca", 7 },
                    { 27, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(873), "Melbourne & Palm Bay", 7 },
                    { 26, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(871), "Northwest Florida", 7 },
                    { 30, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(878), "Gainesville", 7 },
                    { 24, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(867), "Washington D.C.", 6 },
                    { 23, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(865), "Tolland County", 5 },
                    { 22, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(863), "New Haven County", 5 },
                    { 21, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(861), "Middlesex County", 5 },
                    { 20, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(858), "Hartford", 5 },
                    { 19, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(856), "Fairfield County", 5 },
                    { 25, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(868), "Southwest Florida", 7 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9033), "Indiana" },
                    { 9, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9030), "Illiois" },
                    { 8, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9028), "Georgia" },
                    { 7, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9026), "Florida" },
                    { 6, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9024), "District of Columbia" },
                    { 3, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9011), "California" },
                    { 4, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9015), "Colorado" },
                    { 2, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(8948), "Arizona" },
                    { 1, new DateTime(2021, 8, 6, 19, 13, 5, 536, DateTimeKind.Local).AddTicks(2723), "Alabama" },
                    { 11, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9035), "Iowa" },
                    { 5, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9017), "Connecticut" },
                    { 12, new DateTime(2021, 8, 6, 19, 13, 5, 538, DateTimeKind.Local).AddTicks(9037), "Texas" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Address", "ApartmentTypeId", "CityId", "CreatedOn", "Description", "Name", "StateId" },
                values: new object[] { 2, "10, Foster Way, Chorley, Georgia", 2, 35, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(5797), "Triplex with 5 bedrooms", "A well-furnished Triplex with 5 bedrooms", 8 });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Address", "ApartmentTypeId", "CityId", "CreatedOn", "Description", "Name", "StateId" },
                values: new object[] { 1, "22, Deena Kelly Avenue, Austin, Texas", 1, 52, new DateTime(2021, 8, 6, 19, 13, 5, 539, DateTimeKind.Local).AddTicks(2818), "Duplex with 3 bedrooms", "A well-furnished Duplex with 3 bedrooms", 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentTypeId",
                table: "Apartments",
                column: "ApartmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CityId",
                table: "Apartments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_StateId",
                table: "Apartments",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ApartmentTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
