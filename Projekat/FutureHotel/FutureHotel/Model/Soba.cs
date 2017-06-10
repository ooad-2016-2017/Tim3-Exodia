using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Soba
    {
        public string id { get; set; }
        public int redni_br { get; set; }
        public string tip { get; set; }
        public DateTime zauzetaDo { get; set; }
        public string gost_guid { get; set; }

        public Soba(string id, int red_br, string brojKreveta, DateTime zauzetaDo, string gost)
        {
            redni_br = redni_br;
            this.id = id;
            this.tip = brojKreveta;
            this.zauzetaDo = zauzetaDo;
            this.gost_guid = gost;
        }

        public Soba(string id, string brojKreveta)
        {
            this.id = id;
            this.tip = brojKreveta;
            
        }

        public Soba() { }
    }
}
