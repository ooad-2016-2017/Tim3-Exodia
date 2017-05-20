using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Jelo
    {
        public string naziv { get; set; }
        private Dictionary<string, int> sastojci;
        public string tip;
        public double cijelna { get; set; }

        public Jelo(string naziv, Dictionary<string, int> sastojcim, String tip,double cijena)
        {
            this.Naziv = naziv;
            this.Sastojci = sastojci;
            this.tip = tip;
            this.cijelna = cijena;
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

        public override string ToString()
        {
            return naziv;
        }

    }
}
