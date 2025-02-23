using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intrepion.VideoGames.Zelda.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emulators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emulators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emulators_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RomInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomInputs_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RomStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomStates_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RomTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomTexts_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RomTransitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomTransitions_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebSiteCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSiteCategories_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebSites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSites_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebSiteSubcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSiteSubcategories_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameConsoles_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameConsoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmulatorCores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmulatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmulatorCores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmulatorCores_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmulatorCores_Emulators_EmulatorId",
                        column: x => x.EmulatorId,
                        principalTable: "Emulators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameConsoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    Sha256Sum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlphanumericSha256Sum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSiteSubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roms_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roms_GameConsoles_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roms_WebSiteSubcategories_WebSiteSubcategoryId",
                        column: x => x.WebSiteSubcategoryId,
                        principalTable: "WebSiteSubcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaySessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmulatorCoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    RomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaySessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaySessions_AspNetUsers_ApplicationUserUpdatedById",
                        column: x => x.ApplicationUserUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaySessions_EmulatorCores_EmulatorCoreId",
                        column: x => x.EmulatorCoreId,
                        principalTable: "EmulatorCores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaySessions_Roms_RomId",
                        column: x => x.RomId,
                        principalTable: "Roms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_ApplicationUserUpdatedById",
                table: "AspNetRoleClaims",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ApplicationUserUpdatedById",
                table: "AspNetRoles",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ApplicationUserUpdatedById",
                table: "AspNetUserClaims",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_ApplicationUserUpdatedById",
                table: "AspNetUserLogins",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserUpdatedById",
                table: "AspNetUserRoles",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserUpdatedById",
                table: "AspNetUsers",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_ApplicationUserUpdatedById",
                table: "AspNetUserTokens",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ApplicationUserUpdatedById",
                table: "Companies",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmulatorCores_ApplicationUserUpdatedById",
                table: "EmulatorCores",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmulatorCores_EmulatorId",
                table: "EmulatorCores",
                column: "EmulatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Emulators_ApplicationUserUpdatedById",
                table: "Emulators",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoles_ApplicationUserUpdatedById",
                table: "GameConsoles",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoles_CompanyId",
                table: "GameConsoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ApplicationUserUpdatedById",
                table: "Languages",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlaySessions_ApplicationUserUpdatedById",
                table: "PlaySessions",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlaySessions_EmulatorCoreId",
                table: "PlaySessions",
                column: "EmulatorCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaySessions_RomId",
                table: "PlaySessions",
                column: "RomId");

            migrationBuilder.CreateIndex(
                name: "IX_RomInputs_ApplicationUserUpdatedById",
                table: "RomInputs",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roms_ApplicationUserUpdatedById",
                table: "Roms",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roms_GameConsoleId",
                table: "Roms",
                column: "GameConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roms_WebSiteSubcategoryId",
                table: "Roms",
                column: "WebSiteSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RomStates_ApplicationUserUpdatedById",
                table: "RomStates",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RomTexts_ApplicationUserUpdatedById",
                table: "RomTexts",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RomTransitions_ApplicationUserUpdatedById",
                table: "RomTransitions",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WebSiteCategories_ApplicationUserUpdatedById",
                table: "WebSiteCategories",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WebSites_ApplicationUserUpdatedById",
                table: "WebSites",
                column: "ApplicationUserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WebSiteSubcategories_ApplicationUserUpdatedById",
                table: "WebSiteSubcategories",
                column: "ApplicationUserUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PlaySessions");

            migrationBuilder.DropTable(
                name: "RomInputs");

            migrationBuilder.DropTable(
                name: "RomStates");

            migrationBuilder.DropTable(
                name: "RomTexts");

            migrationBuilder.DropTable(
                name: "RomTransitions");

            migrationBuilder.DropTable(
                name: "WebSiteCategories");

            migrationBuilder.DropTable(
                name: "WebSites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EmulatorCores");

            migrationBuilder.DropTable(
                name: "Roms");

            migrationBuilder.DropTable(
                name: "Emulators");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.DropTable(
                name: "WebSiteSubcategories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
