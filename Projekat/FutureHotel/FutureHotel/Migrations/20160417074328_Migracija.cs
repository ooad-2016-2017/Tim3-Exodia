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
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column(type: "INTEGER", nullable: false),
                    idStola = table.Column(type: "INTEGER", nullable: false),
                    UkupnaCijena = table.Column(type: "INTEGER", nullable: false),
                    predjelo_ = table.Column(type: "TEXT", nullable: true),
                    glavno_ = table.Column(type: "TEXT", nullable: true),
                    desert_ = table.Column(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.NarudzbaId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Narudzba");
        }
    }
}
