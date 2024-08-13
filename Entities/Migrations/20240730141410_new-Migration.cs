using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations;

/// <inheritdoc />
public partial class newMigration : Migration
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
                status = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "countries_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_countries_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_countries_20ts24tu_statuses_20ts24tu_status_id",
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
                type = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
            name: "document_teacher_110_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "text", nullable: true),
                parent_id = table.Column<int>(type: "integer", nullable: true),
                indicator = table.Column<bool>(type: "boolean", nullable: true),
                one_indicator = table.Column<bool>(type: "boolean", nullable: true),
                two_indicator = table.Column<bool>(type: "boolean", nullable: true),
                max_score = table.Column<double>(type: "double precision", nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                document_sequence_string = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_document_teacher_110_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_document_teacher_110_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "employee_types_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_employee_types_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_employee_types_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "employments_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_employments_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_employments_20ts24tu_statuses_20ts24tu_status_id",
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
                gender = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "menu_types_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_menu_types_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_menu_types_20ts24tu_statuses_20ts24tu_status_id",
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
                type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "tokens_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                token = table.Column<string>(type: "text", nullable: false),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_tokens_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_tokens_20ts24tu_statuses_20ts24tu_status_id",
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
                type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "territories_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                country_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_territories_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_territories_20ts24tu_countries_20ts24tu_country_id",
                    column: x => x.country_id,
                    principalTable: "countries_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_territories_20ts24tu_statuses_20ts24tu_status_id",
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_districts_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_districts_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_neighborhoods_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_neighborhoods_20ts24tu_districts_20ts24tu_district_id",
                    column: x => x.district_id,
                    principalTable: "districts_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_neighborhoods_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "appeal_to_employee_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                subject = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                message = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                user_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_appeal_to_employee_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_appeal_to_employee_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "appeal_to_employee_translation_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                subject = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                message = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_appeal_to_employee_translation_20ts24tu", x => x.id);
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
                addres = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                fio_ = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                gender_id = table.Column<int>(type: "integer", nullable: true),
                employe_id = table.Column<int>(type: "integer", nullable: true),
                telephone_number_one = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                telephone_number_two = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                file_id = table.Column<int>(type: "integer", nullable: true),
                appeal = table.Column<string>(type: "text", nullable: true),
                confirm = table.Column<bool>(type: "boolean", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
            name: "appeals_to_rectors_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                language_id = table.Column<int>(type: "integer", nullable: true),
                country_translation_id = table.Column<int>(type: "integer", nullable: true),
                territorie_translation_id = table.Column<int>(type: "integer", nullable: true),
                district_translation_id = table.Column<int>(type: "integer", nullable: true),
                neighborhood_translation_id = table.Column<int>(type: "integer", nullable: true),
                addres = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                fio_ = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                gender_translation_id = table.Column<int>(type: "integer", nullable: true),
                employe_translation_id = table.Column<int>(type: "integer", nullable: true),
                telephone_number_one = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                telephone_number_two = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                file_translation_id = table.Column<int>(type: "integer", nullable: true),
                appeal = table.Column<string>(type: "text", nullable: true),
                confirm = table.Column<bool>(type: "boolean", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_appeals_to_rectors_translations_20ts24tu", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "blogs_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                text = table.Column<string>(type: "text", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                event_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                text = table.Column<string>(type: "text", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                event_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                language_id = table.Column<int>(type: "integer", nullable: true),
                country_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
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
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                text = table.Column<string>(type: "text", nullable: true),
                parent_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                img_id = table.Column<int>(type: "integer", nullable: true),
                img_icon_id = table.Column<int>(type: "integer", nullable: true),
                position = table.Column<int>(type: "integer", nullable: true),
                favorite = table.Column<bool>(type: "boolean", nullable: true),
                departament_type_id = table.Column<int>(type: "integer", nullable: true),
                hemis_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
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
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                text = table.Column<string>(type: "text", nullable: true),
                parent_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                img_id = table.Column<int>(type: "integer", nullable: true),
                img_icon_id = table.Column<int>(type: "integer", nullable: true),
                position = table.Column<int>(type: "integer", nullable: true),
                favorite = table.Column<bool>(type: "boolean", nullable: true),
                departament_type_translation_id = table.Column<int>(type: "integer", nullable: true),
                departament_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_departament_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_departament_translations_20ts24tu_departament_20ts24tu_depa~",
                    column: x => x.departament_id,
                    principalTable: "departament_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "departament_types_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                type = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
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
            name: "document_teacher_110_set_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                person_id = table.Column<int>(type: "integer", nullable: true),
                old_year = table.Column<int>(type: "integer", nullable: true),
                new_year = table.Column<int>(type: "integer", nullable: true),
                document_id = table.Column<int>(type: "integer", nullable: true),
                file_id = table.Column<int>(type: "integer", nullable: true),
                comment = table.Column<string>(type: "text", nullable: true),
                score = table.Column<double>(type: "double precision", nullable: true),
                sequence_status = table.Column<int>(type: "integer", nullable: true),
                reason_for_rejection = table.Column<string>(type: "text", nullable: true),
                rejection = table.Column<bool>(type: "boolean", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_document_teacher_110_set_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_document_teacher_110_set_20ts24tu_document_teacher_110_20ts~",
                    column: x => x.document_id,
                    principalTable: "document_teacher_110_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_document_teacher_110_set_20ts24tu_statuses_20ts24tu_status_~",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "employee_types_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                employee_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_employee_types_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_employee_types_translations_20ts24tu_employee_types_20ts24t~",
                    column: x => x.employee_id,
                    principalTable: "employee_types_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "employments_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                employment_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_employments_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_employments_translations_20ts24tu_employments_20ts24tu_empl~",
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
            name: "interactive_services_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                url_ = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                favorite = table.Column<bool>(type: "boolean", nullable: true),
                img_id = table.Column<int>(type: "integer", nullable: true),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_interactive_services_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_interactive_services_20ts24tu_files_20ts24tu_icon_id",
                    column: x => x.icon_id,
                    principalTable: "files_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_20ts24tu_files_20ts24tu_img_id",
                    column: x => x.img_id,
                    principalTable: "files_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_20ts24tu_statuses_20ts24tu_status_id",
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title_short = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                firstName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                lastName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                fathers_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                gender_id = table.Column<int>(type: "integer", nullable: true),
                pinfl = table.Column<string>(type: "text", nullable: true),
                passport_text = table.Column<string>(type: "text", nullable: true),
                passport_number = table.Column<string>(type: "text", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                img_id = table.Column<int>(type: "integer", nullable: true),
                departament_id = table.Column<int>(type: "integer", nullable: true),
                employee_type_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_persons_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_persons_20ts24tu_departament_20ts24tu_departament_id",
                    column: x => x.departament_id,
                    principalTable: "departament_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_20ts24tu_employee_types_20ts24tu_employee_type_id",
                    column: x => x.employee_type_id,
                    principalTable: "employee_types_20ts24tu",
                    principalColumn: "id");
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
            name: "statistical_numbers_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                numbers = table.Column<string>(type: "text", nullable: false),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_statistical_numbers_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_statistical_numbers_20ts24tu_files_20ts24tu_icon_id",
                    column: x => x.icon_id,
                    principalTable: "files_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_statistical_numbers_20ts24tu_statuses_20ts24tu_status_id",
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
                status = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "persons_data_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                persons_id = table.Column<int>(type: "integer", nullable: true),
                biography_json = table.Column<string>(type: "text", nullable: true),
                birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                degree = table.Column<string>(type: "text", nullable: true),
                experience_year = table.Column<int>(type: "integer", nullable: true),
                phone_number1 = table.Column<string>(type: "text", nullable: true),
                phone_number2 = table.Column<string>(type: "text", nullable: true),
                orchid = table.Column<string>(type: "text", nullable: true),
                scopus_id = table.Column<string>(type: "text", nullable: true),
                address = table.Column<string>(type: "text", nullable: true),
                languages_uz = table.Column<int>(type: "integer", nullable: true),
                languages_en = table.Column<int>(type: "integer", nullable: true),
                languages_ru = table.Column<int>(type: "integer", nullable: true),
                languages_any_title = table.Column<string>(type: "text", nullable: true),
                languages_any = table.Column<int>(type: "integer", nullable: true),
                experience_json = table.Column<string>(type: "text", nullable: true),
                scientific_activity_json = table.Column<string>(type: "text", nullable: true),
                portfolio_json = table.Column<string>(type: "text", nullable: true),
                blog_json = table.Column<string>(type: "text", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_persons_data_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_persons_data_20ts24tu_persons_20ts24tu_persons_id",
                    column: x => x.persons_id,
                    principalTable: "persons_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_data_20ts24tu_statuses_20ts24tu_status_id",
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
                login = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                password = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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

        migrationBuilder.CreateTable(
            name: "genders_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                gender = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
            name: "menu_types_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                menu_type_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_menu_types_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_menu_types_translations_20ts24tu_languages_20ts24tu_languag~",
                    column: x => x.language_id,
                    principalTable: "languages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_types_translations_20ts24tu_menu_types_20ts24tu_menu_t~",
                    column: x => x.menu_type_id,
                    principalTable: "menu_types_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_types_translations_20ts24tu_statuses_translations_20ts~",
                    column: x => x.status_translation_id,
                    principalTable: "statuses_translations_20ts24tu",
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
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
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
                table.ForeignKey(
                    name: "FK_neighborhoods_translations_20ts24tu_statuses_translations_2~",
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
                type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
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
            name: "territories_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                language_id = table.Column<int>(type: "integer", nullable: true),
                territorie_id = table.Column<int>(type: "integer", nullable: true),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                country_translation_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
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
                    name: "FK_territories_translations_20ts24tu_statuses_translations_20t~",
                    column: x => x.status_translation_id,
                    principalTable: "statuses_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_territories_translations_20ts24tu_territories_20ts24tu_terr~",
                    column: x => x.territorie_id,
                    principalTable: "territories_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "user_types_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                files_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                crated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                firstName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                lastName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                fathers_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                gender_id = table.Column<int>(type: "integer", nullable: true),
                persons_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                departament_translation_id = table.Column<int>(type: "integer", nullable: true),
                employee_type_translation_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_persons_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_persons_translations_20ts24tu_departament_translations_20ts~",
                    column: x => x.departament_translation_id,
                    principalTable: "departament_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_translations_20ts24tu_employee_types_translations_2~",
                    column: x => x.employee_type_translation_id,
                    principalTable: "employee_types_translations_20ts24tu",
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
            name: "interactive_services_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                url_ = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                interactive_services_id = table.Column<int>(type: "integer", nullable: true),
                img_id = table.Column<int>(type: "integer", nullable: true),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                favorite = table.Column<bool>(type: "boolean", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_interactive_services_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_interactive_services_translations_20ts24tu_files_translatio~",
                    column: x => x.icon_id,
                    principalTable: "files_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_translations_20ts24tu_files_translati~1",
                    column: x => x.img_id,
                    principalTable: "files_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_translations_20ts24tu_interactive_serv~",
                    column: x => x.interactive_services_id,
                    principalTable: "interactive_services_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_translations_20ts24tu_languages_20ts24~",
                    column: x => x.language_id,
                    principalTable: "languages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_interactive_services_translations_20ts24tu_statuses_transla~",
                    column: x => x.status_translation_id,
                    principalTable: "statuses_translations_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "statistical_numbers_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                numbers = table.Column<string>(type: "text", nullable: false),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                statistical_numbers_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_statistical_numbers_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_statistical_numbers_translations_20ts24tu_files_translation~",
                    column: x => x.icon_id,
                    principalTable: "files_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_statistical_numbers_translations_20ts24tu_languages_20ts24t~",
                    column: x => x.language_id,
                    principalTable: "languages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_statistical_numbers_translations_20ts24tu_statistical_numbe~",
                    column: x => x.statistical_numbers_id,
                    principalTable: "statistical_numbers_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_statistical_numbers_translations_20ts24tu_statuses_translat~",
                    column: x => x.status_translation_id,
                    principalTable: "statuses_translations_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "menu_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                parent_id = table.Column<int>(type: "integer", nullable: false),
                position = table.Column<int>(type: "integer", nullable: true),
                high_menu = table.Column<int>(type: "integer", nullable: true),
                menu_type_id = table.Column<int>(type: "integer", nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                link_ = table.Column<string>(type: "text", nullable: true),
                top_menu = table.Column<bool>(type: "boolean", nullable: false),
                blog_id = table.Column<int>(type: "integer", nullable: true),
                page_id = table.Column<int>(type: "integer", nullable: true),
                departament_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_menu_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_blogs_20ts24tu_blog_id",
                    column: x => x.blog_id,
                    principalTable: "blogs_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_departament_20ts24tu_departament_id",
                    column: x => x.departament_id,
                    principalTable: "departament_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_files_20ts24tu_icon_id",
                    column: x => x.icon_id,
                    principalTable: "files_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_menu_types_20ts24tu_menu_type_id",
                    column: x => x.menu_type_id,
                    principalTable: "menu_types_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_pages_20ts24tu_page_id",
                    column: x => x.page_id,
                    principalTable: "pages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_statuses_20ts24tu_status_id",
                    column: x => x.status_id,
                    principalTable: "statuses_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_20ts24tu_users_20ts24tu_user_id",
                    column: x => x.user_id,
                    principalTable: "users_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "pages_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                title_short = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
            name: "persons_data_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                persons_translation_id = table.Column<int>(type: "integer", nullable: true),
                persons_data_id = table.Column<int>(type: "integer", nullable: true),
                biography_json = table.Column<string>(type: "text", nullable: true),
                birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                degree = table.Column<string>(type: "text", nullable: true),
                experience_year = table.Column<int>(type: "integer", nullable: true),
                phone_number1 = table.Column<string>(type: "text", nullable: true),
                phone_number2 = table.Column<string>(type: "text", nullable: true),
                orchid = table.Column<string>(type: "text", nullable: true),
                scopus_id = table.Column<string>(type: "text", nullable: true),
                address = table.Column<string>(type: "text", nullable: true),
                languages_uz = table.Column<int>(type: "integer", nullable: true),
                languages_en = table.Column<int>(type: "integer", nullable: true),
                languages_ru = table.Column<int>(type: "integer", nullable: true),
                languages_any_title = table.Column<string>(type: "text", nullable: true),
                languages_any = table.Column<int>(type: "integer", nullable: true),
                experience_json = table.Column<string>(type: "text", nullable: true),
                scientific_activity_json = table.Column<string>(type: "text", nullable: true),
                portfolio_json = table.Column<string>(type: "text", nullable: true),
                blog_json = table.Column<string>(type: "text", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                status_translation_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_persons_data_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_persons_data_translations_20ts24tu_languages_20ts24tu_langu~",
                    column: x => x.language_id,
                    principalTable: "languages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_data_translations_20ts24tu_persons_data_20ts24tu_pe~",
                    column: x => x.persons_data_id,
                    principalTable: "persons_data_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_data_translations_20ts24tu_persons_translations_20t~",
                    column: x => x.persons_translation_id,
                    principalTable: "persons_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_persons_data_translations_20ts24tu_statuses_translations_20~",
                    column: x => x.status_translation_id,
                    principalTable: "statuses_translations_20ts24tu",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "menu_translations_20ts24tu",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                menu_id = table.Column<int>(type: "integer", nullable: true),
                parent_id = table.Column<int>(type: "integer", nullable: true),
                position = table.Column<int>(type: "integer", nullable: true),
                high_menu = table.Column<int>(type: "integer", nullable: true),
                menu_type_translation_id = table.Column<int>(type: "integer", nullable: true),
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
                icon_id = table.Column<int>(type: "integer", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                link_ = table.Column<string>(type: "text", nullable: true),
                top_menu = table.Column<bool>(type: "boolean", nullable: false),
                blog_translation_id = table.Column<int>(type: "integer", nullable: true),
                page_translation_id = table.Column<int>(type: "integer", nullable: true),
                departament_translation_id = table.Column<int>(type: "integer", nullable: true),
                status_id = table.Column<int>(type: "integer", nullable: true),
                language_id = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_menu_translations_20ts24tu", x => x.id);
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_blogs_translations_20ts24tu_blog~",
                    column: x => x.blog_translation_id,
                    principalTable: "blogs_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_departament_translations_20ts24t~",
                    column: x => x.departament_translation_id,
                    principalTable: "departament_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_files_translations_20ts24tu_icon~",
                    column: x => x.icon_id,
                    principalTable: "files_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_languages_20ts24tu_language_id",
                    column: x => x.language_id,
                    principalTable: "languages_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_menu_20ts24tu_menu_id",
                    column: x => x.menu_id,
                    principalTable: "menu_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_menu_types_translations_20ts24tu~",
                    column: x => x.menu_type_translation_id,
                    principalTable: "menu_types_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_pages_translations_20ts24tu_page~",
                    column: x => x.page_translation_id,
                    principalTable: "pages_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_statuses_translations_20ts24tu_s~",
                    column: x => x.status_id,
                    principalTable: "statuses_translations_20ts24tu",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_menu_translations_20ts24tu_users_20ts24tu_user_id",
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
                title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
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
            table: "statuses_20ts24tu",
            columns: new[] { "id", "is_deleted", "name", "status" },
            values: new object[,]
            {
                { 1, false, "Faol", "Active" },
                { 2, false, "O'chirilgan", "Deleted" }
            });

        migrationBuilder.InsertData(
            table: "countries_20ts24tu",
            columns: new[] { "id", "status_id", "title" },
            values: new object[,]
            {
                { 1, 1, "O'zbekiston" },
                { 2, 1, "Boshqa" }
            });

        migrationBuilder.InsertData(
            table: "departament_types_20ts24tu",
            columns: new[] { "id", "status_id", "type" },
            values: new object[,]
            {
                { 1, 1, "Rektor" },
                { 2, 1, "Rektor yordamchisi" },
                { 3, 1, "Rektor maslahatchisi" },
                { 4, 1, "Kengash" },
                { 5, 1, "Boshqarma" },
                { 6, 1, "Markaz" },
                { 7, 1, "Bo'lim" },
                { 8, 1, "Assistent" },
                { 9, 1, "Litsey" },
                { 10, 1, "Texnikum" },
                { 11, 1, "Sektor" },
                { 12, 1, "Poligon" },
                { 13, 1, "Omborxona" },
                { 14, 1, "Muzey" },
                { 15, 1, "Psixolog" },
                { 16, 1, "Inshoot" },
                { 18, 1, "TTJ" },
                { 19, 1, "Qozonxona" },
                { 20, 1, "Xizmat" },
                { 21, 1, "Kotib" },
                { 22, 1, "Fakultet" },
                { 23, 1, "Yuriskonsult" },
                { 24, 1, "Devonxona" },
                { 25, 1, "Arxiv" }
            });

        migrationBuilder.InsertData(
            table: "employments_20ts24tu",
            columns: new[] { "id", "status_id", "title" },
            values: new object[,]
            {
                { 1, 1, "Band" },
                { 2, 1, "Ishsiz" },
                { 3, 1, "Nafaqada" },
                { 4, 1, "Talaba" }
            });

        migrationBuilder.InsertData(
            table: "genders_20ts24tu",
            columns: new[] { "id", "gender", "status_id" },
            values: new object[,]
            {
                { 1, "Erkak", 1 },
                { 2, "Ayol", 1 }
            });

        migrationBuilder.InsertData(
            table: "languages_20ts24tu",
            columns: new[] { "id", "code", "description", "details", "img_id", "status_id", "title", "title_short" },
            values: new object[,]
            {
                { 1, "en", null, null, null, 1, "England", null },
                { 2, "ru", null, null, null, 1, "Russian", null }
            });

        migrationBuilder.InsertData(
            table: "menu_types_20ts24tu",
            columns: new[] { "id", "status_id", "title" },
            values: new object[,]
            {
                { 1, 1, "Main" },
                { 2, 1, "Blog" },
                { 3, 1, "Page" },
                { 4, 1, "Link" },
                { 5, 1, "Faculty" },
                { 6, 1, "Department" },
                { 7, 1, "Section" }
            });

        migrationBuilder.InsertData(
            table: "user_types_20ts24tu",
            columns: new[] { "id", "status_id", "type" },
            values: new object[] { 1, 1, "Admin" });

        migrationBuilder.InsertData(
            table: "departament_20ts24tu",
            columns: new[] { "id", "crated_at", "departament_type_id", "description", "favorite", "hemis_id", "img_icon_id", "img_id", "parent_id", "position", "status_id", "text", "title", "title_short", "updated_at" },
            values: new object[,]
            {
                { 1, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4236), 1, null, null, null, null, null, 0, null, 1, null, "Rektor", null, null },
                { 2, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4242), 2, null, null, null, null, null, 1, null, 1, null, "Rektorning birinchi o'rinbosari (xorijiy mutaxasis)", null, null },
                { 3, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4244), 3, null, null, null, null, null, 1, null, 1, null, "Universitetdagi istiqbolli va strategik vazifalarni amalga oshirish masalalari bo'yicha rektor maslahatchisi", null, null },
                { 4, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4245), 3, null, null, null, null, null, 1, null, 1, null, "Talabalar orasida ijtimoiy ma'naviy muhit barqarorligini ta'minlashga mas'ul bo'lgan rektor maslahatchisi", null, null },
                { 5, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4247), 4, null, null, null, null, null, 1, null, 1, null, "Kuzatuv kengashi", null, null },
                { 6, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4249), 4, null, null, null, null, null, 1, null, 1, null, "Jamoatchilik kengashi", null, null },
                { 7, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4250), 4, null, null, null, null, null, 1, null, 1, null, "Universitet kengashi", null, null },
                { 8, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4283), 2, null, null, null, null, null, 1, null, 1, null, "Akademik faoliyat bo'yicha prorektor", null, null },
                { 9, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4316), 2, null, null, null, null, null, 1, null, 1, null, "Yoshlar masalalari va ma'naviy - ma'rifiy ishlar bo'yicha birinchi prorektor", null, null },
                { 10, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4338), 2, null, null, null, null, null, 1, null, 1, null, "Ilmiy ishlar va innovatsiyalar bo'yicha prorektor", null, null },
                { 11, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4354), 2, null, null, null, null, null, 1, null, 1, null, "Xalqaro hamkorlik bo'yicha prorektor", null, null },
                { 12, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4365), 2, null, null, null, null, null, 1, null, 1, null, "Moliya - iqtisod ishlari bo'yicha prorektor", null, null },
                { 13, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4383), 2, null, null, null, null, null, 1, null, 1, null, "Ishlab chiqarish korxonalar bilan integratsiya bo'yicha prorektor", null, null },
                { 14, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4286), 5, null, null, null, null, null, 8, null, 1, null, "Akademik faoliyati boshqarmasi", null, null },
                { 15, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4288), 6, null, null, null, null, null, 8, null, 1, null, "Raqamli ta'lim texnologiyalari markazi", null, null },
                { 16, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4289), 6, null, null, null, null, null, 8, null, 1, null, "Axborot - resurs markazi", null, null },
                { 17, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4291), 7, null, null, null, null, null, 8, null, 1, null, "Tahririy nashriyoti va poligrafiya bo'limi", null, null },
                { 18, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4292), 7, null, null, null, null, null, 8, null, 1, null, "Magistratura bo'limi", null, null },
                { 19, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4294), 7, null, null, null, null, null, 8, null, 1, null, "Sirtqi bo'lim", null, null },
                { 20, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4296), 8, null, null, null, null, null, 8, null, 1, null, "O'quv ishlari bo'yicha assistent", null, null },
                { 21, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4297), 6, null, null, null, null, null, 8, null, 1, null, "Talabalarga xizmat ko'rsatish markazi (Ofis registrator)", null, null },
                { 22, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4310), 9, null, null, null, null, null, 8, null, 1, null, "Akademik litsey", null, null },
                { 23, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4311), 10, null, null, null, null, null, 8, null, 1, null, "Andijon transport texnikumi", null, null },
                { 24, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4313), 10, null, null, null, null, null, 8, null, 1, null, "Samarqand temir yo'l texnikumi", null, null },
                { 25, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4314), 10, null, null, null, null, null, 8, null, 1, null, "Nukus transport texnikumi", null, null },
                { 26, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4299), 11, null, null, null, null, null, 21, null, 1, null, "Akademik mobillilikni muvofiqlashtirish va talabalar registratsiyasi (admission ofisi) sektori", null, null },
                { 27, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4301), 11, null, null, null, null, null, 21, null, 1, null, "Talabalar bilan ishlash sektori", null, null },
                { 28, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4302), 7, null, null, null, null, null, 21, null, 1, null, "Ikkinchi bo'lim", null, null },
                { 29, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4304), 7, null, null, null, null, null, 21, null, 1, null, "Talabalarni turar joy bilan ta'minlash ishlarini muvofiqlashtiruvchi bo'lim", null, null },
                { 30, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4318), 7, null, null, null, null, null, 9, null, 1, null, "Yoshlar bilan ishlash, ma'naviy - ma'rifat bo'limi", null, null },
                { 31, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4319), 14, null, null, null, null, null, 9, null, 1, null, "Muzey", null, null },
                { 32, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4321), 15, null, null, null, null, null, 9, null, 1, null, "Psixolog", null, null },
                { 33, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4323), 16, null, null, null, null, null, 9, null, 1, null, "Sport inshootlari", null, null },
                { 34, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4331), 4, null, null, null, null, null, 9, null, 1, null, "Xotin - qizlar maslahat kengashi", null, null },
                { 35, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4333), 18, null, null, null, null, null, 9, null, 1, null, "TTJ (administratsiya va ishchi xodimlar)", null, null },
                { 36, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4335), 4, null, null, null, null, null, 9, null, 1, null, "Talabalar kengashi", null, null },
                { 37, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4337), 7, null, null, null, null, null, 9, null, 1, null, "Yoshlar ittifoqi", null, null },
                { 38, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4340), 7, null, null, null, null, null, 10, null, 1, null, "Ilmiy - tadqiqotlar, innovatsiyalar va ilmiy - pedagofik kadrlar tayyorlash bo'limi", null, null },
                { 39, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4342), 7, null, null, null, null, null, 10, null, 1, null, "Iqtidorli talabalarning ilmiy - tadqiqit faoliyatini tashkil etish bo'limi", null, null },
                { 40, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4343), 7, null, null, null, null, null, 10, null, 1, null, "Ilmiy - innovatsion va loyiha - konstruktorlik bo'limi", null, null },
                { 41, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4345), 7, null, null, null, null, null, 10, null, 1, null, "Ilmiy nashrlar bilan ishlash bo'limi", null, null },
                { 42, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4346), 4, null, null, null, null, null, 10, null, 1, null, "Ixtisoslashtirilgan ilmiy kengashlar", null, null },
                { 43, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4348), 7, null, null, null, null, null, 10, null, 1, null, "Ilmiy - innovatsion ishlanmalarni tijoratlashtirish bo'limi", null, null },
                { 44, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4350), 6, null, null, null, null, null, 10, null, 1, null, "Ilmiy - tadqiqot markazlari", null, null },
                { 45, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4351), 8, null, null, null, null, null, 10, null, 1, null, "Tadqiqot ishlari bo'yicha assistent", null, null },
                { 46, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4356), 5, null, null, null, null, null, 11, null, 1, null, "Xalqaro hamkorlik boshqarmasi", null, null },
                { 47, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4357), 7, null, null, null, null, null, 11, null, 1, null, "Akademik mobillik va xorijiy grantlar va institutlar bilan ishlash bo'limi", null, null },
                { 48, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4359), 7, null, null, null, null, null, 11, null, 1, null, "Xalqaro ta'lim dasturlari bilan ishlash bo'limi", null, null },
                { 49, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4360), 6, null, null, null, null, null, 11, null, 1, null, "O'zbekiston - Turkiya hamkorlik markazi", null, null },
                { 50, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4362), 6, null, null, null, null, null, 11, null, 1, null, "\"Language Club\" Xorijiy tillar markazi", null, null },
                { 51, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4364), 6, null, null, null, null, null, 11, null, 1, null, "Xorij bilan hamkorlik markazlari", null, null },
                { 52, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4367), 7, null, null, null, null, null, 12, null, 1, null, "Moliyalashtirish, buxgalteriya hisobi, hisoboti va tahlili bo'limi - Bosh hisobchi", null, null },
                { 53, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4369), 5, null, null, null, null, null, 12, null, 1, null, "Ishlar boshqarmasi", null, null },
                { 54, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4380), 12, null, null, null, null, null, 12, null, 1, null, "O'quv amaliyot poligoni", null, null },
                { 55, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4381), 13, null, null, null, null, null, 12, null, 1, null, "Omborxona", null, null },
                { 56, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4370), 7, null, null, null, null, null, 53, null, 1, null, "Xo'jalik bo'limi", null, null },
                { 57, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4372), 7, null, null, null, null, null, 53, null, 1, null, "Texnik ta'mirlash va tezkor qayta tiklash bo'limi", null, null },
                { 58, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4373), 7, null, null, null, null, null, 53, null, 1, null, "Fuqaro va mehnat muhofazasi bo'limi", null, null },
                { 59, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4375), 19, null, null, null, null, null, 53, null, 1, null, "Qozonxona", null, null },
                { 60, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4377), 7, null, null, null, null, null, 53, null, 1, null, "Transport xizmati bo'limi", null, null },
                { 61, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4378), 7, null, null, null, null, null, 53, null, 1, null, "Xavfsizlik xizmati bo'limi", null, null },
                { 62, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4385), 6, null, null, null, null, null, 13, null, 1, null, "Karera markazi", null, null },
                { 63, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4252), 7, null, null, null, null, null, 1, null, 1, null, "Birinchi bo'lim", null, null },
                { 64, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4254), 7, null, null, null, null, null, 1, null, 1, null, "Ta'lim sifatini nazorat qilish bo'limi", null, null },
                { 65, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4255), 20, null, null, null, null, null, 1, null, 1, null, "Ichki audit va moliyaviy nazorat xizmati", null, null },
                { 66, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4257), 7, null, null, null, null, null, 1, null, 1, null, "Korrupsiyaga qarshi kurashish \"Komplaens - nazorat\" tizimini boshqarish bo'limi", null, null },
                { 67, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4260), 21, null, null, null, null, null, 1, null, 1, null, "OTM kengashi kotibi", null, null },
                { 69, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4261), 20, null, null, null, null, null, 1, null, 1, null, "Rektor yordamchisi - protokol xizmati", null, null },
                { 70, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4263), 23, null, null, null, null, null, 1, null, 1, null, "Yuriskonsult", null, null },
                { 71, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4269), 20, null, null, null, null, null, 1, null, 1, null, "Matbuot xizmati", null, null },
                { 72, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4274), 7, null, null, null, null, null, 1, null, 1, null, "Inson resurslarini boshqarish bo'limi", null, null },
                { 73, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4275), 7, null, null, null, null, null, 1, null, 1, null, "Jismomniy va yuridik shaxslarning murojaatlari bilan ishlash, nazorat va monitoring bo'limi", null, null },
                { 74, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4277), 24, null, null, null, null, null, 1, null, 1, null, "Devonxona", null, null },
                { 75, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4279), 25, null, null, null, null, null, 1, null, 1, null, "Arxiv", null, null },
                { 76, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4280), 7, null, null, null, null, null, 1, null, 1, null, "Xalqaro rwytinglar bilan ishlash bo'limi", null, null },
                { 77, new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4282), 7, null, null, null, null, null, 1, null, 1, null, "Raqamli transformatsiya bo'limi", null, null }
            });

        migrationBuilder.InsertData(
            table: "statuses_translations_20ts24tu",
            columns: new[] { "id", "is_deleted", "language_id", "name", "status", "status_id" },
            values: new object[,]
            {
                { 1, false, 1, "Active", "Active", 1 },
                { 2, false, 1, "Deleted", "Deleted", 2 },
                { 3, false, 2, "Активный", "Active", 1 },
                { 4, false, 2, "Удалено", "Deleted", 2 }
            });

        migrationBuilder.InsertData(
            table: "territories_20ts24tu",
            columns: new[] { "id", "country_id", "status_id", "title" },
            values: new object[,]
            {
                { 8, 1, 1, "Qoraqalpogʻiston Respublikasi" },
                { 9, 1, 1, "Buxoro viloyati" },
                { 10, 1, 1, "Samarqand viloyati" },
                { 11, 1, 1, "Navoiy viloyati" },
                { 12, 1, 1, "Andijon viloyati" },
                { 13, 1, 1, "Fargʻona viloyati" },
                { 14, 1, 1, "Surxondaryo viloyati" },
                { 15, 1, 1, "Sirdaryo viloyati" },
                { 16, 1, 1, "Xorazm viloyati" },
                { 17, 1, 1, "Toshkent viloyati" },
                { 18, 1, 1, "Qashqadaryo viloyati" },
                { 19, 1, 1, "Jizzax viloyati" },
                { 21, 1, 1, "Namangan viloyati" },
                { 22, 1, 1, "Toshkent shahri" }
            });

        migrationBuilder.InsertData(
            table: "users_20ts24tu",
            columns: new[] { "id", "active", "created_at", "email", "login", "password", "person_id", "removed", "status_id", "token", "updated_at", "user_type_id" },
            values: new object[] { 1, null, null, null, "admin", "X85cpohQrV+USeuUGKBe8qQ4PKBd1oT1MYOu8wOr2V4=", null, null, 1, null, null, 1 });

        migrationBuilder.InsertData(
            table: "districts_20ts24tu",
            columns: new[] { "id", "status_id", "territorie_id", "title" },
            values: new object[,]
            {
                { 1, 1, 8, "Boʻzatov tumani" },
                { 3, 1, 14, "Bandixon tumani" },
                { 4, 1, 16, "Tuproqqal''a tumani" },
                { 10, 1, 8, "Nukus shahar" },
                { 12, 1, 8, "Amudaryo tumani" },
                { 13, 1, 8, "Beruniy tumani" },
                { 14, 1, 8, "Qonlikoʻl tumani" },
                { 15, 1, 8, "Qoraoʻzak tumani" },
                { 16, 1, 8, "Kegeyli tumani" },
                { 17, 1, 8, "Qoʻngʻirot tumani" },
                { 18, 1, 8, "Muynoq tumani" },
                { 19, 1, 8, "Nukus tumani" },
                { 20, 1, 8, "Taxtakoʻprik tumani" },
                { 21, 1, 8, "Toʻrtkoʻl tumani" },
                { 22, 1, 8, "Xoʻjayli tumani" },
                { 23, 1, 8, "Chimboy tumani" },
                { 24, 1, 8, "Shoʻmanay tumani" },
                { 25, 1, 8, "Ellikqal''a tumani" },
                { 26, 1, 9, "Buxoro shahar" },
                { 27, 1, 9, "Buxoro tuman" },
                { 28, 1, 9, "Vobkent tuman" },
                { 29, 1, 9, "Gʻijduvon tuman" },
                { 30, 1, 9, "Jondor tuman" },
                { 32, 1, 9, "Kogon tuman" },
                { 33, 1, 9, "Olot tuman" },
                { 34, 1, 9, "Peshku tuman" },
                { 35, 1, 9, "Romitan tuman" },
                { 36, 1, 9, "Shofirkon tuman" },
                { 37, 1, 9, "Qorakoʻl tuman" },
                { 38, 1, 9, "Qorovulbozor tuman" },
                { 39, 1, 10, "Samarqand shahar" },
                { 40, 1, 10, "Oqdaryo tumani" },
                { 41, 1, 10, "Bulungʻur tumani" },
                { 42, 1, 10, "Jomboy tumani" },
                { 43, 1, 10, "Kattaqoʻrgʻon tumani" },
                { 44, 1, 10, "Kattaqoʻrgʻon shahar" },
                { 45, 1, 10, "Qoʻshrabod tumani" },
                { 46, 1, 10, "Narpay tumani" },
                { 47, 1, 10, "Nurobod tumani" },
                { 48, 1, 10, "Payariq tumani" },
                { 49, 1, 10, "Pastdargʻom tumani" },
                { 50, 1, 10, "Paxtachi tumani" },
                { 51, 1, 10, "Samarqand tumani" },
                { 53, 1, 10, "Tayloq tumani" },
                { 54, 1, 10, "Urgut tumani" },
                { 55, 1, 11, "Navoiy shahar" },
                { 56, 1, 11, "Karmana tumani" },
                { 57, 1, 11, "Navbaxor tumani" },
                { 58, 1, 11, "Nurota tumani - Gʻozgʻon shahri" },
                { 59, 1, 11, "Xatirchi tumani" },
                { 60, 1, 11, "Qiziltepa tumani" },
                { 61, 1, 11, "Konimex tumani" },
                { 62, 1, 11, "Uchquduq tumani" },
                { 63, 1, 11, "Zarafshon shahar" },
                { 64, 1, 11, "Tomdi tumani" },
                { 65, 1, 12, "Andijon shahar" },
                { 66, 1, 12, "Xonobod shahar" },
                { 67, 1, 12, "Andijon tumani" },
                { 68, 1, 12, "Asaka tumani" },
                { 69, 1, 12, "Baliqchi tumani" },
                { 70, 1, 12, "Boʻz tumani" },
                { 71, 1, 12, "Buloqboshi tumani" },
                { 72, 1, 12, "Jalolquduq tumani" },
                { 73, 1, 12, "Izboskan tumani" },
                { 74, 1, 12, "Ulugʻnor tumani" },
                { 75, 1, 12, "Qoʻrgʻontepa tumani" },
                { 76, 1, 12, "Marxamat tumani" },
                { 77, 1, 12, "Oltinkoʻl tumani" },
                { 78, 1, 12, "Paxtaobod tumani" },
                { 79, 1, 12, "Hoʻjaobod tumani" },
                { 80, 1, 12, "Shaxrixon tumani" },
                { 82, 1, 13, "Margʻilon shahar" },
                { 83, 1, 13, "Fargʻona shahar" },
                { 84, 1, 13, "Quvasoy shahar" },
                { 85, 1, 13, "Qoʻqon shahar" },
                { 86, 1, 13, "Bogʻdod tumani" },
                { 87, 1, 13, "Beshariq tumani" },
                { 88, 1, 13, "Buvayda tumani" },
                { 89, 1, 13, "Dangʻara tumani" },
                { 90, 1, 13, "Yozyovon tumani" },
                { 91, 1, 13, "Oltiariq tumani" },
                { 92, 1, 13, "Qoʻshtepa tumani" },
                { 93, 1, 13, "Rishton tumani" },
                { 94, 1, 13, "Soʻx tumani" },
                { 95, 1, 13, "Toshloq tumani" },
                { 96, 1, 13, "Uchkoʻprik tumani" },
                { 97, 1, 13, "Fargʻona tumani" },
                { 98, 1, 13, "Furqat tumani" },
                { 99, 1, 13, "Oʻzbekiston tumani" },
                { 100, 1, 13, "Quva tumani" },
                { 101, 1, 14, "Angor tumani" },
                { 102, 1, 14, "Boysun tumani" },
                { 103, 1, 14, "Denov tumani" },
                { 104, 1, 14, "Jarqoʻrgʻon tumani" },
                { 105, 1, 14, "Qiziriq tumani" },
                { 106, 1, 14, "Qumqoʻrgʻon tumani" },
                { 107, 1, 14, "Muzrabot tumani" },
                { 108, 1, 14, "Oltinsoy tumani" },
                { 109, 1, 14, "Sariosiyo tumani" },
                { 110, 1, 14, "Termiz tumani" },
                { 111, 1, 14, "Termiz shahar" },
                { 112, 1, 14, "Uzun tumani" },
                { 113, 1, 14, "Sherobod tumani" },
                { 114, 1, 14, "Shoʻrchi tumani" },
                { 115, 1, 15, "Oqoltin tumani" },
                { 116, 1, 15, "Boyovut tumani" },
                { 117, 1, 15, "Guliston tumani" },
                { 118, 1, 15, "Mirzaobod tumani" },
                { 119, 1, 15, "Sayxunobod tumani" },
                { 120, 1, 15, "Sirdaryo tumani" },
                { 121, 1, 15, "Sardoba tumani" },
                { 122, 1, 15, "Xovos tumani" },
                { 123, 1, 15, "Guliston shahar" },
                { 124, 1, 15, "Shirin shahar" },
                { 126, 1, 15, "Yangier shahar" },
                { 127, 1, 16, "Urganch shahar" },
                { 128, 1, 16, "Bogʻot tumani" },
                { 129, 1, 16, "Gurlan tumani" },
                { 130, 1, 16, "Xozarasp tumani" },
                { 131, 1, 16, "Xiva tumani" },
                { 132, 1, 16, "Xonqa tumani" },
                { 133, 1, 16, "Urganch tumani" },
                { 134, 1, 16, "Qoʻshkoʻpir tumani" },
                { 135, 1, 16, "Shovot tumani" },
                { 136, 1, 16, "Yangiariq tumani" },
                { 137, 1, 16, "Yangibozor tumani" },
                { 138, 1, 17, "Angren shahar" },
                { 139, 1, 17, "Bekobod shahar" },
                { 140, 1, 17, "Olmaliq shahar" },
                { 141, 1, 17, "Chirchiq shahar" },
                { 142, 1, 17, "Bekobod tumani" },
                { 143, 1, 17, "Boʻka tumani" },
                { 144, 1, 17, "Boʻstonliq tumani" },
                { 145, 1, 17, "Qibray tumani" },
                { 146, 1, 17, "Zangiota tumani" },
                { 148, 1, 17, "Quyichirchiq tumani" },
                { 149, 1, 17, "Oqqoʻrgʻon tumani" },
                { 150, 1, 17, "Oxongaron tumani" },
                { 151, 1, 17, "Parkent tumani" },
                { 152, 1, 17, "Pskent tumani" },
                { 153, 1, 17, "Oʻrtachirchiq tumani - Yangihayot tumani" },
                { 154, 1, 17, "Chinoz tumani" },
                { 155, 1, 17, "Yuqorichirchiq tumani" },
                { 156, 1, 17, "Yangiyoʻl tumani - Yangihayot tumani" },
                { 158, 1, 18, "Qarshi shahar" },
                { 159, 1, 18, "Gʻuzor tumani" },
                { 160, 1, 18, "Qarshi tumani" },
                { 161, 1, 18, "Kasbi tumani" },
                { 162, 1, 18, "Koson tumani" },
                { 163, 1, 18, "Kitob tumani" },
                { 164, 1, 18, "Mirishkor tumani" },
                { 165, 1, 18, "Muborak tumani" },
                { 166, 1, 18, "Nishon tumani" },
                { 167, 1, 18, "Chiroqchi tumani" },
                { 168, 1, 18, "Shaxrisabz tumani" },
                { 170, 1, 18, "Qamashi tumani" },
                { 171, 1, 18, "Dexqonobod tumani" },
                { 172, 1, 18, "Yakkabogʻ tumani" },
                { 173, 1, 19, "Jizzax shahar" },
                { 174, 1, 19, "Baxmal tumani" },
                { 175, 1, 19, "Doʻstlik tumani" },
                { 176, 1, 19, "Gʻallaorol tumani" },
                { 177, 1, 19, "Sh.Rashidov tumani" },
                { 178, 1, 19, "Zarbdor tumani" },
                { 179, 1, 19, "Zafarobod tumani" },
                { 180, 1, 19, "Zomin tumani" },
                { 181, 1, 19, "Paxtakor tumani" },
                { 182, 1, 19, "Mirzachoʻl tumani" },
                { 183, 1, 19, "Forish tumani" },
                { 184, 1, 19, "Yangiobod tumani" },
                { 185, 1, 21, "Namangan shahar" },
                { 186, 1, 21, "Mingbuloq tumani" },
                { 189, 1, 21, "Pop tumani" },
                { 190, 1, 21, "Norin tumani" },
                { 191, 1, 21, "Toʻraqoʻrgʻon tumani" },
                { 192, 1, 21, "Uychi tumani" },
                { 194, 1, 21, "Chortoq tumani" },
                { 195, 1, 21, "Chust tumani" },
                { 196, 1, 21, "Yangiqoʻrgʻon tumani" },
                { 198, 1, 22, "Yunusobod tumani" },
                { 199, 1, 22, "Mirobod tumani" },
                { 200, 1, 22, "Yakkasaroy tumani" },
                { 201, 1, 22, "Olmazor tumani" },
                { 202, 1, 22, "Bektemir tumani - Yangihayot tumani" },
                { 203, 1, 22, "Yashnobod tumani" },
                { 204, 1, 22, "Chilonzor tumani" },
                { 205, 1, 22, "Uchtepa tumani" },
                { 207, 1, 22, "Mirzo Ulugʻbek tumani" },
                { 208, 1, 22, "Sergeli tumani - Yangihayot tumani" },
                { 209, 1, 10, "Ishtixon tumani" },
                { 210, 1, 9, "Kogon shahar" },
                { 211, 1, 19, "Arnasoy tumani" },
                { 212, 1, 22, "Shayxontoxur tumani" },
                { 214, 1, 21, "Namangan tumani" },
                { 215, 1, 21, "Uchqoʻrgʻon tumani" },
                { 216, 1, 21, "Kosonsoy tumani" },
                { 217, 1, 16, "Xiva shahar" },
                { 218, 1, 8, "Taxiatosh" },
                { 219, 1, 18, "Shaxrisabz shahar" },
                { 220, 1, 17, "Toshkent tumani" },
                { 221, 1, 17, "Yangiyoʻl shahar" },
                { 222, 1, 17, "Ohangaron shahar" },
                { 223, 1, 17, "Nurafshon shahar" }
            });

        migrationBuilder.InsertData(
            table: "employments_translations_20ts24tu",
            columns: new[] { "id", "employment_id", "language_id", "status_translation_id", "title" },
            values: new object[,]
            {
                { 1, 1, 1, 1, "Busy" },
                { 2, 2, 1, 1, "Unemployed" },
                { 3, 3, 1, 1, "Retired" },
                { 4, 4, 1, 1, "Student" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_appeal_to_employee_20ts24tu_status_id",
            table: "appeal_to_employee_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeal_to_employee_20ts24tu_user_id",
            table: "appeal_to_employee_20ts24tu",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeal_to_employee_translation_20ts24tu_language_id",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeal_to_employee_translation_20ts24tu_status_id",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeal_to_employee_translation_20ts24tu_user_id",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "user_id");

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
            name: "IX_appeals_to_rectors_translations_20ts24tu_country_translatio~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "country_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_district_translati~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "district_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_employe_translatio~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "employe_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_file_translation_id",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "file_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_gender_translation~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "gender_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_language_id",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_neighborhood_trans~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "neighborhood_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_appeals_to_rectors_translations_20ts24tu_territorie_transla~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "territorie_translation_id");

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
            name: "IX_countries_20ts24tu_status_id",
            table: "countries_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_countries_translations_20ts24tu_country_id",
            table: "countries_translations_20ts24tu",
            column: "country_id");

        migrationBuilder.CreateIndex(
            name: "IX_countries_translations_20ts24tu_language_id",
            table: "countries_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_countries_translations_20ts24tu_status_translation_id",
            table: "countries_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_departament_20ts24tu_departament_type_id",
            table: "departament_20ts24tu",
            column: "departament_type_id");

        migrationBuilder.CreateIndex(
            name: "IX_departament_20ts24tu_img_icon_id",
            table: "departament_20ts24tu",
            column: "img_icon_id");

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
            name: "IX_departament_translations_20ts24tu_departament_id",
            table: "departament_translations_20ts24tu",
            column: "departament_id");

        migrationBuilder.CreateIndex(
            name: "IX_departament_translations_20ts24tu_departament_type_translat~",
            table: "departament_translations_20ts24tu",
            column: "departament_type_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_departament_translations_20ts24tu_img_icon_id",
            table: "departament_translations_20ts24tu",
            column: "img_icon_id");

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
            name: "IX_districts_20ts24tu_status_id",
            table: "districts_20ts24tu",
            column: "status_id");

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
            name: "IX_districts_translations_20ts24tu_status_translation_id",
            table: "districts_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_districts_translations_20ts24tu_territorie_translation_id",
            table: "districts_translations_20ts24tu",
            column: "territorie_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_document_teacher_110_20ts24tu_status_id",
            table: "document_teacher_110_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_document_teacher_110_set_20ts24tu_document_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "document_id");

        migrationBuilder.CreateIndex(
            name: "IX_document_teacher_110_set_20ts24tu_file_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "file_id");

        migrationBuilder.CreateIndex(
            name: "IX_document_teacher_110_set_20ts24tu_person_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "person_id");

        migrationBuilder.CreateIndex(
            name: "IX_document_teacher_110_set_20ts24tu_status_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_employee_types_20ts24tu_status_id",
            table: "employee_types_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_employee_types_translations_20ts24tu_employee_id",
            table: "employee_types_translations_20ts24tu",
            column: "employee_id");

        migrationBuilder.CreateIndex(
            name: "IX_employee_types_translations_20ts24tu_language_id",
            table: "employee_types_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_employee_types_translations_20ts24tu_status_translation_id",
            table: "employee_types_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_employments_20ts24tu_status_id",
            table: "employments_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_employments_translations_20ts24tu_employment_id",
            table: "employments_translations_20ts24tu",
            column: "employment_id");

        migrationBuilder.CreateIndex(
            name: "IX_employments_translations_20ts24tu_language_id",
            table: "employments_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_employments_translations_20ts24tu_status_translation_id",
            table: "employments_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_files_20ts24tu_status_id",
            table: "files_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_files_20ts24tu_title",
            table: "files_20ts24tu",
            column: "title",
            unique: true);

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
            name: "IX_files_translations_20ts24tu_title",
            table: "files_translations_20ts24tu",
            column: "title",
            unique: true);

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
            name: "IX_interactive_services_20ts24tu_icon_id",
            table: "interactive_services_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_20ts24tu_img_id",
            table: "interactive_services_20ts24tu",
            column: "img_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_20ts24tu_status_id",
            table: "interactive_services_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_translations_20ts24tu_icon_id",
            table: "interactive_services_translations_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_translations_20ts24tu_img_id",
            table: "interactive_services_translations_20ts24tu",
            column: "img_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_translations_20ts24tu_interactive_serv~",
            table: "interactive_services_translations_20ts24tu",
            column: "interactive_services_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_translations_20ts24tu_language_id",
            table: "interactive_services_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_interactive_services_translations_20ts24tu_status_translati~",
            table: "interactive_services_translations_20ts24tu",
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
            name: "IX_menu_20ts24tu_blog_id",
            table: "menu_20ts24tu",
            column: "blog_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_departament_id",
            table: "menu_20ts24tu",
            column: "departament_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_icon_id",
            table: "menu_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_menu_type_id",
            table: "menu_20ts24tu",
            column: "menu_type_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_page_id",
            table: "menu_20ts24tu",
            column: "page_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_status_id",
            table: "menu_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_20ts24tu_user_id",
            table: "menu_20ts24tu",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_blog_translation_id",
            table: "menu_translations_20ts24tu",
            column: "blog_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_departament_translation_id",
            table: "menu_translations_20ts24tu",
            column: "departament_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_icon_id",
            table: "menu_translations_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_language_id",
            table: "menu_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_menu_id",
            table: "menu_translations_20ts24tu",
            column: "menu_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_menu_type_translation_id",
            table: "menu_translations_20ts24tu",
            column: "menu_type_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_page_translation_id",
            table: "menu_translations_20ts24tu",
            column: "page_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_status_id",
            table: "menu_translations_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_translations_20ts24tu_user_id",
            table: "menu_translations_20ts24tu",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_types_20ts24tu_status_id",
            table: "menu_types_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_types_translations_20ts24tu_language_id",
            table: "menu_types_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_types_translations_20ts24tu_menu_type_id",
            table: "menu_types_translations_20ts24tu",
            column: "menu_type_id");

        migrationBuilder.CreateIndex(
            name: "IX_menu_types_translations_20ts24tu_status_translation_id",
            table: "menu_types_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_neighborhoods_20ts24tu_district_id",
            table: "neighborhoods_20ts24tu",
            column: "district_id");

        migrationBuilder.CreateIndex(
            name: "IX_neighborhoods_20ts24tu_status_id",
            table: "neighborhoods_20ts24tu",
            column: "status_id");

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
            name: "IX_neighborhoods_translations_20ts24tu_status_translation_id",
            table: "neighborhoods_translations_20ts24tu",
            column: "status_translation_id");

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
            name: "IX_persons_20ts24tu_departament_id",
            table: "persons_20ts24tu",
            column: "departament_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_20ts24tu_employee_type_id",
            table: "persons_20ts24tu",
            column: "employee_type_id");

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
            name: "IX_persons_data_20ts24tu_persons_id",
            table: "persons_data_20ts24tu",
            column: "persons_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_data_20ts24tu_status_id",
            table: "persons_data_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_data_translations_20ts24tu_language_id",
            table: "persons_data_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_data_translations_20ts24tu_persons_data_id",
            table: "persons_data_translations_20ts24tu",
            column: "persons_data_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_data_translations_20ts24tu_persons_translation_id",
            table: "persons_data_translations_20ts24tu",
            column: "persons_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_data_translations_20ts24tu_status_translation_id",
            table: "persons_data_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_translations_20ts24tu_departament_translation_id",
            table: "persons_translations_20ts24tu",
            column: "departament_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_translations_20ts24tu_employee_type_translation_id",
            table: "persons_translations_20ts24tu",
            column: "employee_type_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_persons_translations_20ts24tu_gender_id",
            table: "persons_translations_20ts24tu",
            column: "gender_id");

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
            name: "IX_statistical_numbers_20ts24tu_icon_id",
            table: "statistical_numbers_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_statistical_numbers_20ts24tu_status_id",
            table: "statistical_numbers_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_statistical_numbers_translations_20ts24tu_icon_id",
            table: "statistical_numbers_translations_20ts24tu",
            column: "icon_id");

        migrationBuilder.CreateIndex(
            name: "IX_statistical_numbers_translations_20ts24tu_language_id",
            table: "statistical_numbers_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_statistical_numbers_translations_20ts24tu_statistical_numbe~",
            table: "statistical_numbers_translations_20ts24tu",
            column: "statistical_numbers_id");

        migrationBuilder.CreateIndex(
            name: "IX_statistical_numbers_translations_20ts24tu_status_translatio~",
            table: "statistical_numbers_translations_20ts24tu",
            column: "status_translation_id");

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
            name: "IX_territories_20ts24tu_status_id",
            table: "territories_20ts24tu",
            column: "status_id");

        migrationBuilder.CreateIndex(
            name: "IX_territories_translations_20ts24tu_country_translation_id",
            table: "territories_translations_20ts24tu",
            column: "country_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_territories_translations_20ts24tu_language_id",
            table: "territories_translations_20ts24tu",
            column: "language_id");

        migrationBuilder.CreateIndex(
            name: "IX_territories_translations_20ts24tu_status_translation_id",
            table: "territories_translations_20ts24tu",
            column: "status_translation_id");

        migrationBuilder.CreateIndex(
            name: "IX_territories_translations_20ts24tu_territorie_id",
            table: "territories_translations_20ts24tu",
            column: "territorie_id");

        migrationBuilder.CreateIndex(
            name: "IX_tokens_20ts24tu_status_id",
            table: "tokens_20ts24tu",
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
            name: "FK_appeal_to_employee_20ts24tu_users_20ts24tu_user_id",
            table: "appeal_to_employee_20ts24tu",
            column: "user_id",
            principalTable: "users_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeal_to_employee_translation_20ts24tu_languages_20ts24tu_~",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "language_id",
            principalTable: "languages_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeal_to_employee_translation_20ts24tu_statuses_translatio~",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "status_id",
            principalTable: "statuses_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeal_to_employee_translation_20ts24tu_users_20ts24tu_user~",
            table: "appeal_to_employee_translation_20ts24tu",
            column: "user_id",
            principalTable: "users_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_20ts24tu_files_20ts24tu_file_id",
            table: "appeals_to_rectors_20ts24tu",
            column: "file_id",
            principalTable: "files_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_countries_translat~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "country_translation_id",
            principalTable: "countries_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_districts_translat~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "district_translation_id",
            principalTable: "districts_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_employments_transl~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "employe_translation_id",
            principalTable: "employments_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_files_translations~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "file_translation_id",
            principalTable: "files_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_genders_translatio~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "gender_translation_id",
            principalTable: "genders_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_languages_20ts24tu~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "language_id",
            principalTable: "languages_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_neighborhoods_tran~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "neighborhood_translation_id",
            principalTable: "neighborhoods_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_appeals_to_rectors_translations_20ts24tu_territories_transl~",
            table: "appeals_to_rectors_translations_20ts24tu",
            column: "territorie_translation_id",
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
            name: "FK_countries_translations_20ts24tu_statuses_translations_20ts2~",
            table: "countries_translations_20ts24tu",
            column: "status_translation_id",
            principalTable: "statuses_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_departament_20ts24tu_files_20ts24tu_img_icon_id",
            table: "departament_20ts24tu",
            column: "img_icon_id",
            principalTable: "files_20ts24tu",
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
            column: "departament_type_translation_id",
            principalTable: "departament_types_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
            table: "departament_translations_20ts24tu",
            column: "img_icon_id",
            principalTable: "files_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_departament_translations_20ts24tu_files_translations_20ts2~1",
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
            name: "FK_districts_translations_20ts24tu_statuses_translations_20ts2~",
            table: "districts_translations_20ts24tu",
            column: "status_translation_id",
            principalTable: "statuses_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_districts_translations_20ts24tu_territories_translations_20~",
            table: "districts_translations_20ts24tu",
            column: "territorie_translation_id",
            principalTable: "territories_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_document_teacher_110_set_20ts24tu_files_20ts24tu_file_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "file_id",
            principalTable: "files_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_document_teacher_110_set_20ts24tu_persons_20ts24tu_person_id",
            table: "document_teacher_110_set_20ts24tu",
            column: "person_id",
            principalTable: "persons_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_employee_types_translations_20ts24tu_languages_20ts24tu_lan~",
            table: "employee_types_translations_20ts24tu",
            column: "language_id",
            principalTable: "languages_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_employee_types_translations_20ts24tu_statuses_translations_~",
            table: "employee_types_translations_20ts24tu",
            column: "status_translation_id",
            principalTable: "statuses_translations_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_employments_translations_20ts24tu_languages_20ts24tu_langua~",
            table: "employments_translations_20ts24tu",
            column: "language_id",
            principalTable: "languages_20ts24tu",
            principalColumn: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_employments_translations_20ts24tu_statuses_translations_20t~",
            table: "employments_translations_20ts24tu",
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
            name: "FK_departament_20ts24tu_statuses_20ts24tu_status_id",
            table: "departament_20ts24tu");

        migrationBuilder.DropForeignKey(
            name: "FK_departament_types_20ts24tu_statuses_20ts24tu_status_id",
            table: "departament_types_20ts24tu");

        migrationBuilder.DropForeignKey(
            name: "FK_employee_types_20ts24tu_statuses_20ts24tu_status_id",
            table: "employee_types_20ts24tu");

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
            name: "appeal_to_employee_20ts24tu");

        migrationBuilder.DropTable(
            name: "appeal_to_employee_translation_20ts24tu");

        migrationBuilder.DropTable(
            name: "appeals_to_rectors_20ts24tu");

        migrationBuilder.DropTable(
            name: "appeals_to_rectors_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "departament_details_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "document_teacher_110_set_20ts24tu");

        migrationBuilder.DropTable(
            name: "interactive_services_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "menu_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "persons_data_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "site_details_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "statistical_numbers_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "tokens_20ts24tu");

        migrationBuilder.DropTable(
            name: "user_types_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "employments_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "neighborhoods_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "departament_details_20ts24tu");

        migrationBuilder.DropTable(
            name: "document_teacher_110_20ts24tu");

        migrationBuilder.DropTable(
            name: "interactive_services_20ts24tu");

        migrationBuilder.DropTable(
            name: "blogs_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "menu_20ts24tu");

        migrationBuilder.DropTable(
            name: "menu_types_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "pages_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "persons_data_20ts24tu");

        migrationBuilder.DropTable(
            name: "persons_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "site_details_20ts24tu");

        migrationBuilder.DropTable(
            name: "sites_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "statistical_numbers_20ts24tu");

        migrationBuilder.DropTable(
            name: "employments_20ts24tu");

        migrationBuilder.DropTable(
            name: "districts_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "neighborhoods_20ts24tu");

        migrationBuilder.DropTable(
            name: "blogs_category_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "blogs_20ts24tu");

        migrationBuilder.DropTable(
            name: "menu_types_20ts24tu");

        migrationBuilder.DropTable(
            name: "pages_20ts24tu");

        migrationBuilder.DropTable(
            name: "departament_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "employee_types_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "genders_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "site_types_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "sites_20ts24tu");

        migrationBuilder.DropTable(
            name: "territories_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "districts_20ts24tu");

        migrationBuilder.DropTable(
            name: "blogs_category_20ts24tu");

        migrationBuilder.DropTable(
            name: "departament_types_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "files_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "site_types_20ts24tu");

        migrationBuilder.DropTable(
            name: "countries_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "territories_20ts24tu");

        migrationBuilder.DropTable(
            name: "statuses_translations_20ts24tu");

        migrationBuilder.DropTable(
            name: "countries_20ts24tu");

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
            name: "departament_20ts24tu");

        migrationBuilder.DropTable(
            name: "employee_types_20ts24tu");

        migrationBuilder.DropTable(
            name: "genders_20ts24tu");

        migrationBuilder.DropTable(
            name: "departament_types_20ts24tu");

        migrationBuilder.DropTable(
            name: "files_20ts24tu");
    }
}
