using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureHotel.Model;
using FutureHotel.Restoran;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Microsoft.Data.Entity;

namespace FutureHotel.ViewModel
{
    public class VMRestoran
    {
        public ObservableCollection<Jelo> narucene_stavke  { get; set; }

        public Jelo jelo_odabrano { get; set; }
        public ObservableCollection<Jelo> sva_jela { get; set; }
        public Dictionary<string, int> sastojci = new Dictionary<string, int>();
        public RestoranModel restoran { get; set; }
        public Jelo predjelo;
        public Jelo glavnoJelo;

        public ICommand dodaj_jelo { get; set; }
        public ICommand dodaj_jelo0 { get; set; }
        public ICommand dodaj_jelo1 { get; set; }

        public VMRestoran()
        {
            ucitaj();
        }

        public VMRestoran(Jelo jelo)
        {
            ucitaj();
            narucene_stavke.Add(jelo);
        }

        public VMRestoran(ObservableCollection<Jelo> jela)
        {
            ucitaj();
            narucene_stavke = jela;

        }

        public static void UpisiUBazu(ObservableCollection<Jelo> stavke)
        {
            
            using (var db = new RestoranBaza())
            {
                int l = 0;
                //RestoraniIS.ItemsSource = db.Restorani.OrderBy(c => c.Naziv).ToList();

                var contact = new Narudzba
                {

                    idStola = 20,
                    predjelo_ = stavke[0],
                    glavno_=stavke[1],
                    desert_ = stavke[2],
                    UkupnaCijena = (int)(stavke[0].cijelna + stavke[1].cijelna + stavke[2].cijelna)

                };
                db.Restorani.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije sa bazom
                db.SaveChanges();
                //refresh liste restorana
            }
        }

        public void ucitaj()
        {
            narucene_stavke = new ObservableCollection<Jelo>();
            sastojci.Add("So", 500);
            sastojci.Add("Brasno", 1000);
            Jelo pita = new Jelo("pita", sastojci, "Predjelo", 5.5);
            sva_jela = new ObservableCollection<Jelo>();
            //narucene_stavke.Add(pita);
            sva_jela.Add(pita);
            Jelo kolac = new Jelo("kolač", sastojci, "Desert", 3);
            Jelo corba = new Jelo("corba", sastojci, "Glavno", 8);
            sva_jela.Add(kolac);
            sva_jela.Add(corba);
            restoran = new RestoranModel(sastojci, sva_jela);
            dodaj_jelo = new RelayCommand<Object>(PosaljiNarudzbu, moze);
            dodaj_jelo1 = new RelayCommand<Object>(DodajPredjelo, moze);
            dodaj_jelo0 = new RelayCommand<Object>(DodajJelo, moze);
        }

        async void PosaljiNarudzbu(object param)
        {
            narucene_stavke.Add(jelo_odabrano);
            String novi = "Jela koja ste poručili: \n";
            for(int i=0;i<narucene_stavke.Count;i++)
            {
                novi += narucene_stavke[i] + "\n";
            }
            if(novi == "Jela koja ste poručili: \n\n\n\n")
            {
                var dialogg = new MessageDialog("Niste nista narucili!");
                await dialogg.ShowAsync();
                return;
            }
            var dialog = new MessageDialog(novi);
            await dialog.ShowAsync();

            UpisiUBazu(narucene_stavke);
        }

        public void DodajPredjelo(object param)
        {
            var frame = (Frame)Window.Current.Content;
            narucene_stavke.Add(jelo_odabrano);
            VMRestoran vmr = new VMRestoran(jelo_odabrano);
            frame.Navigate(typeof(Glavno_jelo), vmr);
        }


        public void DodajJelo(object param)
        {
            var frame = (Frame)Window.Current.Content;
            narucene_stavke.Add(jelo_odabrano);
            VMRestoran vmr = new VMRestoran(narucene_stavke);
            frame.Navigate(typeof(Desert), vmr);
        }
        public bool moze(object pram)
        {
            return true;
        }
    }
}
