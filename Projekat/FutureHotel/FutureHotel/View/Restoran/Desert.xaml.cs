﻿using FutureHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Desert : Page
    {
        public Desert()
        {
            this.InitializeComponent();

            DataContext = new VMRestoran();
            //this.UK.SomethingHappened += funkc;
        }


        async public void funkc(object sender, EventArgs e)
        {
            var dialog = new MessageDialog("Uspjesno ste porucioli jelo");
            await dialog.ShowAsync();
        }
        async private void daljeG_Click_1(object sender, RoutedEventArgs e)
        {
            
            var dialog = new MessageDialog("Uspjesno ste porucioli jelo");
            await dialog.ShowAsync();
        }
    }
}
