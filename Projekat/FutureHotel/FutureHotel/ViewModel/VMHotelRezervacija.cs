using FutureHotel.View.Recepcija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.ViewModel
{
    public class VMHotelRezervacija
    {
        public String tipSobe { get; set; }
        public String brojNocenja { get; set; }
        public List<String> TipoviSobe { get; set; }

        public ICommand proslijedi { get; set; }

        public void bNastaviClick(object param)
        {
            var frame = (Frame)Window.Current.Content;
            List <String> s = new List<String>();
            s.Add(tipSobe);
            s.Add(brojNocenja);
            VMRezervacija rez = new VMRezervacija(s);
            frame.Navigate(typeof(RecepcijaUzimanjeGlasa), rez);
        }

        public VMHotelRezervacija()
        {
            TipoviSobe = new List<String>();
            TipoviSobe.Add("Jednokrevetna");
            TipoviSobe.Add("Dvokrevetna");
            TipoviSobe.Add("Bracnokrevetna");
            proslijedi = new RelayCommand<object>(bNastaviClick, moze);
        }

        public bool moze (object param) { return true; }
    }
}
