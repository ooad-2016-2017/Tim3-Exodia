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
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("UkupnaCijena");

                    b.Property<string>("predjelo_");

                    b.Property<string>("glavno_");

                    b.Property<string>("desert_");
                    

                    b.Key("id");
                });
        }
    }
}
