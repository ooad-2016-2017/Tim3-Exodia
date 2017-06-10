using FutureHotel.Model;
using FutureHotel.View.Recepcija;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FutureHotel.ViewModel
{
    public class VMHotelRezervacija
    {
        public String tipSobe { get; set; }
        public String brojNocenja { get; set; }
        public List<String> TipoviSobe { get; set; }
        bool validirano { get; set; }
        public String tjednaNoc = "Jedna noc:\t0$";
        public String tbrojNocenja = "Broj nocenja:\t0";
        public String tukupno = "Ukupno:\t0$";

        public List<Soba> sve_sobe { get; set; }

        IMobileServiceTable<Soba> userTableObj = App.MobileService.GetTable<Soba>();



        public ICommand proslijedi { get; set; }

        public async void validiraj()
        {
            Regex r = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(brojNocenja) || !r.IsMatch(brojNocenja))
            {
                var dialog = new MessageDialog("Broj nocenja nije validan");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            if(tipSobe == null)
            {
                var dialog = new MessageDialog("Tip sobe nije izabran!");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            validirano = true;
        }



        public async void bNastaviClick(object param)
        {
            //Ovu smo metodu koristili kada smo popunlili tabelu soba
            await nafiluj();
            IEnumerable<Soba> sobee = await userTableObj.ReadAsync();
            sve_sobe = new List<Soba>(sobee);

            validiraj();
            if (validirano)
            {
                int cijena;
                String text = "Jedna noc:\t";
                if(tipSobe == "Jednokrevetna")
                {
                    cijena = 15;
                    text += "15$";
                }
                else if(tipSobe == "Dvokrevetna")
                {
                    cijena = 25;
                    text += "25$";
                }
                else
                {
                    cijena = 30;
                    text += "30$";
                }
                text += "\nBroj nocenja:\t" + int.Parse(brojNocenja);
                text += "\nUkupno:\t\t" + int.Parse(brojNocenja) * cijena + "$";
                var dialog = new MessageDialog(text);
                dialog.Title = "Cijena";
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
                var res = await dialog.ShowAsync();
                if ((int)res.Id == 0) {
                    var frame = (Frame)Window.Current.Content;
                    List<String> s = new List<String>();
                    s.Add(tipSobe);
                    s.Add(brojNocenja);
                    Soba zeljena = null;

                    //ovdje provjeriti da li postoji zeljeni tip sobe
                    for (int i = 0; i < sve_sobe.Count; i++)
                    {
                        if (tipSobe.Equals(sve_sobe[i].tip) && sve_sobe[i].zauzetaDo < System.DateTime.Today) {
                            sve_sobe[i].zauzetaDo = System.DateTime.Today.AddDays(Double.Parse(brojNocenja));
                            zeljena = sve_sobe[i];
                           
                        }
                    }
                    if (zeljena == null)
                    {
                        var dialog1 = new MessageDialog("Ne postoji slobodna soba s takvim karakteristikama.");
                        await dialog1.ShowAsync();
                    }
                    else
                    {
                        VMRezervacija rez = new VMRezervacija(zeljena);
                        frame.Navigate(typeof(RecepcijaUzimanjeGlasa), rez);
                    }
                }
            }
        }

        public async Task nafiluj()
        {
            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    Soba obj = new Soba();
                    obj.redni_br = i;
                    obj.tip = TipoviSobe[i % 3];
                    userTableObj.InsertAsync(obj);
                }

            } catch(Exception e) {
                MessageDialog msgDialogError = new MessageDialog("Error : " +
                   e.ToString());
                msgDialogError.ShowAsync();
            }
            /* public void dodajZaposlenog(object param)
        {
            validiraj();
            if (validirano)
            {
                //rad sa bazom

                try
                {
                    Zaposlenik obj = new Zaposlenik();
                    obj.ime = ime;
                    obj.prezime = prezime;
                    obj.dat_rodjenja = datum.ToString();
                    obj.plata = Double.Parse(plata);
                    obj.slika = slika;

                    userTableObj.InsertAsync(obj);
                    MessageDialog msgDialog = new MessageDialog("Uspješno ste unijeli novog zaposlenog.");
                     msgDialog.ShowAsync();

                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " +
                   ex.ToString());
                    msgDialogError.ShowAsync();
                }
            }
        }*/
        }

        public VMHotelRezervacija()
        {
            validirano = false;
            TipoviSobe = new List<String>();
            TipoviSobe.Add("Jednokrevetna");
            TipoviSobe.Add("Dvokrevetna");
            TipoviSobe.Add("Bracnokrevetna");
            proslijedi = new RelayCommand<object>(bNastaviClick, moze);


            //Ovdje učitati sve sobe u listu soba, pa kasnije ju proslijediti tamo (u VM rezervacija) gdje ce se izvrsiti finalna pohrana


        }

        public bool moze (object param) { return true; }
    }
}
