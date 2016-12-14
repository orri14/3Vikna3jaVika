﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage()
        {
            this.InitializeComponent();


        }

        private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            this.DisplayAlert(e.SelectedItem.ToString(), string.Empty, "Ok");
        }
    }
}
