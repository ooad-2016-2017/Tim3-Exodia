using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace FutureHotelMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    jeloId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    //Naziv = table.Column(type: "TEXT", nullable: true),
                    cijelna = table.Column(type: "REAL", nullable: false),
                    naziv = table.Column(type: "TEXT", nullable: true),
                    tip = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelo", x => x.jeloId);
                });
            migration.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    UkupnaCijena = table.Column(type: "INTEGER", nullable: false),
                    desert_jeloId = table.Column(type: "INTEGER", nullable: true),
                    glavno_jeloId = table.Column(type: "INTEGER", nullable: true),
                    idStola = table.Column(type: "INTEGER", nullable: false),
                    predjelo_jeloId = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Jelo_desert_jeloId",
                        columns: x => x.desert_jeloId,
                        referencedTable: "Jelo",
                        referencedColumn: "jeloId");
                    table.ForeignKey(
                        name: "FK_Narudzba_Jelo_glavno_jeloId",
                        columns: x => x.glavno_jeloId,
                        referencedTable: "Jelo",
                        referencedColumn: "jeloId");
                    table.ForeignKey(
                        name: "FK_Narudzba_Jelo_predjelo_jeloId",
                        columns: x => x.predjelo_jeloId,
                        referencedTable: "Jelo",
                        referencedColumn: "jeloId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Narudzba");
            migration.DropTable("Jelo");
        }
    }
}
