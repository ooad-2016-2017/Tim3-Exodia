using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Restoran
    {
        private Dictionary<string, int> sastojci;
        private List<Jelo> jela;

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

        public List<Jelo> Jela
        {
            get
            {
                return jela;
            }

            set
            {
                jela = value;
            }
        }

        public Restoran(Dictionary<string, int> sastojci, List<Jelo> jela)
        {
            this.Sastojci = sastojci;
            this.Jela = jela;
        }
    }
}
