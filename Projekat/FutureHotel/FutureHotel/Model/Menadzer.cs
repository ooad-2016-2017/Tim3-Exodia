using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.Model
{
    class Menadzer : Zaposlenik
    {
        String tipMenadzera;


        public Menadzer(String ime_, String prezime_, DateTime dat, int id_, Image slika_, double plata_, String tip) : base(ime_, prezime_, dat,  id_,  slika_,  plata_)
        {
            tipMenadzera = tip;
        }
    }
}
