using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddPublisher : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1336a4e6-e3ca-4fd4-bfc6-8b67c9e56194"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1ecc7b7f-fd52-4182-9716-468ac5f8695a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("6b13972d-fbd9-4a7f-9e2a-d98bfd452840"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("6bc24937-2beb-41b7-a95f-7c00aa5d5228"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("70a73e9f-9b73-4740-bdca-2b1408cfda03"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("7bb18dd0-453c-4ad2-8028-fc9619032dde"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("8282fc45-5d9b-4e48-abd7-b66f5c471361"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("bcf4ec2a-ef6e-4167-9bc2-bca7b7f5d3a9"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("bd8a7bed-5979-4600-bda4-757a93cd2771"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("d360ef8a-8272-4d7a-9797-0cb117cab398"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("f4ed662f-f1e9-4e17-a6d7-46b9371bbd57"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("027eec94-73fd-4d04-8219-2a63b8d85cca"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("22f409cd-f783-4738-9875-e520d5c62d42"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("578e223f-82da-4c58-99c2-219e72ddba19"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("e5bd3bec-2c19-4672-9f15-cd47aa277bfe"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a"));

        migrationBuilder.AddColumn<int>(
            name: "discount",
            table: "game",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<double>(
            name: "price",
            table: "game",
            type: "float",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.AddColumn<Guid>(
            name: "publisher_id",
            table: "game",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<int>(
            name: "unit_in_stock",
            table: "game",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            name: "publisher",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                company_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                home_page = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_publisher", x => x.id);
            });

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

        migrationBuilder.CreateIndex(
            name: "IX_game_publisher_id",
            table: "game",
            column: "publisher_id");

        migrationBuilder.CreateIndex(
            name: "IX_publisher_company_name",
            table: "publisher",
            column: "company_name",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_game_publisher_publisher_id",
            table: "game",
            column: "publisher_id",
            principalTable: "publisher",
            principalColumn: "id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_game_publisher_publisher_id",
            table: "game");

        migrationBuilder.DropTable(
            name: "publisher");

        migrationBuilder.DropIndex(
            name: "IX_game_publisher_id",
            table: "game");

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

        migrationBuilder.DropColumn(
            name: "discount",
            table: "game");

        migrationBuilder.DropColumn(
            name: "price",
            table: "game");

        migrationBuilder.DropColumn(
            name: "publisher_id",
            table: "game");

        migrationBuilder.DropColumn(
            name: "unit_in_stock",
            table: "game");

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("1336a4e6-e3ca-4fd4-bfc6-8b67c9e56194"), "RPG", null },
                { new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555"), "Races", null },
                { new Guid("6bc24937-2beb-41b7-a95f-7c00aa5d5228"), "Sports", null },
                { new Guid("8282fc45-5d9b-4e48-abd7-b66f5c471361"), "Puzzle & Skill", null },
                { new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4"), "RTS", null },
                { new Guid("bcf4ec2a-ef6e-4167-9bc2-bca7b7f5d3a9"), "Adventure", null },
                { new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a"), "Action", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("027eec94-73fd-4d04-8219-2a63b8d85cca"), "Desktop" },
                { new Guid("22f409cd-f783-4738-9875-e520d5c62d42"), "Console" },
                { new Guid("578e223f-82da-4c58-99c2-219e72ddba19"), "Browser" },
                { new Guid("e5bd3bec-2c19-4672-9f15-cd47aa277bfe"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("1ecc7b7f-fd52-4182-9716-468ac5f8695a"), "Arcade", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("6b13972d-fbd9-4a7f-9e2a-d98bfd452840"), "Rally", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("70a73e9f-9b73-4740-bdca-2b1408cfda03"), "TPS", new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a") },
                { new Guid("7bb18dd0-453c-4ad2-8028-fc9619032dde"), "FPS", new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a") },
                { new Guid("bd8a7bed-5979-4600-bda4-757a93cd2771"), "Off-road", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("d360ef8a-8272-4d7a-9797-0cb117cab398"), "TBS", new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4") },
                { new Guid("f4ed662f-f1e9-4e17-a6d7-46b9371bbd57"), "Formula", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
            });
    }
}
