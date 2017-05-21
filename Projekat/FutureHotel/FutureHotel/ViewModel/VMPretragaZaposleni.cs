using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.ViewModel
{
    class VMPretragaZaposleni
    {
        public Hotel hotel {get;set;}
        List<Zaposlenik> zap { get; set; }
        List<Soba> s { get; set; }
        List<Zaposlenik> zaposleni { get; set; }
        public String rijec { get; set; }


        public VMPretragaZaposleni()
        {
            ucitaj();
            hotel = new Hotel(zap, s, null);
        }

        public void ucitaj()
        {
            zap = new List<Zaposlenik>();
            zap.Add(new Zaposlenik("Meho", "Aljo", new DateTime(1, 1, 1), 1, 120));
        }

        public void pretraga()
        {
            zaposleni = new List<Zaposlenik>();
            for(int i=0; i<hotel.zaposleni.Count; i++)
            {
                if(hotel.zaposleni[i].ToString().Contains(rijec))
                {
                    zaposleni.Add(hotel.zaposleni[i]);
                }
            }
        }
    }
}
