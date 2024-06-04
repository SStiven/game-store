using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class RefactorGenreSeeder : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("015b74ba-68ab-4b11-bab5-3399bccbff1f"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("0bc9b264-ea4e-4842-9ce1-cdbc6e48aac3"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("47a196b1-f734-4cda-b8f1-55eeade8c3f8"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("4d97b2ce-13e6-4950-923b-715689f4ff38"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("4f17398d-7316-4ddb-8001-498dac4a0642"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("539a11e6-ef8e-4718-a0b7-7a9ea7594645"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("566151a8-9412-4731-9ac7-d97efcd829fd"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("69380ec4-0926-4a41-8a47-c57ec407d4d7"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("7245fed8-4802-4668-9732-37b19b3f853e"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("c92f983e-7ae1-4b4a-b269-d7bd0008ae85"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("d1951207-eb9b-4c24-b32a-3b751275376b"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("eb714918-05ad-49e0-b1c4-1551e2e45f63"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("788645ae-ea06-4013-8664-11d3cedcf756"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4"));

        migrationBuilder.DeleteData(
            table: "genre",
            keyColumn: "id",
            keyValue: new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed"));

        migrationBuilder.AlterColumn<string>(
            name: "key",
            table: "game",
            type: "nvarchar(105)",
            maxLength: 105,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(200)",
            oldMaxLength: 200);

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
                { new Guid("1ecc7b7f-fd52-4182-9716-468ac5f8695a"), "Arcade", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("6b13972d-fbd9-4a7f-9e2a-d98bfd452840"), "Rally", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("70a73e9f-9b73-4740-bdca-2b1408cfda03"), "TPS", new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a") },
                { new Guid("7bb18dd0-453c-4ad2-8028-fc9619032dde"), "FPS", new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a") },
                { new Guid("bd8a7bed-5979-4600-bda4-757a93cd2771"), "Off-road", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
                { new Guid("d360ef8a-8272-4d7a-9797-0cb117cab398"), "TBS", new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4") },
                { new Guid("f4ed662f-f1e9-4e17-a6d7-46b9371bbd57"), "Formula", new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555") },
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
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

        migrationBuilder.AlterColumn<string>(
            name: "key",
            table: "game",
            type: "nvarchar(200)",
            maxLength: 200,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(105)",
            oldMaxLength: 105);

        var genreColumns = new[] { "id", "name", "parent_genre_id" };
        migrationBuilder.InsertData(
            table: "genre",
            columns: genreColumns,
            values: new object[,]
            {
                { new Guid("47a196b1-f734-4cda-b8f1-55eeade8c3f8"), "Adventure", null },
                { new Guid("4f17398d-7316-4ddb-8001-498dac4a0642"), "Puzzle & Skill", null },
                { new Guid("539a11e6-ef8e-4718-a0b7-7a9ea7594645"), "RPG", null },
                { new Guid("566151a8-9412-4731-9ac7-d97efcd829fd"), "Sports", null },
                { new Guid("788645ae-ea06-4013-8664-11d3cedcf756"), "Action", null },
                { new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4"), "Races", null },
                { new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed"), "Strategy", null },
                { new Guid("015b74ba-68ab-4b11-bab5-3399bccbff1f"), "Off-road", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("0bc9b264-ea4e-4842-9ce1-cdbc6e48aac3"), "RTS", new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed") },
                { new Guid("4d97b2ce-13e6-4950-923b-715689f4ff38"), "Formula", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("69380ec4-0926-4a41-8a47-c57ec407d4d7"), "Rally", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("7245fed8-4802-4668-9732-37b19b3f853e"), "FPS", new Guid("788645ae-ea06-4013-8664-11d3cedcf756") },
                { new Guid("c92f983e-7ae1-4b4a-b269-d7bd0008ae85"), "Arcade", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("d1951207-eb9b-4c24-b32a-3b751275376b"), "TPS", new Guid("788645ae-ea06-4013-8664-11d3cedcf756") },
                { new Guid("eb714918-05ad-49e0-b1c4-1551e2e45f63"), "TBS", new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed") },
            });
    }
}
