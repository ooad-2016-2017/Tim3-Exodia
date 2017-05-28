using FutureHotel.View.Recepcija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.ViewModel
{
    public class VMHotelRezervacija
    {
        public String tipSobe { get; set; }
        public String brojNocenja { get; set; }
        public List<String> TipoviSobe { get; set; }
        bool validirano { get; set; }
        public String tjednaNoc = "Jedna noc:\t0$";
        public String tbrojNocenja = "Broj nocenja:\t0";
        public String tukupno = "Ukupno:\t0$";

        public ICommand proslijedi { get; set; }

        public async void validiraj()
        {
            Regex r = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(brojNocenja) || !r.IsMatch(brojNocenja))
            {
                var dialog = new MessageDialog("Broj nocenja nije validan");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            if(tipSobe == null)
            {
                var dialog = new MessageDialog("Tip sobe nije izabran!");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            validirano = true;
        }

        public async void bNastaviClick(object param)
        {
            validiraj();
            if (validirano)
            {
                int cijena;
                String text = "Jedna noc:\t";
                if(tipSobe == "Jednokrevetna")
                {
                    cijena = 15;
                    text += "15$";
                }
                else if(tipSobe == "Dvokrevetna")
                {
                    cijena = 25;
                    text += "25$";
                }
                else
                {
                    cijena = 30;
                    text += "30$";
                }
                text += "\nBroj nocenja:\t" + int.Parse(brojNocenja);
                text += "\nUkupno:\t\t" + int.Parse(brojNocenja) * cijena + "$";
                var dialog = new MessageDialog(text);
                dialog.Title = "Cijena";
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
                var res = await dialog.ShowAsync();
                if ((int)res.Id == 0) {
                    var frame = (Frame)Window.Current.Content;
                    List<String> s = new List<String>();
                    s.Add(tipSobe);
                    s.Add(brojNocenja);
                    VMRezervacija rez = new VMRezervacija(s);
                    frame.Navigate(typeof(RecepcijaUzimanjeGlasa), rez);
                }
            }
        }

        public VMHotelRezervacija()
        {
            validirano = false;
            TipoviSobe = new List<String>();
            TipoviSobe.Add("Jednokrevetna");
            TipoviSobe.Add("Dvokrevetna");
            TipoviSobe.Add("Bracnokrevetna");
            proslijedi = new RelayCommand<object>(bNastaviClick, moze);
        }

        public bool moze (object param) { return true; }
    }
}
