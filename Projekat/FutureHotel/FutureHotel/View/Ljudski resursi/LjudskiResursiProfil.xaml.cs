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
    public sealed partial class LjudskiResursiProfil : Page
    {
        public LjudskiResursiProfil()
        {
            this.InitializeComponent();
        }

        private void TextBlock1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null)
            {
                double fontsizeMultiplier = this.Button1.ActualHeight * 0.6;
                // Set the new FontSize 
                this.TextBlock1.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock2.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock3.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock4.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock5.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock6.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock7.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock8.FontSize = Math.Floor(fontsizeMultiplier);
                this.TextBlock9.FontSize = Math.Floor(fontsizeMultiplier);  
                this.Button1.FontSize = Math.Floor(fontsizeMultiplier * 0.7);

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (VMLjudskiResursiProfil)e.Parameter;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
