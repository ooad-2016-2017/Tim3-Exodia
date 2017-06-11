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

namespace FutureHotel.View.Vrata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VrataSnimanjeGlasa : Page
    {
        public VrataSnimanjeGlasa()
        {
            this.InitializeComponent();
            DataContext = new VMSnimanje(49);
        }

        private void ButtonSnimi_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button contentTextBlock = sender as Button;
            if (contentTextBlock != null)
            {
                double fontsizeMultiplier = this.ButtonSnimi.ActualWidth * 0.1;
                // Set the new FontSize 
                this.ButtonSnimi.FontSize = Math.Floor(fontsizeMultiplier);
                this.Text1.FontSize = Math.Floor(fontsizeMultiplier * 0.5);

            }
        }
    }
}
