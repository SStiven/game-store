using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddComments : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1a89a9ad-c4bf-4e56-b3e4-1f29c1ed4a66"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("3def8c3d-a340-4a83-b886-603cff5318cf"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("4df6fa1a-8ee4-4f7c-960e-899f5d90e4bf"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("76598919-f635-411b-b47c-50cdcf9d43e3"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("900f6745-025d-4eb2-a1ff-e9e7162ea090"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("a5373f44-39c4-41cc-93df-3d6b6ac9d6a5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("aa450b18-e5fb-448a-8f6e-df74bca0f418"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("aba032a7-e09f-4deb-b807-99ab085c659b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("e2079696-7a5f-48ea-8507-2cbfa33328b6"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("e7a02f23-cb7d-4571-bd10-c65db678c935"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ece41bea-230f-413f-8d31-d89708cc3112"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("2642586d-e405-434a-8134-d30481bc00f7"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("3fd79899-b275-469f-949f-4a9cae8df6bc"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("41a16a1c-4c44-4e9f-8cdb-b1cbca7e6770"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("e6569b06-4bed-449c-89bb-049387f7324c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1254c6eb-7fc2-4387-9004-c0cb46a18070"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("dbc819f1-7e7d-4830-89fd-8dc21b3f8da5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105"));

        migrationBuilder.CreateTable(
            name: "comment",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                parent_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                game_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_comment", x => x.id);
                table.ForeignKey(
                    name: "FK_comment_comment_parent_id",
                    column: x => x.parent_id,
                    principalTable: "comment",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "order",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                date = table.Column<DateTime>(type: "datetime2", nullable: true),
                customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                status = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_order", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "order_game",
            columns: table => new
            {
                order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                price = table.Column<double>(type: "float", nullable: false),
                quantity = table.Column<int>(type: "int", nullable: false),
                discount = table.Column<int>(type: "int", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_order_game", x => new { x.order_id, x.product_id });
                table.ForeignKey(
                    name: "FK_order_game_game_product_id",
                    column: x => x.product_id,
                    principalTable: "game",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_order_game_order_order_id",
                    column: x => x.order_id,
                    principalTable: "order",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("233955f3-97f1-4a31-b733-1016b2f58aea"), "RTS", null },
                { new Guid("578423cb-4d15-45fd-91ca-42faa6eaf9e4"), "Action", null },
                { new Guid("9ed5045c-c007-4453-9285-30aa791a33a9"), "Sports", null },
                { new Guid("afe885c2-f905-47ba-b1ed-fc32d18d1eb5"), "RPG", null },
                { new Guid("ce5b3d0c-1bbe-4593-a04a-a2cd9d60f094"), "Puzzle & Skill", null },
                { new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da"), "Races", null },
                { new Guid("d4d466c3-0200-4378-9254-e1187c403918"), "Adventure", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("5bd36607-8c56-40c3-9584-540f383c81ca"), "Desktop" },
                { new Guid("7f372f13-b3ea-4bca-907f-fb803b099e00"), "Console" },
                { new Guid("d9570464-f4c9-42bb-8925-7db5ce43e8a5"), "Browser" },
                { new Guid("e60e1df2-9332-4bdf-9c98-7875b258b69f"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("01c4daae-4b0b-4f26-a997-470507279c6a"), "Formula", new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da") },
                { new Guid("166dfb1c-71a0-480d-aed9-619a2d0a1b7f"), "TPS", new Guid("578423cb-4d15-45fd-91ca-42faa6eaf9e4") },
                { new Guid("2d89a567-9ffb-4b8e-975c-3980befb8d5f"), "FPS", new Guid("578423cb-4d15-45fd-91ca-42faa6eaf9e4") },
                { new Guid("927471e7-5aef-4932-a4f6-f4af71a4c3f5"), "Arcade", new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da") },
                { new Guid("9292257d-e7d4-401b-b672-19ab1fb2ef15"), "TBS", new Guid("233955f3-97f1-4a31-b733-1016b2f58aea") },
                { new Guid("cbd4bd73-0ff6-4f1b-82fc-ad202e2a2578"), "Off-road", new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da") },
                { new Guid("e4000144-3ad2-46c1-80ea-d94d9b3866aa"), "Rally", new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da") },
            });

        migrationBuilder.CreateIndex(
            name: "IX_comment_parent_id",
            table: "comment",
            column: "parent_id");

        migrationBuilder.CreateIndex(
            name: "IX_order_game_product_id",
            table: "order_game",
            column: "product_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "comment");

        migrationBuilder.DropTable(
            name: "order_game");

        migrationBuilder.DropTable(
            name: "order");

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("01c4daae-4b0b-4f26-a997-470507279c6a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("166dfb1c-71a0-480d-aed9-619a2d0a1b7f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("2d89a567-9ffb-4b8e-975c-3980befb8d5f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("927471e7-5aef-4932-a4f6-f4af71a4c3f5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("9292257d-e7d4-401b-b672-19ab1fb2ef15"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("9ed5045c-c007-4453-9285-30aa791a33a9"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("afe885c2-f905-47ba-b1ed-fc32d18d1eb5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("cbd4bd73-0ff6-4f1b-82fc-ad202e2a2578"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ce5b3d0c-1bbe-4593-a04a-a2cd9d60f094"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("d4d466c3-0200-4378-9254-e1187c403918"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("e4000144-3ad2-46c1-80ea-d94d9b3866aa"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("5bd36607-8c56-40c3-9584-540f383c81ca"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("7f372f13-b3ea-4bca-907f-fb803b099e00"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("d9570464-f4c9-42bb-8925-7db5ce43e8a5"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("e60e1df2-9332-4bdf-9c98-7875b258b69f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("233955f3-97f1-4a31-b733-1016b2f58aea"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("578423cb-4d15-45fd-91ca-42faa6eaf9e4"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("cf8bc634-0847-4d97-aad4-9b34f6a196da"));

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("1254c6eb-7fc2-4387-9004-c0cb46a18070"), "RTS", null },
                { new Guid("1a89a9ad-c4bf-4e56-b3e4-1f29c1ed4a66"), "RPG", null },
                { new Guid("3def8c3d-a340-4a83-b886-603cff5318cf"), "Puzzle & Skill", null },
                { new Guid("4df6fa1a-8ee4-4f7c-960e-899f5d90e4bf"), "Adventure", null },
                { new Guid("dbc819f1-7e7d-4830-89fd-8dc21b3f8da5"), "Action", null },
                { new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105"), "Races", null },
                { new Guid("ece41bea-230f-413f-8d31-d89708cc3112"), "Sports", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("2642586d-e405-434a-8134-d30481bc00f7"), "Browser" },
                { new Guid("3fd79899-b275-469f-949f-4a9cae8df6bc"), "Console" },
                { new Guid("41a16a1c-4c44-4e9f-8cdb-b1cbca7e6770"), "Desktop" },
                { new Guid("e6569b06-4bed-449c-89bb-049387f7324c"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("76598919-f635-411b-b47c-50cdcf9d43e3"), "FPS", new Guid("dbc819f1-7e7d-4830-89fd-8dc21b3f8da5") },
                { new Guid("900f6745-025d-4eb2-a1ff-e9e7162ea090"), "Off-road", new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105") },
                { new Guid("a5373f44-39c4-41cc-93df-3d6b6ac9d6a5"), "TBS", new Guid("1254c6eb-7fc2-4387-9004-c0cb46a18070") },
                { new Guid("aa450b18-e5fb-448a-8f6e-df74bca0f418"), "Formula", new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105") },
                { new Guid("aba032a7-e09f-4deb-b807-99ab085c659b"), "TPS", new Guid("dbc819f1-7e7d-4830-89fd-8dc21b3f8da5") },
                { new Guid("e2079696-7a5f-48ea-8507-2cbfa33328b6"), "Rally", new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105") },
                { new Guid("e7a02f23-cb7d-4571-bd10-c65db678c935"), "Arcade", new Guid("e73c7ff1-67be-47f6-b42a-0a80ec26e105") },
            });
    }
}
