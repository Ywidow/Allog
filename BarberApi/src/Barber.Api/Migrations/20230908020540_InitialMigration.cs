using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Barber.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    BirthdayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    CPF = table.Column<string>(type: "character(14)", fixedLength: true, maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    District = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    State = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "character(9)", fixedLength: true, maxLength: 9, nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BuyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Observations = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedulings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StartServiceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishServiceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ConfirmedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telephones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthdayDate", "CPF", "Email", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 8, 22), "181.851.057-07", "guimasthomy@gmail.com", 0, "Guilherme Thomy" },
                    { 2, new DateOnly(2023, 8, 22), "111.111.111-11", "guirosa@gmail.com", 0, "Guilherme Rosa" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CEP", "City", "CustomerId", "District", "Number", "State", "Street" },
                values: new object[,]
                {
                    { 1, "88301-650", "Itajaí", 1, "District1", 157, "SC", "Agostinho Fernandes Vieira" },
                    { 2, "11111-111", "Niterói", 1, "District2", 7, "RJ", "Avenida Presidente Roosevelt" },
                    { 3, "22222-22", "Itajaí", 2, "District3", 157, "SC", "Street1" },
                    { 4, "33333-33", "Itajaí", 2, "District4", 157, "SC", "Agostinho Fernandes Vieira" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyDate", "CustomerId", "Number", "Observations", "PaymentMethod", "Status" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 9, 7), 1, 52, "Observation1", 4, 0 },
                    { 2, new DateOnly(2023, 9, 8), 1, 53, "Observation2", 5, 0 },
                    { 3, new DateOnly(2023, 9, 9), 2, 54, "Observation3", 6, 0 },
                    { 4, new DateOnly(2023, 9, 10), 2, 55, "Observation4", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Schedulings",
                columns: new[] { "Id", "CancellationDate", "ConfirmedDate", "CustomerId", "FinishDate", "FinishServiceDate", "StartDate", "StartServiceDate", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(75), 1, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(72), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(74), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(66), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(73), 0 },
                    { 2, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(77), null, 1, null, null, null, null, 3 },
                    { 3, null, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(82), 2, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(79), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(81), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(79), new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(80), 0 },
                    { 4, new DateTime(2023, 9, 8, 2, 5, 40, 774, DateTimeKind.Utc).AddTicks(83), null, 2, null, null, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "CustomerId", "Number", "Type" },
                values: new object[,]
                {
                    { 1, 1, "+55 (47) 99238-1783", 1 },
                    { 2, 1, "+55 (47) 99999-9999", 0 },
                    { 3, 2, "+55 (47) 88888-8888", 1 },
                    { 4, 2, "+55 (47) 77777-7777", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Schedulings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_CustomerId",
                table: "Telephones",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Schedulings");

            migrationBuilder.DropTable(
                name: "Telephones");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
