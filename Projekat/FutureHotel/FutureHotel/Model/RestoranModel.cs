using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class RestoranModel
    {
        private Dictionary<string, int> sastojci;
        public List<Jelo> predjela;
        public List<Jelo> glavna_jela;
        public List<Jelo> deserti;

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

        

        public RestoranModel(Dictionary<string, int> sastojci, List<Jelo> jela)
        {
            predjela = new List<Jelo>();
            glavna_jela = new List<Jelo>();
            deserti = new List<Jelo>();
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
