using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Narudzba
    {
        private static int k = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarudzbaId{ get; set; }
        public int idStola { get; set; }
        public Jelo predjelo_ { get; set; }
        public Jelo glavno_ { get; set; }
        public Jelo desert_ { get; set; }
        
        public int UkupnaCijena { get; set; }



      /*  public Narudzba(Jelo pre,Jelo glv, Jelo des,int cijena)
        {
            NarudzbaId = k;
            k++;
            //idStola = idStola_;
            predjelo_ = pre;
            glavno_ = glv;
            desert_ = des;
            UkupnaCijena = cijena;
        }*/
    }
}
