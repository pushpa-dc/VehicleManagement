﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make3')");

            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make1-ModelA',(SELECT Id FROM Makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make1-ModelB',(SELECT Id FROM Makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make1-ModelC',(SELECT Id FROM Makes WHERE Name='Make1'))");


            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make2-ModelA',(SELECT Id FROM Makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make2-ModelB',(SELECT Id FROM Makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make2-ModelC',(SELECT Id FROM Makes WHERE Name='Make2'))");

            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make3-ModelA',(SELECT Id FROM Makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make3-ModelB',(SELECT Id FROM Makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name,MakeId) Values('Make3-ModelC',(SELECT Id FROM Makes WHERE Name='Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
