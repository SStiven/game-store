using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddOrders : Migration
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
            name: "order",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                data = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                { new Guid("324c098d-3c39-4a6d-a37c-47a042c850d0"), "RTS", null },
                { new Guid("51f7b426-3644-40d8-8d1c-f8295c2a9da1"), "Action", null },
                { new Guid("7e1287c4-804d-4bdd-9d09-e132beffd7dd"), "Adventure", null },
                { new Guid("8f1de765-9132-4ac9-b0bf-3b0102951a8f"), "Sports", null },
                { new Guid("94230625-8f65-421d-8521-b6f92c22f39c"), "RPG", null },
                { new Guid("9f3abf3b-c3d0-41bb-b925-82d018ca9074"), "Puzzle & Skill", null },
                { new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9"), "Races", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("32f8c5db-be1c-4d5c-8df7-7eb1bf00cc4d"), "Browser" },
                { new Guid("5ad354f4-13fb-482a-b0ff-12e79c0b7474"), "Console" },
                { new Guid("a30dcbd2-6107-42d4-a884-52f971d7dc6c"), "Desktop" },
                { new Guid("ad9fed5c-0a8b-4535-a9fc-93b0361f1354"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("38ba7126-80c5-4011-a62d-b6a7c5e03d70"), "Formula", new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9") },
                { new Guid("3965ff49-822f-4a57-9a66-197b9222cf9a"), "FPS", new Guid("51f7b426-3644-40d8-8d1c-f8295c2a9da1") },
                { new Guid("7057d1e6-e2b4-4781-b971-a42ba98e9980"), "TPS", new Guid("51f7b426-3644-40d8-8d1c-f8295c2a9da1") },
                { new Guid("a1ba50a4-8409-4f2b-b2bc-936bc6b811c1"), "Off-road", new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9") },
                { new Guid("ae7edb24-ae01-4f13-9c67-558850896fda"), "TBS", new Guid("324c098d-3c39-4a6d-a37c-47a042c850d0") },
                { new Guid("ca517ffc-e948-4028-8d6d-4517c62a9b1a"), "Arcade", new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9") },
                { new Guid("d6fe40c9-0882-4cbb-a484-a3a969adb769"), "Rally", new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9") },
            });

        migrationBuilder.CreateIndex(
            name: "IX_order_game_product_id",
            table: "order_game",
            column: "product_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "order_game");

        migrationBuilder.DropTable(
            name: "order");

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("38ba7126-80c5-4011-a62d-b6a7c5e03d70"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("3965ff49-822f-4a57-9a66-197b9222cf9a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("7057d1e6-e2b4-4781-b971-a42ba98e9980"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("7e1287c4-804d-4bdd-9d09-e132beffd7dd"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("8f1de765-9132-4ac9-b0bf-3b0102951a8f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("94230625-8f65-421d-8521-b6f92c22f39c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("9f3abf3b-c3d0-41bb-b925-82d018ca9074"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("a1ba50a4-8409-4f2b-b2bc-936bc6b811c1"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ae7edb24-ae01-4f13-9c67-558850896fda"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ca517ffc-e948-4028-8d6d-4517c62a9b1a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("d6fe40c9-0882-4cbb-a484-a3a969adb769"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("32f8c5db-be1c-4d5c-8df7-7eb1bf00cc4d"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("5ad354f4-13fb-482a-b0ff-12e79c0b7474"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("a30dcbd2-6107-42d4-a884-52f971d7dc6c"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("ad9fed5c-0a8b-4535-a9fc-93b0361f1354"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("324c098d-3c39-4a6d-a37c-47a042c850d0"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("51f7b426-3644-40d8-8d1c-f8295c2a9da1"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("a2f06067-05a1-4be6-92d5-a37c6c3639f9"));

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
