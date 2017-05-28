using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    public class Gost
    {
        public int id { get; set; }
        public Guid glasovi { get; set; }
        public int soba { get; set; }
        public Gost(int _id, Guid _glasovi, int _soba)
        {
            id = _id;
            glasovi = _glasovi;
            soba = _soba;
        }
    }
}
