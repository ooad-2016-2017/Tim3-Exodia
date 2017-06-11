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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FutureHotel.Restoran
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Glavno_jelo : Page
    {
        public Glavno_jelo()
        {
            this.InitializeComponent();

            //this.UK.SomethingHappened += funkc;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (VMRestoran)e.Parameter;
        }

        private void daljeG_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Button contentTextBlock = sender as Button;
            if (contentTextBlock != null)
            {
                double fontsizeMultiplier = this.daljeG.ActualHeight * 0.4;
                // Set the new FontSize 
                this.RestoraniListView.FontSize = Math.Floor(fontsizeMultiplier);
                this.daljeG.FontSize = Math.Floor(fontsizeMultiplier);
                this.Text1.FontSize = Math.Floor(fontsizeMultiplier);

            }
        }
    }
}
