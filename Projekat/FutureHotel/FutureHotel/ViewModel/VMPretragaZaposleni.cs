using FutureHotel.Ljudski_resursi;
using FutureHotel.Model;
using Microsoft.WindowsAzure.MobileServices;
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
using Windows.UI.Xaml.Controls;

namespace FutureHotel.ViewModel
{
    public class VMPretragaZaposleni
    {
        public Hotel hotel {get;set;}
        public List<Zaposlenik> zap { get; set; }
        public List<Soba> s { get; set; }
        public ObservableCollection<Zaposlenik> zaposleni { get; set; }
        //IEnumerable<Zaposlenik> zaposleni { get; set; }
    public String rijec { get; set; }
        public object selektovani { get; set; }
        public ICommand komanda { get; set; }
        public ICommand komandaPregled { get; set; }

        IMobileServiceTable<Zaposlenik> userTableObj = App.MobileService.GetTable<Zaposlenik>();


        public VMPretragaZaposleni()
        {
            rijec = "";
            //ucitaj_();
            zaposleni = new ObservableCollection<Zaposlenik>();
            //zaposleni.Add(new Zaposlenik("mujo", "hah", new DateTime(1, 1, 1), "id def", 100));
            komanda = new RelayCommand<object>(pretraga, moze);
            komandaPregled = new RelayCommand<object>(pregled, moze);
            hotel = new Hotel(zap, s, null);
        }

        /*public async void ucitaj_()
        {
            IEnumerable<Zaposlenik> zaposleni_ = await userTableObj.ReadAsync();
            zap = new List<Zaposlenik>(zaposleni_);
            hotel.zaposleni = new List<Zaposlenik>(zaposleni);
        }*/

        

        public bool moze(object param)
        {
            return true;
        }
        
        public async void pretraga(object param)
        {
            IEnumerable<Zaposlenik> zaposleni_ = await userTableObj.ReadAsync();
            zap = new List<Zaposlenik>(zaposleni_);
            hotel.zaposleni = new List<Zaposlenik>(zaposleni);
            hotel = new Hotel(zap, s, null);

            zaposleni.Clear();
            if(hotel.zaposleni!=null)
            for (int i=0; i<hotel.zaposleni.Count; i++)
            {
                if(hotel.zaposleni[i].ToString().Contains(rijec))
                {
                    zaposleni.Add(hotel.zaposleni[i]);
                }
            }
        }

        public async void pregled(object param)
        {
            var frame = (Frame)Window.Current.Content;
            if (selektovani == null)
            {
                var dialog = new MessageDialog("Niko nije selektovan");
                await dialog.ShowAsync();
                //return;
            }
            else
            {
                VMLjudskiResursiProfil vmr = new VMLjudskiResursiProfil((Zaposlenik)selektovani);
                frame.Navigate(typeof(LjudskiResursiProfil), vmr);
            }
        }
    }
}
