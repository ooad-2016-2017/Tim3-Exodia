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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarudzbaId { get; set; }
        public int idStola { get; set; }
        public Jelo predjelo_ { get; set; }
        public Jelo glavno_ { get; set; }
        public Jelo desert_ { get; set; }
        
        public int UkupnaCijena { get; set; }



       /* public Narudzba(int id,int idStola,Jelo pre,Jelo glv, Jelo des)
        {
            this.id = id;

            this.idStola = idStola;
            predjelo_ = pre;
            glavno_ = glv;
            desert_ = des;
            
        }*/
    }
}
