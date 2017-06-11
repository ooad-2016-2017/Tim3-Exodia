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

namespace FutureHotel.View.Recepcija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecepcijaPocetna : Page
    {
        public RecepcijaPocetna()
        {
            this.InitializeComponent();
        }

        private void bNastavi_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OdabirSobe));
        }

        private void bNastavi_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button contentTextBlock = sender as Button;
            if (contentTextBlock != null)
            {
                double fontsizeMultiplier = this.bNastavi.ActualWidth * 0.1;
                this.bNastavi.FontSize = Math.Floor(fontsizeMultiplier);                
            }
        }
        
    }
}
