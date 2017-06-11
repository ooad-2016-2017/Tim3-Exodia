using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FutureHotel.Ljudski_resursi;
using FutureHotel.Restoran;
using FutureHotel.View.Recepcija;
using FutureHotel.View.Vrata;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FutureHotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonLjudskiResursiClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LjudskiResursiPocetna));
            
        }

        private void ButtonHotel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                double fontsizeMultiplier = this.ButtonLjudskiResursi.ActualWidth * 0.07;
                // Set the new FontSize 
                this.ButtonHotel.FontSize = Math.Floor(fontsizeMultiplier);
                this.ButtonRestoran.FontSize = Math.Floor(fontsizeMultiplier);
                this.ButtonLjudskiResursi.FontSize = Math.Floor(fontsizeMultiplier);
                this.ButtonVrata.FontSize = Math.Floor(fontsizeMultiplier);                

            }
        }

        private void ButtonRestoranClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Predjelo));
        }

        private void ButtonHotelClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RecepcijaPocetna));
        }

        private void ButtonVrata_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VrataSnimanjeGlasa));
        }
    }
}
