using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddUserBan : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
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

        migrationBuilder.CreateTable(
            name: "user_ban",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_user_ban", x => x.id);
            });

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("1374ef94-5e22-454d-a5c5-aa3042ae889b"), "RTS", null },
                { new Guid("29d6e228-b6a4-4f08-add7-eb74ee5704ae"), "Sports", null },
                { new Guid("3d281a91-a47e-4837-98be-b513f5880b0c"), "RPG", null },
                { new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1"), "Races", null },
                { new Guid("a5ee5b02-c0ca-40b4-9b88-8c140f9b2fbc"), "Action", null },
                { new Guid("cc7917a9-a10f-42e2-b769-c35e191b5026"), "Adventure", null },
                { new Guid("d9b90777-a9ea-446c-9e39-2403ece59de9"), "Puzzle & Skill", null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("0d640fff-bf08-4909-960d-e8c4461c1b03"), "Browser" },
                { new Guid("2d504166-4b1f-4f7d-b630-cdd753e6dd8f"), "Console" },
                { new Guid("3d99ab7d-04af-4d8b-888d-4bbb313e8678"), "Desktop" },
                { new Guid("adcd8738-891d-4ff5-a4db-a6772b93195b"), "Mobile" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("02eb0416-f338-4aed-847b-8d6b37d2d917"), "Rally", new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1") },
                { new Guid("12107e8d-99ef-4572-adf8-32e5330f6a10"), "Formula", new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1") },
                { new Guid("3b8481df-090e-43aa-a4f2-7954d67644c0"), "FPS", new Guid("a5ee5b02-c0ca-40b4-9b88-8c140f9b2fbc") },
                { new Guid("3f0f10c8-b2f5-4e32-bb7d-6b03e687f9d2"), "Arcade", new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1") },
                { new Guid("52057bd3-70a4-4e3a-9fe4-d1f0ae5cb73c"), "Off-road", new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1") },
                { new Guid("bcf0cb9c-baf8-4e64-8aaf-04d2825b7eed"), "TPS", new Guid("a5ee5b02-c0ca-40b4-9b88-8c140f9b2fbc") },
                { new Guid("cb055253-ac8c-4f1d-bf32-9b707725c926"), "TBS", new Guid("1374ef94-5e22-454d-a5c5-aa3042ae889b") },
            });

        migrationBuilder.CreateIndex(
            name: "IX_comment_game_id",
            table: "comment",
            column: "game_id");

        migrationBuilder.CreateIndex(
            name: "IX_user_ban_user_name",
            table: "user_ban",
            column: "user_name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "user_ban");

        migrationBuilder.DropIndex(
            name: "IX_comment_game_id",
            table: "comment");

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("02eb0416-f338-4aed-847b-8d6b37d2d917"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("12107e8d-99ef-4572-adf8-32e5330f6a10"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("29d6e228-b6a4-4f08-add7-eb74ee5704ae"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("3b8481df-090e-43aa-a4f2-7954d67644c0"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("3d281a91-a47e-4837-98be-b513f5880b0c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("3f0f10c8-b2f5-4e32-bb7d-6b03e687f9d2"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("52057bd3-70a4-4e3a-9fe4-d1f0ae5cb73c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("bcf0cb9c-baf8-4e64-8aaf-04d2825b7eed"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("cb055253-ac8c-4f1d-bf32-9b707725c926"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("cc7917a9-a10f-42e2-b769-c35e191b5026"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("d9b90777-a9ea-446c-9e39-2403ece59de9"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("0d640fff-bf08-4909-960d-e8c4461c1b03"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("2d504166-4b1f-4f7d-b630-cdd753e6dd8f"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("3d99ab7d-04af-4d8b-888d-4bbb313e8678"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("adcd8738-891d-4ff5-a4db-a6772b93195b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1374ef94-5e22-454d-a5c5-aa3042ae889b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("69cd00ab-cd62-405a-9b5b-6fb25c0bf9e1"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("a5ee5b02-c0ca-40b4-9b88-8c140f9b2fbc"));

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
}
