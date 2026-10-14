using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpriteGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Direction = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpriteImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpriteImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimationFrames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimationId = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationFrames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationFrames_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Elevated = table.Column<bool>(type: "boolean", nullable: false),
                    VerticallyAligned = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprites_SpriteImages_SpriteImageId",
                        column: x => x.SpriteImageId,
                        principalTable: "SpriteImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpriteAnimations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpriteAnimations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpriteAnimations_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpriteAnimations_Sprites_SpriteId",
                        column: x => x.SpriteId,
                        principalTable: "Sprites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationFrames_AnimationId",
                table: "AnimationFrames",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteAnimations_AnimationId",
                table: "SpriteAnimations",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteAnimations_SpriteId",
                table: "SpriteAnimations",
                column: "SpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprites_SpriteImageId",
                table: "Sprites",
                column: "SpriteImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationFrames");

            migrationBuilder.DropTable(
                name: "SpriteAnimations");

            migrationBuilder.DropTable(
                name: "Animations");

            migrationBuilder.DropTable(
                name: "Sprites");

            migrationBuilder.DropTable(
                name: "SpriteImages");
        }
    }
}
