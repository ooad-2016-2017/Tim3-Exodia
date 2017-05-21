using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Soba
    {
        private int id;
        private int brojKreveta;
        private DateTime zauzetaDo;
        private int gost;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int BrojKreveta
        {
            get
            {
                return brojKreveta;
            }

            set
            {
                brojKreveta = value;
            }
        }

        public DateTime ZauzetaDo
        {
            get
            {
                return zauzetaDo;
            }

            set
            {
                zauzetaDo = value;
            }
        }

        public int Gost
        {
            get
            {
                return gost;
            }

            set
            {
                gost = value;
            }
        }

        public Soba(int id, int brojKreveta, DateTime zauzetaDo, int gost)
        {
            this.Id = id;
            this.BrojKreveta = brojKreveta;
            this.ZauzetaDo = zauzetaDo;
            this.Gost = gost;
        }

        public Soba(int id, int brojKreveta)
        {
            this.Id = id;
            this.BrojKreveta = brojKreveta;
            
        }
    }
}
