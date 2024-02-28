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
                name: "blogs_category_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs_category_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_blogs_category_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departament_types_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_types_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_departament_types_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
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
                name: "site_types_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site_types_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_site_types_20ts24tu_statuses_20ts24tu_status_id",
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
                name: "blogs_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true),
                    blog_category_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_blogs_20ts24tu_blogs_category_20ts24tu_blog_category_id",
                        column: x => x.blog_category_id,
                        principalTable: "blogs_category_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_blogs_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "blogs_category_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    blog_category_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs_category_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_blogs_category_translations_20ts24tu_blogs_category_20ts24t~",
                        column: x => x.blog_category_id,
                        principalTable: "blogs_category_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "blogs_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_translation_id = table.Column<int>(type: "integer", nullable: true),
                    blog_category_translation_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    blog_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_blogs_translations_20ts24tu_blogs_20ts24tu_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blogs_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_blogs_translations_20ts24tu_blogs_category_translations_20t~",
                        column: x => x.blog_category_translation_id,
                        principalTable: "blogs_category_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departament_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    departament_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_departament_20ts24tu_departament_types_20ts24tu_departament~",
                        column: x => x.departament_type_id,
                        principalTable: "departament_types_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_departament_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departament_details_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text_json = table.Column<string>(type: "text", nullable: true),
                    departament_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_details_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_departament_details_20ts24tu_departament_20ts24tu_departame~",
                        column: x => x.departament_id,
                        principalTable: "departament_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_departament_details_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departament_details_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text_json = table.Column<string>(type: "text", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    departament_translation_id = table.Column<int>(type: "integer", nullable: true),
                    departament_detail_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_details_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_departament_details_translations_20ts24tu_departament_detai~",
                        column: x => x.departament_detail_id,
                        principalTable: "departament_details_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departament_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    departament_type_translation_id = table.Column<int>(type: "integer", nullable: true),
                    departament_translation_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_translations_20ts24tu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departament_types_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    departament_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament_types_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_departament_types_translations_20ts24tu_departament_types_2~",
                        column: x => x.departament_type_id,
                        principalTable: "departament_types_20ts24tu",
                        principalColumn: "id");
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
                name: "languages_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_languages_20ts24tu_files_20ts24tu_img_id",
                        column: x => x.img_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_languages_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
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
                name: "statuses_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_statuses_translations_20ts24tu_languages_20ts24tu_language_~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_statuses_translations_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
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
                    departament_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_20ts24tu_departament_20ts24tu_departament_id",
                        column: x => x.departament_id,
                        principalTable: "departament_20ts24tu",
                        principalColumn: "id");
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

            migrationBuilder.CreateTable(
                name: "genders_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender = table.Column<string>(type: "text", nullable: true),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_genders_20ts24tu_gender_id",
                        column: x => x.gender_id,
                        principalTable: "genders_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_languages_20ts24tu_language_id",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_genders_translations_20ts24tu_statuses_translations_20ts24t~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "site_types_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    site_type_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site_types_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_site_types_translations_20ts24tu_languages_20ts24tu_languag~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_types_translations_20ts24tu_site_types_20ts24tu_site_t~",
                        column: x => x.site_type_id,
                        principalTable: "site_types_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_types_translations_20ts24tu_statuses_translations_20ts~",
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
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_types_translations_20ts24tu_languages_20ts24tu_languag~",
                        column: x => x.language_id,
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
                name: "files_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    files_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_files_translations_20ts24tu_languages_20ts24tu_language_id",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_files_translations_20ts24tu_statuses_translations_20ts24tu_~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_files_translations_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pages_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_pages_20ts24tu_files_20ts24tu_img_id",
                        column: x => x.img_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sites_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    site_type_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sites_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_sites_20ts24tu_site_types_20ts24tu_site_type_id",
                        column: x => x.site_type_id,
                        principalTable: "site_types_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
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
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    img_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_files_translations_20ts24tu_i~",
                        column: x => x.img_id,
                        principalTable: "files_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_genders_translations_20ts24tu~",
                        column: x => x.gender_id,
                        principalTable: "genders_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_persons_translations_20ts24tu_languages_20ts24tu_language_id",
                        column: x => x.language_id,
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
                name: "pages_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_short = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_translation_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: true),
                    page_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_pages_translations_20ts24tu_files_translations_20ts24tu_img~",
                        column: x => x.img_translation_id,
                        principalTable: "files_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_translations_20ts24tu_languages_20ts24tu_language_id",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_translations_20ts24tu_pages_20ts24tu_page_id",
                        column: x => x.page_id,
                        principalTable: "pages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_translations_20ts24tu_statuses_translations_20ts24tu_~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_translations_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "site_details_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    logo_w_id = table.Column<int>(type: "integer", nullable: true),
                    logo_b_id = table.Column<int>(type: "integer", nullable: true),
                    favicon_id = table.Column<int>(type: "integer", nullable: true),
                    socials = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    site_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site_details_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_site_details_20ts24tu_files_20ts24tu_favicon_id",
                        column: x => x.favicon_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_20ts24tu_files_20ts24tu_logo_b_id",
                        column: x => x.logo_b_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_20ts24tu_files_20ts24tu_logo_w_id",
                        column: x => x.logo_w_id,
                        principalTable: "files_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_20ts24tu_sites_20ts24tu_site_id",
                        column: x => x.site_id,
                        principalTable: "sites_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sites_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    site_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true),
                    site_type_translation_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sites_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_sites_translations_20ts24tu_languages_20ts24tu_language_id",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_translations_20ts24tu_site_types_translations_20ts24t~",
                        column: x => x.site_type_translation_id,
                        principalTable: "site_types_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_translations_20ts24tu_sites_20ts24tu_site_id",
                        column: x => x.site_id,
                        principalTable: "sites_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_translations_20ts24tu_statuses_translations_20ts24tu_~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_translations_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "site_details_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    site_detail_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    logo_w_id = table.Column<int>(type: "integer", nullable: true),
                    logo_b_id = table.Column<int>(type: "integer", nullable: true),
                    favicon_id = table.Column<int>(type: "integer", nullable: true),
                    socials = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    site_translation_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site_details_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_files_translations_20ts2~",
                        column: x => x.favicon_id,
                        principalTable: "files_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_files_translations_20ts~1",
                        column: x => x.logo_b_id,
                        principalTable: "files_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_files_translations_20ts~2",
                        column: x => x.logo_w_id,
                        principalTable: "files_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_languages_20ts24tu_langu~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_site_details_20ts24tu_si~",
                        column: x => x.site_detail_id,
                        principalTable: "site_details_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_sites_translations_20ts2~",
                        column: x => x.site_translation_id,
                        principalTable: "sites_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_site_details_translations_20ts24tu_statuses_translations_20~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_20ts24tu_blog_category_id",
                table: "blogs_20ts24tu",
                column: "blog_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_20ts24tu_img_id",
                table: "blogs_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_20ts24tu_status_id",
                table: "blogs_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_20ts24tu_user_id",
                table: "blogs_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_category_20ts24tu_status_id",
                table: "blogs_category_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_category_translations_20ts24tu_blog_category_id",
                table: "blogs_category_translations_20ts24tu",
                column: "blog_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_category_translations_20ts24tu_language_id",
                table: "blogs_category_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_category_translations_20ts24tu_status_translation_id",
                table: "blogs_category_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_blog_category_translation_id",
                table: "blogs_translations_20ts24tu",
                column: "blog_category_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_blog_id",
                table: "blogs_translations_20ts24tu",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_img_translation_id",
                table: "blogs_translations_20ts24tu",
                column: "img_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_language_id",
                table: "blogs_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_status_translation_id",
                table: "blogs_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_translations_20ts24tu_user_id",
                table: "blogs_translations_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_20ts24tu_departament_type_id",
                table: "departament_20ts24tu",
                column: "departament_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_20ts24tu_img_id",
                table: "departament_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_20ts24tu_status_id",
                table: "departament_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_20ts24tu_departament_id",
                table: "departament_details_20ts24tu",
                column: "departament_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_20ts24tu_status_id",
                table: "departament_details_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_translations_20ts24tu_departament_detai~",
                table: "departament_details_translations_20ts24tu",
                column: "departament_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_translations_20ts24tu_departament_trans~",
                table: "departament_details_translations_20ts24tu",
                column: "departament_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_translations_20ts24tu_language_id",
                table: "departament_details_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_details_translations_20ts24tu_status_translatio~",
                table: "departament_details_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_translations_20ts24tu_departament_translation_t~",
                table: "departament_translations_20ts24tu",
                column: "departament_translation_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_translations_20ts24tu_img_id",
                table: "departament_translations_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_translations_20ts24tu_language_id",
                table: "departament_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_translations_20ts24tu_status_translation_id",
                table: "departament_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_types_20ts24tu_status_id",
                table: "departament_types_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_types_translations_20ts24tu_departament_type_id",
                table: "departament_types_translations_20ts24tu",
                column: "departament_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_types_translations_20ts24tu_language_id",
                table: "departament_types_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_types_translations_20ts24tu_status_translation_~",
                table: "departament_types_translations_20ts24tu",
                column: "status_translation_id");

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
                name: "IX_files_translations_20ts24tu_language_id",
                table: "files_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_translations_20ts24tu_status_translation_id",
                table: "files_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_files_translations_20ts24tu_user_id",
                table: "files_translations_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_20ts24tu_status_id",
                table: "genders_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_gender_id",
                table: "genders_translations_20ts24tu",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_language_id",
                table: "genders_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_genders_translations_20ts24tu_status_translation_id",
                table: "genders_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_languages_20ts24tu_img_id",
                table: "languages_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_languages_20ts24tu_status_id",
                table: "languages_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_20ts24tu_img_id",
                table: "pages_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_20ts24tu_status_id",
                table: "pages_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_20ts24tu_user_id",
                table: "pages_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_translations_20ts24tu_img_translation_id",
                table: "pages_translations_20ts24tu",
                column: "img_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_translations_20ts24tu_language_id",
                table: "pages_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_translations_20ts24tu_page_id",
                table: "pages_translations_20ts24tu",
                column: "page_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_translations_20ts24tu_status_translation_id",
                table: "pages_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_translations_20ts24tu_user_id",
                table: "pages_translations_20ts24tu",
                column: "user_id");

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
                name: "IX_persons_translations_20ts24tu_img_id",
                table: "persons_translations_20ts24tu",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_language_id",
                table: "persons_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_persons_id",
                table: "persons_translations_20ts24tu",
                column: "persons_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_translations_20ts24tu_status_translation_id",
                table: "persons_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_20ts24tu_favicon_id",
                table: "site_details_20ts24tu",
                column: "favicon_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_20ts24tu_logo_b_id",
                table: "site_details_20ts24tu",
                column: "logo_b_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_20ts24tu_logo_w_id",
                table: "site_details_20ts24tu",
                column: "logo_w_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_20ts24tu_site_id",
                table: "site_details_20ts24tu",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_20ts24tu_status_id",
                table: "site_details_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_favicon_id",
                table: "site_details_translations_20ts24tu",
                column: "favicon_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_language_id",
                table: "site_details_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_logo_b_id",
                table: "site_details_translations_20ts24tu",
                column: "logo_b_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_logo_w_id",
                table: "site_details_translations_20ts24tu",
                column: "logo_w_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_site_detail_id",
                table: "site_details_translations_20ts24tu",
                column: "site_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_site_translation_id",
                table: "site_details_translations_20ts24tu",
                column: "site_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_details_translations_20ts24tu_status_translation_id",
                table: "site_details_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_types_20ts24tu_status_id",
                table: "site_types_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_types_translations_20ts24tu_language_id",
                table: "site_types_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_types_translations_20ts24tu_site_type_id",
                table: "site_types_translations_20ts24tu",
                column: "site_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_types_translations_20ts24tu_status_translation_id",
                table: "site_types_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_20ts24tu_site_type_id",
                table: "sites_20ts24tu",
                column: "site_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_20ts24tu_status_id",
                table: "sites_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_20ts24tu_user_id",
                table: "sites_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_translations_20ts24tu_language_id",
                table: "sites_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_translations_20ts24tu_site_id",
                table: "sites_translations_20ts24tu",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_translations_20ts24tu_site_type_translation_id",
                table: "sites_translations_20ts24tu",
                column: "site_type_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_translations_20ts24tu_status_translation_id",
                table: "sites_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_translations_20ts24tu_user_id",
                table: "sites_translations_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_statuses_translations_20ts24tu_language_id",
                table: "statuses_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_statuses_translations_20ts24tu_status_id",
                table: "statuses_translations_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_20ts24tu_status_id",
                table: "user_types_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_language_id",
                table: "user_types_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_status_translation_id",
                table: "user_types_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_types_translations_20ts24tu_user_types_id",
                table: "user_types_translations_20ts24tu",
                column: "user_types_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_20ts24tu_departament_id",
                table: "users_20ts24tu",
                column: "departament_id");

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
                name: "FK_blogs_20ts24tu_files_20ts24tu_img_id",
                table: "blogs_20ts24tu",
                column: "img_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_20ts24tu_users_20ts24tu_user_id",
                table: "blogs_20ts24tu",
                column: "user_id",
                principalTable: "users_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_category_translations_20ts24tu_languages_20ts24tu_lan~",
                table: "blogs_category_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_category_translations_20ts24tu_statuses_translations_~",
                table: "blogs_category_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_translations_20ts24tu_files_translations_20ts24tu_img~",
                table: "blogs_translations_20ts24tu",
                column: "img_translation_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_translations_20ts24tu_languages_20ts24tu_language_id",
                table: "blogs_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_translations_20ts24tu_statuses_translations_20ts24tu_~",
                table: "blogs_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_translations_20ts24tu_users_20ts24tu_user_id",
                table: "blogs_translations_20ts24tu",
                column: "user_id",
                principalTable: "users_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_20ts24tu_files_20ts24tu_img_id",
                table: "departament_20ts24tu",
                column: "img_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_details_translations_20ts24tu_departament_trans~",
                table: "departament_details_translations_20ts24tu",
                column: "departament_translation_id",
                principalTable: "departament_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_details_translations_20ts24tu_languages_20ts24t~",
                table: "departament_details_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_details_translations_20ts24tu_statuses_translat~",
                table: "departament_details_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_departament_types_transla~",
                table: "departament_translations_20ts24tu",
                column: "departament_translation_type_id",
                principalTable: "departament_types_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
                table: "departament_translations_20ts24tu",
                column: "img_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_languages_20ts24tu_langua~",
                table: "departament_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_statuses_translations_20t~",
                table: "departament_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_types_translations_20ts24tu_languages_20ts24tu_~",
                table: "departament_types_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_types_translations_20ts24tu_statuses_translatio~",
                table: "departament_types_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");

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
                name: "FK_departament_20ts24tu_files_20ts24tu_img_id",
                table: "departament_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_20ts24tu_files_20ts24tu_img_id",
                table: "persons_20ts24tu");

            migrationBuilder.DropTable(
                name: "blogs_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_details_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "pages_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "persons_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "site_details_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "user_types_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "blogs_20ts24tu");

            migrationBuilder.DropTable(
                name: "blogs_category_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_details_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "pages_20ts24tu");

            migrationBuilder.DropTable(
                name: "genders_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "site_details_20ts24tu");

            migrationBuilder.DropTable(
                name: "sites_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "blogs_category_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_types_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "files_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "site_types_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "sites_20ts24tu");

            migrationBuilder.DropTable(
                name: "statuses_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "site_types_20ts24tu");

            migrationBuilder.DropTable(
                name: "languages_20ts24tu");

            migrationBuilder.DropTable(
                name: "files_20ts24tu");

            migrationBuilder.DropTable(
                name: "users_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_20ts24tu");

            migrationBuilder.DropTable(
                name: "persons_20ts24tu");

            migrationBuilder.DropTable(
                name: "user_types_20ts24tu");

            migrationBuilder.DropTable(
                name: "departament_types_20ts24tu");

            migrationBuilder.DropTable(
                name: "genders_20ts24tu");

            migrationBuilder.DropTable(
                name: "statuses_20ts24tu");
        }
    }
}
