﻿using RestaurantManager.Models;
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

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {

        

        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {

            DataManager dm = App.Current.Resources["DataManager"] as DataManager;

            foreach (Object OrderItem in this.MenuList.SelectedItems)
            {
                dm.CurrentlySelectedMenuItems.Add(OrderItem.ToString());
            }

            //remove selection
            this.MenuList.SelectedIndex = -1;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DataManager dm = App.Current.Resources["DataManager"] as DataManager;

            String Order = String.Join(", ", dm.CurrentlySelectedMenuItems);

            dm.OrderItems.Add(Order);

            dm.CurrentlySelectedMenuItems.Clear();
        }

    }
}
