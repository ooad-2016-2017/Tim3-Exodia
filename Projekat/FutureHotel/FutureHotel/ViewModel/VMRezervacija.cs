using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FutureHotel.ViewModel
{
    class VMRezervacija
    {
        String brojNocenja;
        String tipSobe;
        public VMRezervacija(List<String> lista)
        {
            tipSobe = lista[0];
            brojNocenja = lista[1];
            /*var dialog = new MessageDialog(lista[0]);
            dialog.ShowAsync();*/
            //potrebna komunikacija sa ekstermin uredjajem za dalje
        }
    }
}
