using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vurilo.Migrations
{
    /// <inheritdoc />
    public partial class Search : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Browse",
                columns: table => new
                {
                    VideoLength = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browse", x => x.VideoLength);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Browse");
        }
    }
}
