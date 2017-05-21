using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.ViewModel
{
    class VMLjudskiResursiProfil
    {
        public Zaposlenik zaposlenik { get; set; }
        public String datum { get; set; }

        public VMLjudskiResursiProfil(Zaposlenik zap)
        {
            zaposlenik = zap;
        }
    }
}
