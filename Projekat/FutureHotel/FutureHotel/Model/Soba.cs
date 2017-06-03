using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Soba
    {
        public int id { get; set; }
        public int brojKreveta { get; set; }
        public DateTime zauzetaDo { get; set; }
        public int gost { get; set; }

        public Soba(int id, int brojKreveta, DateTime zauzetaDo, int gost)
        {
            this.id = id;
            this.brojKreveta = brojKreveta;
            this.zauzetaDo = zauzetaDo;
            this.gost = gost;
        }

        public Soba(int id, int brojKreveta)
        {
            this.id = id;
            this.brojKreveta = brojKreveta;
            
        }
    }
}
