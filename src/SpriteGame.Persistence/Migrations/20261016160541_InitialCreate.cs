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
                name: "Audio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ItemType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
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
                name: "Neighbourhoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MusicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighbourhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighbourhoods_Audio_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventScenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventScenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventScenes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TileSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TileCount = table.Column<int>(type: "integer", nullable: false),
                    BlockedTiles = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TileSheets_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractionId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConditionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Interactions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventSceneAnimations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventSceneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSceneAnimations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSceneAnimations_EventScenes_EventSceneId",
                        column: x => x.EventSceneId,
                        principalTable: "EventScenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TriggerableEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConditionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerableEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriggerableEvents_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TriggerableEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractiveMapLayerOneId = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractiveMapLayerOneColumn = table.Column<int>(type: "integer", nullable: false),
                    InteractiveMapLayerOneRow = table.Column<int>(type: "integer", nullable: false),
                    InteractiveMapLayerTwoId = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractiveMapLayerTwoColumn = table.Column<int>(type: "integer", nullable: false),
                    InteractiveMapLayerTwoRow = table.Column<int>(type: "integer", nullable: false),
                    InteractiveMapLayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTriggers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerableEventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTriggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTriggers_TriggerableEvents_TriggerableEventId",
                        column: x => x.TriggerableEventId,
                        principalTable: "TriggerableEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractiveMapLayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MapId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractiveMapLayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HasCollision = table.Column<bool>(type: "boolean", nullable: false),
                    VerticallyAligned = table.Column<bool>(type: "boolean", nullable: false),
                    BlockedAreaX = table.Column<int>(type: "integer", nullable: true),
                    BlockedAreaY = table.Column<int>(type: "integer", nullable: true),
                    BlockedAreaWidth = table.Column<int>(type: "integer", nullable: true),
                    BlockedAreaHeight = table.Column<int>(type: "integer", nullable: true),
                    InteractiveMapLayerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprites_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprites_InteractiveMapLayers_InteractiveMapLayerId",
                        column: x => x.InteractiveMapLayerId,
                        principalTable: "InteractiveMapLayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MapLayerSprites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteLayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractiveMapLayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Direction = table.Column<int>(type: "integer", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapLayerSprites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapLayerSprites_InteractiveMapLayers_InteractiveMapLayerId",
                        column: x => x.InteractiveMapLayerId,
                        principalTable: "InteractiveMapLayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapLayerSprites_Sprites_SpriteId",
                        column: x => x.SpriteId,
                        principalTable: "Sprites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpriteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Sprites_SpriteId",
                        column: x => x.SpriteId,
                        principalTable: "Sprites",
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

            migrationBuilder.CreateTable(
                name: "Triggers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MapLayerSpriteId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpriteLayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: true),
                    Row = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Triggers_InteractiveMapLayers_SpriteLayerId",
                        column: x => x.SpriteLayerId,
                        principalTable: "InteractiveMapLayers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Triggers_MapLayerSprites_MapLayerSpriteId",
                        column: x => x.MapLayerSpriteId,
                        principalTable: "MapLayerSprites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInteractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerInteractions_Interactions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerInteractions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NeighbourhoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    BackgroundStaticLayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BackgroundInteractiveLayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ForegroundStaticLayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ForegroundInteractiveLayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Columns = table.Column<int>(type: "integer", nullable: false),
                    Rows = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_InteractiveMapLayers_BackgroundInteractiveLayerId",
                        column: x => x.BackgroundInteractiveLayerId,
                        principalTable: "InteractiveMapLayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_InteractiveMapLayers_ForegroundInteractiveLayerId",
                        column: x => x.ForegroundInteractiveLayerId,
                        principalTable: "InteractiveMapLayers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maps_Neighbourhoods_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticMapLayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MapId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockedAreas = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticMapLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticMapLayers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticMapLayers_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationFrames_AnimationId",
                table: "AnimationFrames",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_InteractionId",
                table: "Conditions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_InteractiveMapLayerId",
                table: "Doors",
                column: "InteractiveMapLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_InteractiveMapLayerOneId",
                table: "Doors",
                column: "InteractiveMapLayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_InteractiveMapLayerTwoId",
                table: "Doors",
                column: "InteractiveMapLayerTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSceneAnimations_EventSceneId",
                table: "EventSceneAnimations",
                column: "EventSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_EventScenes_EventId",
                table: "EventScenes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTriggers_TriggerableEventId",
                table: "EventTriggers",
                column: "TriggerableEventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTriggers_TriggerId",
                table: "EventTriggers",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractiveMapLayers_MapId",
                table: "InteractiveMapLayers",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PlayerId",
                table: "Inventory",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_InventoryId",
                table: "InventoryItem",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ItemId",
                table: "InventoryItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MapLayerSprites_InteractiveMapLayerId",
                table: "MapLayerSprites",
                column: "InteractiveMapLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MapLayerSprites_SpriteId",
                table: "MapLayerSprites",
                column: "SpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_BackgroundInteractiveLayerId",
                table: "Maps",
                column: "BackgroundInteractiveLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_BackgroundStaticLayerId",
                table: "Maps",
                column: "BackgroundStaticLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_ForegroundInteractiveLayerId",
                table: "Maps",
                column: "ForegroundInteractiveLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_ForegroundStaticLayerId",
                table: "Maps",
                column: "ForegroundStaticLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_NeighbourhoodId",
                table: "Maps",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighbourhoods_MusicId",
                table: "Neighbourhoods",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInteractions_InteractionId",
                table: "PlayerInteractions",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInteractions_PlayerId",
                table: "PlayerInteractions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SpriteId",
                table: "Players",
                column: "SpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteAnimations_AnimationId",
                table: "SpriteAnimations",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteAnimations_SpriteId",
                table: "SpriteAnimations",
                column: "SpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprites_ImageId",
                table: "Sprites",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprites_InteractiveMapLayerId",
                table: "Sprites",
                column: "InteractiveMapLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticMapLayers_ImageId",
                table: "StaticMapLayers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticMapLayers_MapId",
                table: "StaticMapLayers",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_TileSheets_ImageId",
                table: "TileSheets",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerableEvents_ConditionId",
                table: "TriggerableEvents",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerableEvents_EventId",
                table: "TriggerableEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_MapLayerSpriteId",
                table: "Triggers",
                column: "MapLayerSpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_SpriteLayerId",
                table: "Triggers",
                column: "SpriteLayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_InteractiveMapLayers_InteractiveMapLayerId",
                table: "Doors",
                column: "InteractiveMapLayerId",
                principalTable: "InteractiveMapLayers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_InteractiveMapLayers_InteractiveMapLayerOneId",
                table: "Doors",
                column: "InteractiveMapLayerOneId",
                principalTable: "InteractiveMapLayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_InteractiveMapLayers_InteractiveMapLayerTwoId",
                table: "Doors",
                column: "InteractiveMapLayerTwoId",
                principalTable: "InteractiveMapLayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTriggers_Triggers_TriggerId",
                table: "EventTriggers",
                column: "TriggerId",
                principalTable: "Triggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractiveMapLayers_Maps_MapId",
                table: "InteractiveMapLayers",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_StaticMapLayers_BackgroundStaticLayerId",
                table: "Maps",
                column: "BackgroundStaticLayerId",
                principalTable: "StaticMapLayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_StaticMapLayers_ForegroundStaticLayerId",
                table: "Maps",
                column: "ForegroundStaticLayerId",
                principalTable: "StaticMapLayers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_InteractiveMapLayers_BackgroundInteractiveLayerId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_InteractiveMapLayers_ForegroundInteractiveLayerId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticMapLayers_Maps_MapId",
                table: "StaticMapLayers");

            migrationBuilder.DropTable(
                name: "AnimationFrames");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "EventSceneAnimations");

            migrationBuilder.DropTable(
                name: "EventTriggers");

            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "PlayerInteractions");

            migrationBuilder.DropTable(
                name: "SpriteAnimations");

            migrationBuilder.DropTable(
                name: "TileSheets");

            migrationBuilder.DropTable(
                name: "EventScenes");

            migrationBuilder.DropTable(
                name: "TriggerableEvents");

            migrationBuilder.DropTable(
                name: "Triggers");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Animations");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MapLayerSprites");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Sprites");

            migrationBuilder.DropTable(
                name: "InteractiveMapLayers");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Neighbourhoods");

            migrationBuilder.DropTable(
                name: "StaticMapLayers");

            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
