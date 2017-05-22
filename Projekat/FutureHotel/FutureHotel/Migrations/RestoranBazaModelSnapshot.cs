using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using FutureHotel.Model;

namespace FutureHotelMigrations
{
    [ContextType(typeof(RestoranBaza))]
    partial class RestoranBazaModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("FutureHotel.Model.Jelo", b =>
                {
                    b.Property<int>("jeloId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<double>("cijelna");

                    b.Property<string>("naziv");

                    b.Property<string>("tip");

                    b.Key("jeloId");
                });

            builder.Entity("FutureHotel.Model.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UkupnaCijena");

                    b.Property<int?>("desert_jeloId");

                    b.Property<int?>("glavno_jeloId");

                    b.Property<int>("idStola");

                    b.Property<int?>("predjelo_jeloId");

                    b.Key("NarudzbaId");
                });

            builder.Entity("FutureHotel.Model.Narudzba", b =>
                {
                    b.Reference("FutureHotel.Model.Jelo")
                        .InverseCollection()
                        .ForeignKey("desert_jeloId");

                    b.Reference("FutureHotel.Model.Jelo")
                        .InverseCollection()
                        .ForeignKey("glavno_jeloId");

                    b.Reference("FutureHotel.Model.Jelo")
                        .InverseCollection()
                        .ForeignKey("predjelo_jeloId");
                });
        }
    }
}
