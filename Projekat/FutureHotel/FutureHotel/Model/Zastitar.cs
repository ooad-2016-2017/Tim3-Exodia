using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.Model
{
    class Zastitar: Zaposlenik
    {

        Stream glas;
        public Zastitar(String ime_, String prezime_, DateTime dat, string id_, String slika_, double plata_, Stream tip) : base(ime_, prezime_, dat, id_, slika_, plata_)
        {
            glas = tip;
        }

    }
}
