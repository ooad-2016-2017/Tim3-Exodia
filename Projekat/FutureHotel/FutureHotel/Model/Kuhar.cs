﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.Model
{
    class Kuhar : Zaposlenik
    {
        String tipKuhara;
        private Stream audioStream; //??
        public Kuhar(String ime_, String prezime_, DateTime dat, int id_, Image slika_, double plata_, String tip, Stream pf) : base(ime_, prezime_, dat,  id_,  slika_,  plata_)
        {
            tipKuhara = tip;
            audioStream = pf;

        }

    }
}
