using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statuses_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses_20ts24tu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genders_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_genders_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "languages_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    languages = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_languages_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_types_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_types_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "statuses_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    languages_id = table.Column<int>(type: "integer", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_statuses_translations_20ts24tu_languages_20ts24tu_languages~",
                        column: x => x.languages_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_statuses_translations_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "genders_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender = table.Column<string>(type: "text", nullable: true),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    genders_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    languages_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_genders_20ts24tu_genders_id",
                        column: x => x.genders_id,
                        principalTable: "genders_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_languages_20ts24tu_languages_~",
                        column: x => x.languages_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_statuses_translations_20ts24t~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_types_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    user_types_id = table.Column<int>(type: "integer", nullable: false),
                    languages_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_types_translations_20ts24tu_languages_20ts24tu_languag~",
                        column: x => x.languages_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_types_translations_20ts24tu_statuses_translations_20ts~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_types_translations_20ts24tu_user_types_20ts24tu_user_t~",
                        column: x => x.user_types_id,
                        principalTable: "user_types_20ts24tu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "files_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_files_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "files_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    files_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    languages_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_files_translations_20ts24tu_files_20ts24tu_files_id",
                        column: x => x.files_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_files_translations_20ts24tu_languages_20ts24tu_languages_id",
                        column: x => x.languages_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_files_translations_20ts24tu_statuses_translations_20ts24tu_~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "persons_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: true),
                    lastName = table.Column<string>(type: "text", nullable: true),
                    fathers_name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    pinfl = table.Column<string>(type: "text", nullable: true),
                    passport_text = table.Column<string>(type: "text", nullable: true),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    files_id = table.Column<int>(type: "integer", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_20ts24tu_files_20ts24tu_img_id",
                        column: x => x.img_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_20ts24tu_genders_20ts24tu_gender_id",
                        column: x => x.gender_id,
                        principalTable: "genders_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "persons_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: true),
                    lastName = table.Column<string>(type: "text", nullable: true),
                    fathers_name = table.Column<string>(type: "text", nullable: true),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    persons_id = table.Column<int>(type: "integer", nullable: true),
                    languages_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_genders_translations_20ts24tu~",
                        column: x => x.gender_id,
                        principalTable: "genders_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_languages_20ts24tu_languages_~",
                        column: x => x.languages_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_persons_20ts24tu_persons_id",
                        column: x => x.persons_id,
                        principalTable: "persons_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_statuses_translations_20ts24t~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    token = table.Column<string>(type: "text", nullable: true),
                    user_type_id = table.Column<int>(type: "integer", nullable: true),
                    person_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_20ts24tu_persons_20ts24tu_person_id",
                        column: x => x.person_id,
                        principalTable: "persons_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_20ts24tu_user_types_20ts24tu_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "user_types_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_files_20ts24tu_status_id",
                table: "files_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_20ts24tu_user_id",
                table: "files_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_translations_20ts24tu_files_id",
                table: "files_translations_20ts24tu",
                column: "files_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_translations_20ts24tu_languages_id",
                table: "files_translations_20ts24tu",
                column: "languages_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_translations_20ts24tu_status_translation_id",
                table: "files_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_20ts24tu_status_id",
                table: "genders_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_genders_id",
                table: "genders_translations_20ts24tu",
                column: "genders_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_languages_id",
                table: "genders_translations_20ts24tu",
                column: "languages_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_status_translation_id",
                table: "genders_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_languages_20ts24tu_status_id",
                table: "languages_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_20ts24tu_gender_id",
                table: "persons_20ts24tu",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_20ts24tu_img_id",
                table: "persons_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_20ts24tu_status_id",
                table: "persons_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_gender_id",
                table: "persons_translations_20ts24tu",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_languages_id",
                table: "persons_translations_20ts24tu",
                column: "languages_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_persons_id",
                table: "persons_translations_20ts24tu",
                column: "persons_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_status_translation_id",
                table: "persons_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_statuses_translations_20ts24tu_languages_id",
                table: "statuses_translations_20ts24tu",
                column: "languages_id");

            migrationBuilder.CreateIndex(
                name: "IX_statuses_translations_20ts24tu_status_id",
                table: "statuses_translations_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_20ts24tu_status_id",
                table: "user_types_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_languages_id",
                table: "user_types_translations_20ts24tu",
                column: "languages_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_status_translation_id",
                table: "user_types_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_user_types_id",
                table: "user_types_translations_20ts24tu",
                column: "user_types_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_20ts24tu_login",
                table: "users_20ts24tu",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_20ts24tu_person_id",
                table: "users_20ts24tu",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_20ts24tu_status_id",
                table: "users_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_20ts24tu_user_type_id",
                table: "users_20ts24tu",
                column: "user_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_files_20ts24tu_users_20ts24tu_user_id",
                table: "files_20ts24tu",
                column: "user_id",
                principalTable: "users_20ts24tu",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_20ts24tu_statuses_20ts24tu_status_id",
                table: "files_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_genders_20ts24tu_statuses_20ts24tu_status_id",
                table: "genders_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_20ts24tu_statuses_20ts24tu_status_id",
                table: "persons_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_user_types_20ts24tu_statuses_20ts24tu_status_id",
                table: "user_types_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_users_20ts24tu_statuses_20ts24tu_status_id",
                table: "users_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_files_20ts24tu_users_20ts24tu_user_id",
                table: "files_20ts24tu");

            migrationBuilder.DropTable(
                name: "files_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "persons_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "user_types_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "genders_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "statuses_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "languages_20ts24tu");

            migrationBuilder.DropTable(
                name: "statuses_20ts24tu");

            migrationBuilder.DropTable(
                name: "users_20ts24tu");

            migrationBuilder.DropTable(
                name: "persons_20ts24tu");

            migrationBuilder.DropTable(
                name: "user_types_20ts24tu");

            migrationBuilder.DropTable(
                name: "files_20ts24tu");

            migrationBuilder.DropTable(
                name: "genders_20ts24tu");
        }
    }
}
