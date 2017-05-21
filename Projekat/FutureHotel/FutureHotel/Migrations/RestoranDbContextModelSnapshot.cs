using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using FutureHotel.Model;

namespace OoadProjekatBazaMigrations
{
    [ContextType(typeof(RestoranBaza))]
    partial class RestoranDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("UkupnaCijena");

                    //b.Property<float>("GeoSirina");

                    b.Property<string>("predjelo_");

                    b.Property<string>("glavno_");

                   // b.Property<float>("Rating");

                   // b.Property<byte[]>("Slika")
                    //    .Annotation("Relational:ColumnType", "image");

                    b.Property<string>("desert_");

                    //b.Property<string>("fourSqaureId");

                    b.Key("id");
                });
        }
    }
}
