using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using FutureHotel.Model;

namespace OoadProjekatBazaMigrations
{
    [ContextType(typeof(RestoranBaza))]
    partial class Migracija
    {
        public override string Id
        {
            get { return "20160417074328_Migracija"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("OoadProjekatBaza.RestoranBaza.Models.Restoran", b =>
                {
                    b.Property<int>("RestoranId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("GeoDuzina");

                    b.Property<float>("GeoSirina");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<float>("Rating");

                    b.Property<byte[]>("Slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<string>("Telefon");

                    b.Property<string>("fourSqaureId");

                    b.Key("RestoranId");
                });
        }
    }
}
