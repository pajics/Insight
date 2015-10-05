using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Insight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Company = table.Column<string>(isNullable: true),
                    Department = table.Column<string>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    Email = table.Column<string>(isNullable: false),
                    FirstName = table.Column<string>(isNullable: false),
                    Gender = table.Column<int>(isNullable: false),
                    LastName = table.Column<string>(isNullable: false),
                    LogonCount = table.Column<int>(isNullable: false),
                    ProfileImageUrl = table.Column<string>(isNullable: true),
                    Role = table.Column<string>(isNullable: true),
                    Thumbnail = table.Column<byte[]>(isNullable: true),
                    TimestampCreated = table.Column<DateTime>(isNullable: false),
                    TimestampModified = table.Column<DateTime>(isNullable: false, computedColumnSql: "getdate()"),
                    Username = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(isNullable: false),
                    AccessFailedCount = table.Column<int>(isNullable: false),
                    ConcurrencyStamp = table.Column<string>(isNullable: true),
                    Email = table.Column<string>(isNullable: true),
                    EmailConfirmed = table.Column<bool>(isNullable: false),
                    LockoutEnabled = table.Column<bool>(isNullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(isNullable: true),
                    NormalizedEmail = table.Column<string>(isNullable: true),
                    NormalizedUserName = table.Column<string>(isNullable: true),
                    PasswordHash = table.Column<string>(isNullable: true),
                    PhoneNumber = table.Column<string>(isNullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(isNullable: false),
                    SecurityStamp = table.Column<string>(isNullable: true),
                    TwoFactorEnabled = table.Column<bool>(isNullable: false),
                    UserName = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(isNullable: false),
                    ConcurrencyStamp = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    NormalizedName = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(isNullable: true),
                    Name = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(isNullable: true),
                    Name = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(isNullable: true),
                    ClaimValue = table.Column<string>(isNullable: true),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(isNullable: false),
                    ProviderKey = table.Column<string>(isNullable: false),
                    ProviderDisplayName = table.Column<string>(isNullable: true),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(isNullable: true),
                    ClaimValue = table.Column<string>(isNullable: true),
                    RoleId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(isNullable: false),
                    RoleId = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateIndex(
                name: "IX_Employee_Username",
                table: "Employee",
                column: "Username",
                isUnique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Employee_TimestampCreated_LastName_FirstName",
                table: "Employee",
                columns: new[] { "TimestampCreated", "LastName", "FirstName" });
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("EmployeeRole");
            migrationBuilder.DropTable("Skill");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Employee");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}
