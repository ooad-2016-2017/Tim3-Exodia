using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Narudzba
    {
        private int idStola;
        private List<Jelo> jela;
        private int id;

        public int IdStola
        {
            get
            {
                return idStola;
            }

            set
            {
                idStola = value;
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

        public Narudzba(int idStola, List<Jelo> jela, int id)
        {
            this.IdStola = idStola;
            this.Jela = jela;
            this.Id = id;
        }
    }
}
