using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Jelo
    {
        private string naziv;
        private Dictionary<string, int> sastojci;

        public Jelo(string naziv, Dictionary<string, int> sastojci)
        {
            this.Naziv = naziv;
            this.Sastojci = sastojci;
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

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
    }
}
