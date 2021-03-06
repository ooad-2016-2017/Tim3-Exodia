﻿using FutureHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
//<<<<<<< HEAD
using Windows.Media.Audio;
//=======
using Windows.UI.Xaml.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml.Media;
using FutureHotel.Ljudski_resursi;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using Windows.Storage.Streams;
//>>>>>>> a9eb7bb8982431c94774fbc0f6c997c345713dc0

namespace FutureHotel.ViewModel
{
    public class VMZaposleni
    {
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTimeOffset datum { get; set; }
        public String plata { get;set; }
        public static string slika { get; set; }
        public ICommand kSlika { get; set; }
        public ICommand komanda { get; set; }
        public bool validirano { get; set; }

        IMobileServiceTable<Zaposlenik> userTableObj = App.MobileService.GetTable<Zaposlenik>();


        public VMZaposleni()
        {
            slika = "";
            kSlika = new RelayCommand<object>(dodajSliku, moze);
            komanda = new RelayCommand<object>(dodajZaposlenog, moze);
        }

        public async void validiraj()
        {
            Regex r = new Regex("^[a-z A-Z]+$");
            if (string.IsNullOrEmpty(ime) || !r.IsMatch(ime))
            {
                var dialog = new MessageDialog("Neispravno ime");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            if (string.IsNullOrEmpty(prezime) || !r.IsMatch(prezime))
            {
                var dialog = new MessageDialog("Neispravno prezime");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            r = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(plata) || !r.IsMatch(plata))
            {
                var dialog = new MessageDialog("Neispravna plata");
                await dialog.ShowAsync();
                validirano = false; return;
            }
            validirano = true;
        }

        public bool moze(object param)
        {
            return true;
        }

        public void dodajZaposlenog(object param)
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
        }

        public static void ubaci(string sliba)
        {
            slika = sliba;
        }

        public void dodajSliku(object param)
        {
            
        }
        
    }
}
