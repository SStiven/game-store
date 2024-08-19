using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddNorthwindFieldsInSqlServer : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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

        migrationBuilder.AddColumn<string>(
            name: "ContactName",
            table: "publisher",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "description",
            table: "genre",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "picture",
            table: "genre",
            type: "varbinary(max)",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "discontinued",
            table: "game",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "quantity_per_unit",
            table: "game",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<int>(
            name: "reorder_level",
            table: "game",
            type: "int",
            nullable: false,
            defaultValue: 0);

        var genreColumns = new[] { "id", "description", "name", "parent_genre_id", "picture" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("0991216c-d8b1-4a14-a5b1-a3aabbfcd91c"), null, "RTS", null, null },
                { new Guid("2a35044e-dbd0-4378-862e-907a73e31136"), null, "Sports", null, null },
                { new Guid("2ada3b81-6f18-4869-9d3c-247f356192d5"), null, "Puzzle & Skill", null, null },
                { new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"), null, "Races", null, null },
                { new Guid("415049d2-2e29-4127-8e6e-7d973c842c6b"), null, "Action", null, null },
                { new Guid("8a11c838-ca6e-4721-a590-874ac4f633f7"), null, "Adventure", null, null },
                { new Guid("f2a5d8c6-6a2d-44f1-95f2-c7e46f47441b"), null, "RPG", null, null },
            });

        var platformColumns = new[] { "id", "type" };
        migrationBuilder.InsertData(
            table: "platform",
            columns: platformColumns,
            values: new object[,]
            {
                { new Guid("140d9679-3bb5-4c8c-886f-5d2d530cfe15"), "Mobile" },
                { new Guid("15d91282-7848-4451-8bd9-6f70dc1b7301"), "Desktop" },
                { new Guid("a4e68139-4d9d-4ba0-8af3-e12568f925cc"), "Console" },
                { new Guid("fa98aab1-f48f-4ad8-be45-fce4f49df9bd"), "Browser" },
            });

        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("0ee20c73-198f-4dd7-bd22-b8f39d5d7e87"), null, "Off-road", new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"), null },
                { new Guid("1afe7493-0007-4400-a343-9986106a3e86"), null, "Rally", new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"), null },
                { new Guid("36051aca-c8a7-4af1-bc03-3cf3f43cbcd1"), null, "Arcade", new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"), null },
                { new Guid("5291ccd8-4a4c-48e7-8973-f94f23f32eb9"), null, "TBS", new Guid("0991216c-d8b1-4a14-a5b1-a3aabbfcd91c"), null },
                { new Guid("b78de823-12c9-4ead-8bc2-35498f3e2e5b"), null, "FPS", new Guid("415049d2-2e29-4127-8e6e-7d973c842c6b"), null },
                { new Guid("ba04d3cf-3672-4a49-84a7-39ac4f80fd27"), null, "TPS", new Guid("415049d2-2e29-4127-8e6e-7d973c842c6b"), null },
                { new Guid("fa43877a-68c4-47ba-bb41-93bff989b244"), null, "Formula", new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"), null },
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("0ee20c73-198f-4dd7-bd22-b8f39d5d7e87"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("1afe7493-0007-4400-a343-9986106a3e86"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("2a35044e-dbd0-4378-862e-907a73e31136"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("2ada3b81-6f18-4869-9d3c-247f356192d5"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("36051aca-c8a7-4af1-bc03-3cf3f43cbcd1"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("5291ccd8-4a4c-48e7-8973-f94f23f32eb9"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("8a11c838-ca6e-4721-a590-874ac4f633f7"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("b78de823-12c9-4ead-8bc2-35498f3e2e5b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("ba04d3cf-3672-4a49-84a7-39ac4f80fd27"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("f2a5d8c6-6a2d-44f1-95f2-c7e46f47441b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("fa43877a-68c4-47ba-bb41-93bff989b244"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("140d9679-3bb5-4c8c-886f-5d2d530cfe15"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("15d91282-7848-4451-8bd9-6f70dc1b7301"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("a4e68139-4d9d-4ba0-8af3-e12568f925cc"));

        migrationBuilder.DeleteData(
            table: "platform",
            keyColumn: "id",
            keyValue: new Guid("fa98aab1-f48f-4ad8-be45-fce4f49df9bd"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("0991216c-d8b1-4a14-a5b1-a3aabbfcd91c"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("2eb99b1d-2dee-4996-97de-d8f8269210c8"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("415049d2-2e29-4127-8e6e-7d973c842c6b"));

        migrationBuilder.DropColumn(
            name: "ContactName",
            table: "publisher");

        migrationBuilder.DropColumn(
            name: "description",
            table: "genre");

        migrationBuilder.DropColumn(
            name: "picture",
            table: "genre");

        migrationBuilder.DropColumn(
            name: "discontinued",
            table: "game");

        migrationBuilder.DropColumn(
            name: "quantity_per_unit",
            table: "game");

        migrationBuilder.DropColumn(
            name: "reorder_level",
            table: "game");

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
    }
}
