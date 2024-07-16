using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddCommentType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "comment",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<int>(
            name: "type",
            table: "comment",
            type: "int",
            nullable: false,
            defaultValue: 0);

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("02612e6a-5a0a-40ad-9dfa-08606007a25c"), "Adventure", null },
                { new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55"), "Races", null },
                { new Guid("467a6c27-9846-4ce3-bdb8-94a53929cee5"), "Puzzle & Skill", null },
                { new Guid("4d9f961b-6589-4a10-8698-c786eee777ec"), "Sports", null },
                { new Guid("51053ff6-bd43-4a55-aba7-0bfe78ef7ab3"), "RPG", null },
                { new Guid("8edf86d0-9058-4dda-841c-090a8bb10218"), "Action", null },
                { new Guid("911753e2-6a9e-4b89-96f3-51cb9e82b876"), "RTS", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("0fded73f-c4a6-4aa4-a3b6-1a1fddbe9c95"), "Desktop" },
                { new Guid("a87e56ab-4b7f-47f6-8cc3-25baf7158493"), "Console" },
                { new Guid("aa28f32a-b7ab-41b5-92e0-76bb22c358a8"), "Browser" },
                { new Guid("b60e6894-ee6e-4799-98af-7308857cf23f"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("639b5584-16c3-4a60-83c4-d36d9db59dcb"), "TBS", new Guid("911753e2-6a9e-4b89-96f3-51cb9e82b876") },
                { new Guid("6efea131-4a3d-4c49-a7b0-b5852ad47e72"), "Formula", new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55") },
                { new Guid("85fa3fc2-aaf3-466c-8779-df20245c937d"), "Off-road", new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55") },
                { new Guid("ac086397-f894-42e2-a650-77c820f8817a"), "TPS", new Guid("8edf86d0-9058-4dda-841c-090a8bb10218") },
                { new Guid("af8521d6-5a4f-4634-a691-7d48f9e2f06a"), "Rally", new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55") },
                { new Guid("bf4d4be2-6eba-4cb5-8007-f9c5408e2185"), "Arcade", new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55") },
                { new Guid("c56b29fa-b796-4ab1-8122-12b8b284050c"), "FPS", new Guid("8edf86d0-9058-4dda-841c-090a8bb10218") },
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("02612e6a-5a0a-40ad-9dfa-08606007a25c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("467a6c27-9846-4ce3-bdb8-94a53929cee5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("4d9f961b-6589-4a10-8698-c786eee777ec"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("51053ff6-bd43-4a55-aba7-0bfe78ef7ab3"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("639b5584-16c3-4a60-83c4-d36d9db59dcb"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("6efea131-4a3d-4c49-a7b0-b5852ad47e72"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("85fa3fc2-aaf3-466c-8779-df20245c937d"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ac086397-f894-42e2-a650-77c820f8817a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("af8521d6-5a4f-4634-a691-7d48f9e2f06a"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("bf4d4be2-6eba-4cb5-8007-f9c5408e2185"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("c56b29fa-b796-4ab1-8122-12b8b284050c"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("0fded73f-c4a6-4aa4-a3b6-1a1fddbe9c95"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("a87e56ab-4b7f-47f6-8cc3-25baf7158493"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("aa28f32a-b7ab-41b5-92e0-76bb22c358a8"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("b60e6894-ee6e-4799-98af-7308857cf23f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("393c1d05-dd94-4944-97b8-def5b7bd3c55"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("8edf86d0-9058-4dda-841c-090a8bb10218"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("911753e2-6a9e-4b89-96f3-51cb9e82b876"));

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "comment");

        migrationBuilder.DropColumn(
            name: "type",
            table: "comment");

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
    }
}
