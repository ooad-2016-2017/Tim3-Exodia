using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace FutureHotel.ViewModel
{
    public class VMPretragaZaposleni
    {
        public Hotel hotel {get;set;}
        public List<Zaposlenik> zap { get; set; }
        public List<Soba> s { get; set; }
        public ObservableCollection<Zaposlenik> zaposleni { get; set; }
        public String rijec { get; set; }
        public ICommand komanda { get; set; }


        public VMPretragaZaposleni()
        {
            zaposleni = new ObservableCollection<Zaposlenik>();
            rijec = "";
            ucitaj();
            komanda = new RelayCommand<object>(pretraga, moze);
            hotel = new Hotel(zap, s, null);
        }

        public void ucitaj()
        {
            zap = new List<Zaposlenik>();
            zap.Add(new Zaposlenik("Meho", "Aljo", new DateTime(1, 1, 1), 1, 120));
        }

        public bool moze(object param)
        {
            return true;
        }
        
        public void pretraga(object param)
        {
            zaposleni.Clear();
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
