using FutureHotel.Model;
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
using FutureHotel.Ljudski_resursi;
//>>>>>>> a9eb7bb8982431c94774fbc0f6c997c345713dc0

namespace FutureHotel.ViewModel
{
    public class VMZaposleni
    {
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTime datum { get; set; }
        public String plata { get;set; }
        public BitmapImage slika { get; set; }
        public ICommand kSlika { get; set; }
        public ICommand komanda { get; set; }
        public bool validirano { get; set; }

        IMobileServiceTable<Zaposlenik> userTableObj = App.MobileService.GetTable<Zaposlenik>();


        public VMZaposleni()
        {
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
                    obj.dat_rodjenja = datum;
                    obj.plata = Double.Parse(plata);
                    obj.slika = slika.ToString();

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

        public async void dodajSliku(object param)
        {
            FileOpenPicker open = new FileOpenPicker();
            // Open a stream for the selected file 
            StorageFile file = await open.PickSingleFileAsync();
            // Ensure a file was selected 
            if (file != null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    Image TextBoxSlika = new Image();
                    // Set the image source to the selected bitmap 
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.DecodePixelWidth = 600; //match the target Image.Width, not shown
                    await bitmapImage.SetSourceAsync(fileStream);
                    TextBoxSlika.Source = bitmapImage;
                }
            }

            /*
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                //slika = new BitmapImage(new Uri("ms-appx:///FutureHotel/Assets/logo.png"));

            }*/
        }

        void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage bitmapImage = new BitmapImage();
            img.Width = bitmapImage.DecodePixelWidth = 80; //natural px width of image source
                                                           // don't need to set Height, system maintains aspect ratio, and calculates the other
                                                           // dimension, so long as one dimension measurement is provided
            bitmapImage.UriSource = new Uri(img.BaseUri, "ms-appx:///FutureHotel/Assets/logo.png");
        }
    }
}
