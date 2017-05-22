using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Jelo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int jeloId { get; set; }
        public string naziv { get; set; }
        private Dictionary<string, int> sastojci;
        public string tip { get; set; }
        public double cijelna { get; set; }

        public Jelo(Jelo k)
        {
            this.naziv = k.naziv;
            this.sastojci = k.sastojci;
            this.tip = k.tip;
            this.cijelna = k.cijelna;
        }
        public Jelo(string naziv, Dictionary<string, int> sastojcim, String tip_,double cijena)
        {
            this.naziv = naziv;
            this.Sastojci = sastojci;
            this.tip = tip_;
            this.cijelna = cijena;
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
