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

            builder.Entity("FutureHotel.Model.Narudzba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();
                    
                    b.Property<float>("UkupnaCIjena");

                    b.Property<string>("Predjelo1");

                    b.Property<string>("GlavnoJelo1");
                    

                    b.Property<string>("Desert1");
                    
                    b.Key("id");
                });
        }
    }
}
