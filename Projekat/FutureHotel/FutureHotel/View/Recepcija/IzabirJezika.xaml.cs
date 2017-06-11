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

namespace FutureHotel.Recepcija
{
    public sealed partial class IzabirJezika : UserControl
    {
        public IzabirJezika()
        {
            this.InitializeComponent();
            cbJezici.Items.Add("Bosanski");
            cbJezici.SelectedItem = "Bosanski";
        }

        private void cbJezici_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ComboBox contentTextBlock = sender as ComboBox;
            if (contentTextBlock != null)
            {
                
                    double fontsizeMultiplier = this.cbJezici.ActualHeight * 0.5;
                    // Set the new FontSize 
                    this.cbJezici.FontSize = Math.Floor(fontsizeMultiplier);
                    this.Text1.FontSize = Math.Floor(fontsizeMultiplier);
                
            }
        }
    }
}
