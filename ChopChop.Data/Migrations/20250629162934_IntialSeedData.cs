using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChopChop.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Main Dishes" },
                    { 2, "Desserts" },
                    { 3, "Salads" },
                    { 4, "Soups" },
                    { 5, "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedOn", "ImageUrl", "Instructions", "Title" },
                values: new object[,]
                {
                    { 1, "test-user", 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/spaghetti.jpg", "Cook pasta. In another pan, cook minced meat with tomato sauce, onion, and garlic. Combine and simmer.", "Classic Spaghetti Bolognese" },
                    { 2, "test-user", 2, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/pancakes.jpg", "Mix flour, eggs, milk, and sugar. Fry in a pan until golden on both sides. Serve with syrup.", "Easy Pancakes" },
                    { 3, "test-user", 3, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/greek_salad.jpg", "Chop cucumbers, tomatoes, olives, and feta cheese. Mix with olive oil and oregano.", "Fresh Greek Salad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
