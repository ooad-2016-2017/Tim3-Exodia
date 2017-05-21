using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class RestoranModel
    {
        private Dictionary<string, int> sastojci;
        public ObservableCollection<Jelo> predjela { get; set; }
        public ObservableCollection<Jelo> glavna_jela { get; set; }
        public ObservableCollection<Jelo> deserti { get; set; }

        public Dictionary<string, int> Sastojci
        {
            get
            {
                return sastojci;
            }

            set
            {
                sastojci = value;
            }
        }

        

        public RestoranModel(Dictionary<string, int> sastojci, ObservableCollection<Jelo> jela)
        {
            predjela = new ObservableCollection<Jelo>();
            glavna_jela = new ObservableCollection<Jelo>();
            deserti = new ObservableCollection<Jelo>();
            this.Sastojci = sastojci;
            for (int i = 0; i < jela.Count; i++)
            {
                if (jela[i].tip == "Glavno") glavna_jela.Add(jela[i]);
                else if (jela[i].tip == "Predjelo") predjela.Add(jela[i]);
                else deserti.Add(jela[i]);
            }
        }


    }
}
