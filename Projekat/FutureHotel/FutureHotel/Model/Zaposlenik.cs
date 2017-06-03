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
        public string id { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public string dat_rodjenja { get; set; }
        public String slika { get; set; }
        public double plata { get; set; }

        public Zaposlenik(String ime_, String prezime_, string dat, string id_, String slika_, double plata_) {
            ime = ime_;
            prezime = prezime_;
            dat_rodjenja = dat; 
            id = id_;
            slika = slika_;
            plata = plata_;

        }

        public Zaposlenik(String ime_, String prezime_, string dat, string id_, double plata_)
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
