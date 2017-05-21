using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.Model
{
    public class Zaposlenik
    {
        public String ime;
        public String prezime;
        public DateTime dat_rodjenja;
        public int id;
        public Image slika;
        public double plata;

        public Zaposlenik(String ime_, String prezime_, DateTime dat, int id_, Image slika_, double plata_) {
            ime = ime_;
            prezime = prezime_;
            dat_rodjenja = dat; 
            id = id_;
            slika = slika_;
            plata = plata_;

        }

        public Zaposlenik(String ime_, String prezime_, DateTime dat, int id_, double plata_)
        {
            ime = ime_;
            prezime = prezime_;
            dat_rodjenja = dat;
            id = id_;
            plata = plata_;

        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }

    }
}
