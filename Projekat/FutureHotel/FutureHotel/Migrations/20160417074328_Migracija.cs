using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace OoadProjekatBazaMigrations
{
    public partial class Migracija : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    UkupnaCIjena = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                   // GeoDuzina = table.Column(type: "REAL", nullable: false),
                   // GeoSirina = table.Column(type: "REAL", nullable: false),
                    Predjelo1 = table.Column(type: "TEXT", nullable: true),
                    GlavnoJelo1 = table.Column(type: "TEXT", nullable: true),
                  //  Rating = table.Column(type: "REAL", nullable: false),
                    //Slika = table.Column(type: "image", nullable: true),
                    Desert1 = table.Column(type: "TEXT", nullable: true),
                   // fourSqaureId = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.id);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Restoran");
        }
    }
}
