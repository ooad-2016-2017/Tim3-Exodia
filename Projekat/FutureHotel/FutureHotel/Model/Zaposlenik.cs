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
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTime dat_rodjenja { get; set; }
        public int id { get; set; }
        public Image slika { get; set; }
        public double plata { get; set; }

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

        public Zaposlenik()
        {

        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }

    }
}
