using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Data.Migrations
{
    public partial class SeedFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Good')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Better')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Best')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
