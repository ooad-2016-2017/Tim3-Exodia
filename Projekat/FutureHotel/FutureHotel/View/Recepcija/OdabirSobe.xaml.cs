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

namespace FutureHotel.View.Recepcija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OdabirSobe : Page
    {
        public OdabirSobe()
        {
            this.InitializeComponent();
            DataContext = new VMHotelRezervacija();
        }

        private void Text1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null)
            {
                double height = contentTextBlock.Height;
                if (this.bNastavi.ActualHeight != height)
                {
                    double fontsizeMultiplier = this.bNastavi.ActualHeight * 0.3;
                    // Set the new FontSize 
                    this.Text1.FontSize = Math.Floor(fontsizeMultiplier);
                    this.Text2.FontSize = Math.Floor(fontsizeMultiplier);
                    this.tbBrojNocenja.FontSize = Math.Floor(fontsizeMultiplier);
                    this.cbTipSobe.FontSize = Math.Floor(fontsizeMultiplier);
                    this.bNastavi.FontSize = Math.Floor(fontsizeMultiplier);
                }
            }
        }
    }
}
