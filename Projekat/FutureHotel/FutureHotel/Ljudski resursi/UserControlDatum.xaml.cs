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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FutureHotel
{
    public sealed partial class UserControlDatum : UserControl
    {
        public UserControlDatum()
        {
            this.InitializeComponent();
        }

        private void TextBlockSlika_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null) 
            {
                double height = contentTextBlock.Height;
                if (this.TextBoxSlika.ActualHeight != height)
                {
                    double fontsizeMultiplier = this.ButtonSlika.ActualHeight * 0.5;
                    // Set the new FontSize 
                    this.TextBlockSlika.FontSize = Math.Floor(fontsizeMultiplier);                    
                    this.ButtonSlika.FontSize = Math.Floor(fontsizeMultiplier * 0.8);
                }
            }
        }
    }



    
}
