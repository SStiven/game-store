using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "game",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_game", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "genre",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                parent_genre_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_genre", x => x.id);
                table.ForeignKey(
                    name: "FK_genre_genre_parent_genre_id",
                    column: x => x.parent_genre_id,
                    principalTable: "genre",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "platform",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_platform", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "game_genre",
            columns: table => new
            {
                game_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                genre_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_game_genre", x => new { x.game_id, x.genre_id });
                table.ForeignKey(
                    name: "FK_game_genre_game_game_id",
                    column: x => x.game_id,
                    principalTable: "game",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_game_genre_genre_genre_id",
                    column: x => x.genre_id,
                    principalTable: "genre",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "game_platform",
            columns: table => new
            {
                game_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                platform_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_game_platform", x => new { x.game_id, x.platform_id });
                table.ForeignKey(
                    name: "FK_game_platform_game_game_id",
                    column: x => x.game_id,
                    principalTable: "game",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_game_platform_platform_platform_id",
                    column: x => x.platform_id,
                    principalTable: "platform",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        var genreColumns = new string[] { "id", "name", "parent_genre_id" };
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
            });

        var platformColumns = new string[] { "id", "type" };
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
                { new Guid("015b74ba-68ab-4b11-bab5-3399bccbff1f"), "Off-road", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("0bc9b264-ea4e-4842-9ce1-cdbc6e48aac3"), "RTS", new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed") },
                { new Guid("4d97b2ce-13e6-4950-923b-715689f4ff38"), "Formula", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("69380ec4-0926-4a41-8a47-c57ec407d4d7"), "Rally", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("7245fed8-4802-4668-9732-37b19b3f853e"), "FPS", new Guid("788645ae-ea06-4013-8664-11d3cedcf756") },
                { new Guid("c92f983e-7ae1-4b4a-b269-d7bd0008ae85"), "Arcade", new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4") },
                { new Guid("d1951207-eb9b-4c24-b32a-3b751275376b"), "TPS", new Guid("788645ae-ea06-4013-8664-11d3cedcf756") },
                { new Guid("eb714918-05ad-49e0-b1c4-1551e2e45f63"), "TBS", new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed") },
            });

        migrationBuilder.CreateIndex(
            name: "IX_game_key",
            table: "game",
            column: "key",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_game_genre_genre_id",
            table: "game_genre",
            column: "genre_id");

        migrationBuilder.CreateIndex(
            name: "IX_game_platform_platform_id",
            table: "game_platform",
            column: "platform_id");

        migrationBuilder.CreateIndex(
            name: "IX_genre_name",
            table: "genre",
            column: "name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_genre_parent_genre_id",
            table: "genre",
            column: "parent_genre_id");

        migrationBuilder.CreateIndex(
            name: "IX_platform_type",
            table: "platform",
            column: "type",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "game_genre");

        migrationBuilder.DropTable(
            name: "game_platform");

        migrationBuilder.DropTable(
            name: "genre");

        migrationBuilder.DropTable(
            name: "game");

        migrationBuilder.DropTable(
            name: "platform");
    }
}
