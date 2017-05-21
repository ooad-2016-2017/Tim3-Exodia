using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace FutureHotel.ViewModel
{
    class VMZaposleni
    {
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTime datum { get; set; }
        public String plata { get;set; }
        public ICommand komanda { get; set; }
        public bool validirano { get; set; }

        public VMZaposleni()
        {
            komanda = new RelayCommand<object>(dodajZaposlenog, moze);
        }

        public async void validiraj()
        {
            Regex r = new Regex("^[a-z A-Z]+$");
            if (string.IsNullOrEmpty(ime) || !r.IsMatch(ime))
            {
                var dialog = new MessageDialog("Neispravno ime");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            if (string.IsNullOrEmpty(prezime) || !r.IsMatch(prezime))
            {
                var dialog = new MessageDialog("Neispravno prezime");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            r = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(plata) || !r.IsMatch(plata))
            {
                var dialog = new MessageDialog("Neispravna plata");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            validirano = true;
        }

        public bool moze(object param)
        {
            return true;
        }

        public async void dodajZaposlenog(object param)
        {
            validiraj();
            if (validirano)
            {
                //rad sa bazom
                var dialog = new MessageDialog("Zaposleni uspjesno dodan!");
                await dialog.ShowAsync();
            }
        }
    }
}
