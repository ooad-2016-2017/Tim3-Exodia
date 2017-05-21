using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureHotel.Model
{
    class Gost
    {
        public int id { get; set; }
        public List<Stream> glasovi { get; set; }
        public int soba { get; set; }
        public Gost(int _id, List<Stream> _glasovi, int _soba)
        {
            id = _id;
            glasovi = _glasovi;
            soba = _soba;
        }
    }
}
