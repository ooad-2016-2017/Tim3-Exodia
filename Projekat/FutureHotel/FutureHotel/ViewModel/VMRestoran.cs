using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureHotel.Model;
using FutureHotel.Restoran;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FutureHotel.ViewModel
{
    public class VMRestoran
    {
        public ObservableCollection<Jelo> narucene_stavke  { get; set; }

        public Jelo jelo_odabrano { get; set; }
        public ObservableCollection<Jelo> sva_jela { get; set; }
        //dodavanje jela i sastojaka rucno
        public Dictionary<string, int> sastojci = new Dictionary<string, int>();
        
        public RestoranModel restoran { get; set; }

        public ICommand dodaj_jelo { get; set; }

        public VMRestoran()
        {
            narucene_stavke = new ObservableCollection<Jelo>();
            sastojci.Add("So", 500);
            sastojci.Add("Brasno", 1000);
            Jelo pita = new Jelo("pita", sastojci, "Predjelo",5.5);
            sva_jela = new ObservableCollection<Jelo>();
            //narucene_stavke.Add(pita);
            sva_jela.Add(pita);
            Jelo kolac = new Jelo("kolač", sastojci, "Desert", 3);
            Jelo corba = new Jelo("corba", sastojci, "Glavno",8);
            sva_jela.Add(kolac);
            sva_jela.Add(corba);
            jelo_odabrano = new Jelo(sva_jela[0]);
            restoran = new RestoranModel(sastojci, sva_jela);
            dodaj_jelo = new RelayCommand<Object>(DodajJelo,moze);
        }

        public void DodajJelo(object param)
        {
            narucene_stavke.Add(jelo_odabrano);
        }
        public bool moze(object pram)
        {
            return true;
        }
    }
}
