using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries_20ts24tu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employments_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employments_20ts24tu", x => x.id);
                });

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
                name: "territories_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territories_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_territories_20ts24tu_countries_20ts24tu_country_id",
                        column: x => x.country_id,
                        principalTable: "countries_20ts24tu",
                        principalColumn: "id");
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
                name: "districts_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    territorie_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_districts_20ts24tu_territories_20ts24tu_territorie_id",
                        column: x => x.territorie_id,
                        principalTable: "territories_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "neighborhoods_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    district_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_neighborhoods_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_neighborhoods_20ts24tu_districts_20ts24tu_district_id",
                        column: x => x.district_id,
                        principalTable: "districts_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "appeals_to_rectors_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_id = table.Column<int>(type: "integer", nullable: true),
                    territorie_id = table.Column<int>(type: "integer", nullable: true),
                    district_id = table.Column<int>(type: "integer", nullable: true),
                    neighborhood_id = table.Column<int>(type: "integer", nullable: true),
                    addres = table.Column<int>(type: "integer", nullable: false),
                    fio_ = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    employe_id = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    file_id = table.Column<int>(type: "integer", nullable: true),
                    appeal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appeals_to_rectors_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_countries_20ts24tu_country_id",
                        column: x => x.country_id,
                        principalTable: "countries_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_districts_20ts24tu_district_id",
                        column: x => x.district_id,
                        principalTable: "districts_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_employments_20ts24tu_employe_id",
                        column: x => x.employe_id,
                        principalTable: "employments_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_genders_20ts24tu_gender_id",
                        column: x => x.gender_id,
                        principalTable: "genders_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_neighborhoods_20ts24tu_neighbor~",
                        column: x => x.neighborhood_id,
                        principalTable: "neighborhoods_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_territories_20ts24tu_territorie~",
                        column: x => x.territorie_id,
                        principalTable: "territories_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    appeal_to_rector_id = table.Column<int>(type: "integer", nullable: true),
                    country_translation_id = table.Column<int>(type: "integer", nullable: true),
                    territorie_translation_id = table.Column<int>(type: "integer", nullable: true),
                    territorie_translation_ididid = table.Column<int>(type: "integer", nullable: true),
                    district_translation_id = table.Column<int>(type: "integer", nullable: true),
                    neighborhood_translation_id = table.Column<int>(type: "integer", nullable: true),
                    addres = table.Column<int>(type: "integer", nullable: false),
                    fio_ = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender_translation_id = table.Column<int>(type: "integer", nullable: true),
                    employe_translation_id = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    file_translation_id = table.Column<int>(type: "integer", nullable: true),
                    appeal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appeals_to_rectors_20ts24tu_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_appeals_t~",
                        column: x => x.appeal_to_rector_id,
                        principalTable: "appeals_to_rectors_20ts24tu",
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
                name: "countries_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_countries_translations_20ts24tu_countries_20ts24tu_country_~",
                        column: x => x.country_id,
                        principalTable: "countries_20ts24tu",
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
                name: "districts_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    district_id = table.Column<int>(type: "integer", nullable: true),
                    territorie_translation_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_districts_translations_20ts24tu_districts_20ts24tu_district~",
                        column: x => x.district_id,
                        principalTable: "districts_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employments_20ts24tu_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    employment_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employments_20ts24tu_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_employments_20ts24tu_translations_20ts24tu_employments_20ts~",
                        column: x => x.employment_id,
                        principalTable: "employments_20ts24tu",
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
                name: "neighborhoods_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    neighborhood_id = table.Column<int>(type: "integer", nullable: true),
                    district_translation_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_neighborhoods_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_neighborhoods_translations_20ts24tu_districts_translations_~",
                        column: x => x.district_translation_id,
                        principalTable: "districts_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_neighborhoods_translations_20ts24tu_languages_20ts24tu_lang~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_neighborhoods_translations_20ts24tu_neighborhoods_20ts24tu_~",
                        column: x => x.neighborhood_id,
                        principalTable: "neighborhoods_20ts24tu",
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
                name: "territories_translations_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    territorie_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    country_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territories_translations_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_territories_translations_20ts24tu_countries_translations_20~",
                        column: x => x.country_translation_id,
                        principalTable: "countries_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_territories_translations_20ts24tu_languages_20ts24tu_langua~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_territories_translations_20ts24tu_territories_20ts24tu_terr~",
                        column: x => x.territorie_id,
                        principalTable: "territories_20ts24tu",
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

            migrationBuilder.InsertData(
                table: "countries_20ts24tu",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "O'zbekiston" },
                    { 2, "Boshqa" }
                });

            migrationBuilder.InsertData(
                table: "employments_20ts24tu",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Band" },
                    { 2, "Ishsiz" },
                    { 3, "Nafaqada" },
                    { 4, "Talaba" }
                });

            migrationBuilder.InsertData(
                table: "languages_20ts24tu",
                columns: new[] { "id", "code", "description", "details", "img_id", "status_id", "title", "title_short" },
                values: new object[,]
                {
                    { 1, "en", null, null, null, null, "England", null },
                    { 2, "ru", null, null, null, null, "Russian", null }
                });

            migrationBuilder.InsertData(
                table: "user_types_20ts24tu",
                columns: new[] { "id", "status_id", "type" },
                values: new object[,]
                {
                    { 1, null, "admin" },
                    { 2, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "employments_20ts24tu_translations_20ts24tu",
                columns: new[] { "id", "employment_id", "language_id", "title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Busy" },
                    { 2, 2, 1, "Unemployed" },
                    { 3, 3, 1, "Retired" },
                    { 4, 4, 1, "Student" }
                });

            migrationBuilder.InsertData(
                table: "territories_20ts24tu",
                columns: new[] { "id", "country_id", "title" },
                values: new object[,]
                {
                    { 8, 1, "Qoraqalpogʻiston Respublikasi" },
                    { 9, 1, "Buxoro viloyati" },
                    { 10, 1, "Samarqand viloyati" },
                    { 11, 1, "Navoiy viloyati" },
                    { 12, 1, "Andijon viloyati" },
                    { 13, 1, "Fargʻona viloyati" },
                    { 14, 1, "Surxondaryo viloyati" },
                    { 15, 1, "Sirdaryo viloyati" },
                    { 16, 1, "Xorazm viloyati" },
                    { 17, 1, "Toshkent viloyati" },
                    { 18, 1, "Qashqadaryo viloyati" },
                    { 19, 1, "Jizzax viloyati" },
                    { 21, 1, "Namangan viloyati" },
                    { 22, 1, "Toshkent shahri" }
                });

            migrationBuilder.InsertData(
                table: "users_20ts24tu",
                columns: new[] { "id", "active", "created_at", "departament_id", "email", "login", "password", "person_id", "removed", "status_id", "token", "updated_at", "user_type_id" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "admin", "X85cpohQrV+USeuUGKBe8qQ4PKBd1oT1MYOu8wOr2V4=", null, null, null, null, null, 1 },
                    { 2, null, null, null, null, "user", "5sI/jrzFz2ijUO3dRLlGnjdVl5zBYO4OInDwyb/qPYk=", null, null, null, null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "districts_20ts24tu",
                columns: new[] { "id", "territorie_id", "title" },
                values: new object[,]
                {
                    { 1, 8, "Boʻzatov tumani" },
                    { 3, 14, "Bandixon tumani" },
                    { 4, 16, "Tuproqqal''a tumani" },
                    { 10, 8, "Nukus shahar" },
                    { 12, 8, "Amudaryo tumani" },
                    { 13, 8, "Beruniy tumani" },
                    { 14, 8, "Qonlikoʻl tumani" },
                    { 15, 8, "Qoraoʻzak tumani" },
                    { 16, 8, "Kegeyli tumani" },
                    { 17, 8, "Qoʻngʻirot tumani" },
                    { 18, 8, "Muynoq tumani" },
                    { 19, 8, "Nukus tumani" },
                    { 20, 8, "Taxtakoʻprik tumani" },
                    { 21, 8, "Toʻrtkoʻl tumani" },
                    { 22, 8, "Xoʻjayli tumani" },
                    { 23, 8, "Chimboy tumani" },
                    { 24, 8, "Shoʻmanay tumani" },
                    { 25, 8, "Ellikqal''a tumani" },
                    { 26, 9, "Buxoro shahar" },
                    { 27, 9, "Buxoro tuman" },
                    { 28, 9, "Vobkent tuman" },
                    { 29, 9, "Gʻijduvon tuman" },
                    { 30, 9, "Jondor tuman" },
                    { 32, 9, "Kogon tuman" },
                    { 33, 9, "Olot tuman" },
                    { 34, 9, "Peshku tuman" },
                    { 35, 9, "Romitan tuman" },
                    { 36, 9, "Shofirkon tuman" },
                    { 37, 9, "Qorakoʻl tuman" },
                    { 38, 9, "Qorovulbozor tuman" },
                    { 39, 10, "Samarqand shahar" },
                    { 40, 10, "Oqdaryo tumani" },
                    { 41, 10, "Bulungʻur tumani" },
                    { 42, 10, "Jomboy tumani" },
                    { 43, 10, "Kattaqoʻrgʻon tumani" },
                    { 44, 10, "Kattaqoʻrgʻon shahar" },
                    { 45, 10, "Qoʻshrabod tumani" },
                    { 46, 10, "Narpay tumani" },
                    { 47, 10, "Nurobod tumani" },
                    { 48, 10, "Payariq tumani" },
                    { 49, 10, "Pastdargʻom tumani" },
                    { 50, 10, "Paxtachi tumani" },
                    { 51, 10, "Samarqand tumani" },
                    { 53, 10, "Tayloq tumani" },
                    { 54, 10, "Urgut tumani" },
                    { 55, 11, "Navoiy shahar" },
                    { 56, 11, "Karmana tumani" },
                    { 57, 11, "Navbaxor tumani" },
                    { 58, 11, "Nurota tumani - Gʻozgʻon shahri" },
                    { 59, 11, "Xatirchi tumani" },
                    { 60, 11, "Qiziltepa tumani" },
                    { 61, 11, "Konimex tumani" },
                    { 62, 11, "Uchquduq tumani" },
                    { 63, 11, "Zarafshon shahar" },
                    { 64, 11, "Tomdi tumani" },
                    { 65, 12, "Andijon shahar" },
                    { 66, 12, "Xonobod shahar" },
                    { 67, 12, "Andijon tumani" },
                    { 68, 12, "Asaka tumani" },
                    { 69, 12, "Baliqchi tumani" },
                    { 70, 12, "Boʻz tumani" },
                    { 71, 12, "Buloqboshi tumani" },
                    { 72, 12, "Jalolquduq tumani" },
                    { 73, 12, "Izboskan tumani" },
                    { 74, 12, "Ulugʻnor tumani" },
                    { 75, 12, "Qoʻrgʻontepa tumani" },
                    { 76, 12, "Marxamat tumani" },
                    { 77, 12, "Oltinkoʻl tumani" },
                    { 78, 12, "Paxtaobod tumani" },
                    { 79, 12, "Hoʻjaobod tumani" },
                    { 80, 12, "Shaxrixon tumani" },
                    { 82, 13, "Margʻilon shahar" },
                    { 83, 13, "Fargʻona shahar" },
                    { 84, 13, "Quvasoy shahar" },
                    { 85, 13, "Qoʻqon shahar" },
                    { 86, 13, "Bogʻdod tumani" },
                    { 87, 13, "Beshariq tumani" },
                    { 88, 13, "Buvayda tumani" },
                    { 89, 13, "Dangʻara tumani" },
                    { 90, 13, "Yozyovon tumani" },
                    { 91, 13, "Oltiariq tumani" },
                    { 92, 13, "Qoʻshtepa tumani" },
                    { 93, 13, "Rishton tumani" },
                    { 94, 13, "Soʻx tumani" },
                    { 95, 13, "Toshloq tumani" },
                    { 96, 13, "Uchkoʻprik tumani" },
                    { 97, 13, "Fargʻona tumani" },
                    { 98, 13, "Furqat tumani" },
                    { 99, 13, "Oʻzbekiston tumani" },
                    { 100, 13, "Quva tumani" },
                    { 101, 14, "Angor tumani" },
                    { 102, 14, "Boysun tumani" },
                    { 103, 14, "Denov tumani" },
                    { 104, 14, "Jarqoʻrgʻon tumani" },
                    { 105, 14, "Qiziriq tumani" },
                    { 106, 14, "Qumqoʻrgʻon tumani" },
                    { 107, 14, "Muzrabot tumani" },
                    { 108, 14, "Oltinsoy tumani" },
                    { 109, 14, "Sariosiyo tumani" },
                    { 110, 14, "Termiz tumani" },
                    { 111, 14, "Termiz shahar" },
                    { 112, 14, "Uzun tumani" },
                    { 113, 14, "Sherobod tumani" },
                    { 114, 14, "Shoʻrchi tumani" },
                    { 115, 15, "Oqoltin tumani" },
                    { 116, 15, "Boyovut tumani" },
                    { 117, 15, "Guliston tumani" },
                    { 118, 15, "Mirzaobod tumani" },
                    { 119, 15, "Sayxunobod tumani" },
                    { 120, 15, "Sirdaryo tumani" },
                    { 121, 15, "Sardoba tumani" },
                    { 122, 15, "Xovos tumani" },
                    { 123, 15, "Guliston shahar" },
                    { 124, 15, "Shirin shahar" },
                    { 126, 15, "Yangier shahar" },
                    { 127, 16, "Urganch shahar" },
                    { 128, 16, "Bogʻot tumani" },
                    { 129, 16, "Gurlan tumani" },
                    { 130, 16, "Xozarasp tumani" },
                    { 131, 16, "Xiva tumani" },
                    { 132, 16, "Xonqa tumani" },
                    { 133, 16, "Urganch tumani" },
                    { 134, 16, "Qoʻshkoʻpir tumani" },
                    { 135, 16, "Shovot tumani" },
                    { 136, 16, "Yangiariq tumani" },
                    { 137, 16, "Yangibozor tumani" },
                    { 138, 17, "Angren shahar" },
                    { 139, 17, "Bekobod shahar" },
                    { 140, 17, "Olmaliq shahar" },
                    { 141, 17, "Chirchiq shahar" },
                    { 142, 17, "Bekobod tumani" },
                    { 143, 17, "Boʻka tumani" },
                    { 144, 17, "Boʻstonliq tumani" },
                    { 145, 17, "Qibray tumani" },
                    { 146, 17, "Zangiota tumani" },
                    { 148, 17, "Quyichirchiq tumani" },
                    { 149, 17, "Oqqoʻrgʻon tumani" },
                    { 150, 17, "Oxongaron tumani" },
                    { 151, 17, "Parkent tumani" },
                    { 152, 17, "Pskent tumani" },
                    { 153, 17, "Oʻrtachirchiq tumani - Yangihayot tumani" },
                    { 154, 17, "Chinoz tumani" },
                    { 155, 17, "Yuqorichirchiq tumani" },
                    { 156, 17, "Yangiyoʻl tumani - Yangihayot tumani" },
                    { 158, 18, "Qarshi shahar" },
                    { 159, 18, "Gʻuzor tumani" },
                    { 160, 18, "Qarshi tumani" },
                    { 161, 18, "Kasbi tumani" },
                    { 162, 18, "Koson tumani" },
                    { 163, 18, "Kitob tumani" },
                    { 164, 18, "Mirishkor tumani" },
                    { 165, 18, "Muborak tumani" },
                    { 166, 18, "Nishon tumani" },
                    { 167, 18, "Chiroqchi tumani" },
                    { 168, 18, "Shaxrisabz tumani" },
                    { 170, 18, "Qamashi tumani" },
                    { 171, 18, "Dexqonobod tumani" },
                    { 172, 18, "Yakkabogʻ tumani" },
                    { 173, 19, "Jizzax shahar" },
                    { 174, 19, "Baxmal tumani" },
                    { 175, 19, "Doʻstlik tumani" },
                    { 176, 19, "Gʻallaorol tumani" },
                    { 177, 19, "Sh.Rashidov tumani" },
                    { 178, 19, "Zarbdor tumani" },
                    { 179, 19, "Zafarobod tumani" },
                    { 180, 19, "Zomin tumani" },
                    { 181, 19, "Paxtakor tumani" },
                    { 182, 19, "Mirzachoʻl tumani" },
                    { 183, 19, "Forish tumani" },
                    { 184, 19, "Yangiobod tumani" },
                    { 185, 21, "Namangan shahar" },
                    { 186, 21, "Mingbuloq tumani" },
                    { 189, 21, "Pop tumani" },
                    { 190, 21, "Norin tumani" },
                    { 191, 21, "Toʻraqoʻrgʻon tumani" },
                    { 192, 21, "Uychi tumani" },
                    { 194, 21, "Chortoq tumani" },
                    { 195, 21, "Chust tumani" },
                    { 196, 21, "Yangiqoʻrgʻon tumani" },
                    { 198, 22, "Yunusobod tumani" },
                    { 199, 22, "Mirobod tumani" },
                    { 200, 22, "Yakkasaroy tumani" },
                    { 201, 22, "Olmazor tumani" },
                    { 202, 22, "Bektemir tumani - Yangihayot tumani" },
                    { 203, 22, "Yashnobod tumani" },
                    { 204, 22, "Chilonzor tumani" },
                    { 205, 22, "Uchtepa tumani" },
                    { 207, 22, "Mirzo Ulugʻbek tumani" },
                    { 208, 22, "Sergeli tumani - Yangihayot tumani" },
                    { 209, 10, "Ishtixon tumani" },
                    { 210, 9, "Kogon shahar" },
                    { 211, 19, "Arnasoy tumani" },
                    { 212, 22, "Shayxontoxur tumani" },
                    { 214, 21, "Namangan tumani" },
                    { 215, 21, "Uchqoʻrgʻon tumani" },
                    { 216, 21, "Kosonsoy tumani" },
                    { 217, 16, "Xiva shahar" },
                    { 218, 8, "Taxiatosh" },
                    { 219, 18, "Shaxrisabz shahar" },
                    { 220, 17, "Toshkent tumani" },
                    { 221, 17, "Yangiyoʻl shahar" },
                    { 222, 17, "Ohangaron shahar" },
                    { 223, 17, "Nurafshon shahar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_country_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_district_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_employe_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "employe_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_file_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_gender_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_neighborhood_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "neighborhood_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_territorie_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "territorie_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_appeal_to~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "appeal_to_rector_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_country_t~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "country_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_district_~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "district_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_employe_t~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "employe_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_file_tran~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "file_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_gender_tr~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "gender_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_language_~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_neighborh~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "neighborhood_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_translations_20ts24tu_territori~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "territorie_translation_ididid");

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
                name: "IX_countries_translations_20ts24tu_country_id",
                table: "countries_translations_20ts24tu",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_translations_20ts24tu_language_id",
                table: "countries_translations_20ts24tu",
                column: "language_id");

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
                name: "IX_districts_20ts24tu_territorie_id",
                table: "districts_20ts24tu",
                column: "territorie_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_translations_20ts24tu_district_id",
                table: "districts_translations_20ts24tu",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_translations_20ts24tu_language_id",
                table: "districts_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_translations_20ts24tu_territorie_translation_id",
                table: "districts_translations_20ts24tu",
                column: "territorie_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_employments_20ts24tu_translations_20ts24tu_employment_id",
                table: "employments_20ts24tu_translations_20ts24tu",
                column: "employment_id");

            migrationBuilder.CreateIndex(
                name: "IX_employments_20ts24tu_translations_20ts24tu_language_id",
                table: "employments_20ts24tu_translations_20ts24tu",
                column: "language_id");

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
                name: "IX_neighborhoods_20ts24tu_district_id",
                table: "neighborhoods_20ts24tu",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_translations_20ts24tu_district_translation_id",
                table: "neighborhoods_translations_20ts24tu",
                column: "district_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_translations_20ts24tu_language_id",
                table: "neighborhoods_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_translations_20ts24tu_neighborhood_id",
                table: "neighborhoods_translations_20ts24tu",
                column: "neighborhood_id");

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
                name: "IX_territories_20ts24tu_country_id",
                table: "territories_20ts24tu",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_territories_translations_20ts24tu_country_translation_id",
                table: "territories_translations_20ts24tu",
                column: "country_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_territories_translations_20ts24tu_language_id",
                table: "territories_translations_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_territories_translations_20ts24tu_territorie_id",
                table: "territories_translations_20ts24tu",
                column: "territorie_id");

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
                name: "FK_appeals_to_rectors_20ts24tu_files_20ts24tu_file_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "file_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_countries~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "country_translation_id",
                principalTable: "countries_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_districts~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "district_translation_id",
                principalTable: "districts_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_employmen~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "employe_translation_id",
                principalTable: "employments_20ts24tu_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_files_tra~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "file_translation_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_genders_t~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "gender_translation_id",
                principalTable: "genders_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_languages~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_neighborh~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "neighborhood_translation_id",
                principalTable: "neighborhoods_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_translations_20ts24tu_territori~",
                table: "appeals_to_rectors_20ts24tu_translations_20ts24tu",
                column: "territorie_translation_ididid",
                principalTable: "territories_translations_20ts24tu",
                principalColumn: "id");

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
                name: "FK_countries_translations_20ts24tu_languages_20ts24tu_language~",
                table: "countries_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
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
                name: "FK_districts_translations_20ts24tu_languages_20ts24tu_language~",
                table: "districts_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_districts_translations_20ts24tu_territories_translations_20~",
                table: "districts_translations_20ts24tu",
                column: "territorie_translation_id",
                principalTable: "territories_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employments_20ts24tu_translations_20ts24tu_languages_20ts24~",
                table: "employments_20ts24tu_translations_20ts24tu",
                column: "language_id",
                principalTable: "languages_20ts24tu",
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
                name: "appeals_to_rectors_20ts24tu_translations_20ts24tu");

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
                name: "appeals_to_rectors_20ts24tu");

            migrationBuilder.DropTable(
                name: "employments_20ts24tu_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "neighborhoods_translations_20ts24tu");

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
                name: "employments_20ts24tu");

            migrationBuilder.DropTable(
                name: "districts_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "neighborhoods_20ts24tu");

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
                name: "territories_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "districts_20ts24tu");

            migrationBuilder.DropTable(
                name: "statuses_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "site_types_20ts24tu");

            migrationBuilder.DropTable(
                name: "countries_translations_20ts24tu");

            migrationBuilder.DropTable(
                name: "territories_20ts24tu");

            migrationBuilder.DropTable(
                name: "languages_20ts24tu");

            migrationBuilder.DropTable(
                name: "countries_20ts24tu");

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
