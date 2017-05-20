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
    public sealed partial class LjudskiResursiUpisZaposlenika : Page
    {
        public LjudskiResursiUpisZaposlenika()
        {
            this.InitializeComponent();
        } 

        private void ButtonUnesi(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void TextBlockIme_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null)
            {
                double height = contentTextBlock.Height;
                if (this.ContextTextBox.ActualHeight != height)
                {
                    double fontsizeMultiplier = this.ContextTextBox.ActualHeight * 0.5;
                    // Set the new FontSize 
                    this.TextBlockIme.FontSize = Math.Floor(fontsizeMultiplier);
                    this.TextBlockDatum.FontSize = Math.Floor(fontsizeMultiplier);
                    this.TextBlockPlata.FontSize = Math.Floor(fontsizeMultiplier);
                    this.TextBlockPrezime.FontSize = Math.Floor(fontsizeMultiplier);
                    this.ContextTextBox.FontSize = Math.Floor(fontsizeMultiplier);
                    this.TextBoxPrezime.FontSize = Math.Floor(fontsizeMultiplier);
                    this.TextBoxPlata.FontSize = Math.Floor(fontsizeMultiplier);
                    this.ButtonUnesi1.FontSize = Math.Floor(fontsizeMultiplier * 0.5);
                    this.DatePicker.FontSize = Math.Floor(fontsizeMultiplier * 0.8);
                    this.DatePicker.Width = this.ContextTextBox.ActualWidth;
                }
            }
        }
    }
}
