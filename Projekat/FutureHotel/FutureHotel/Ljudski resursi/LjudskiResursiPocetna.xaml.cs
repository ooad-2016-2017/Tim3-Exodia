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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FutureHotel.Ljudski_resursi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LjudskiResursiPocetna : Page
    {
        public LjudskiResursiPocetna()
        {
            this.InitializeComponent();
        }

        private void ButtonUpisNovogZaposlenika(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LjudskiResursiUpisZaposlenika));
        }

        private void ButtonPregledZaposlenih(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LjudskiResursiPregledZaposlenih));
        }
         

        private void Button1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                double fontsizeMultiplier = this.Button1.ActualWidth * 0.07;
                // Set the new FontSize 
                this.Button1.FontSize = Math.Floor(fontsizeMultiplier);
                this.Button2.FontSize = Math.Floor(fontsizeMultiplier);

            }
        }
    }
}
