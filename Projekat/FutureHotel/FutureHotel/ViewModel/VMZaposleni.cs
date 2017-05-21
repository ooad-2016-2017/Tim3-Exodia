using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public VMZaposleni()
        {
            komanda = new RelayCommand<object>(dodajZaposlenog, moze);
        }

        public bool moze(object param)
        {
            return true;
        }

        public async void dodajZaposlenog(object param)
        {
            //rad sa bazom
            var dialog = new MessageDialog("Zaposleni uspjesno dodan!");
            await dialog.ShowAsync();
        }
    }
}
