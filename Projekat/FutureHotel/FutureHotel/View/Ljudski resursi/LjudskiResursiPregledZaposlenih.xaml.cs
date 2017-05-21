using FutureHotel.ViewModel;
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
    public sealed partial class LjudskiResursiPregledZaposlenih : Page
    {
        public LjudskiResursiPregledZaposlenih()
        {
            this.InitializeComponent();
            DataContext = new VMPretragaZaposleni();
        }

        private void tbPretraga_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null)
            {
               
                double fontsizeMultiplier = this.tbPretraga.ActualHeight * 0.5;
                this.tbPretraga.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock1.FontSize = Math.Floor(fontsizeMultiplier);
                this.ListView1.FontSize = Math.Floor(fontsizeMultiplier);
                 
            }
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
