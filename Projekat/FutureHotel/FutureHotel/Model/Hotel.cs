using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Hotel
    {
        //public RestoranModel restoran { get; set; }
        public List<Zaposlenik> zaposleni { get; set; }
        public List<Soba> sobe { get; set; }
        public List<Gost> gosti { get; set; }
        

        public Hotel( List<Zaposlenik> _zaposleni, List<Soba> _sobe, List<Gost> _gosti)
        {
            this.zaposleni = _zaposleni;
            this.sobe = _sobe;
            this.gosti = _gosti;
        }

        public Hotel()
        {

        }
    }
}
