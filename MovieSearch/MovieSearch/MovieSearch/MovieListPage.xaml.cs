using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;

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

            var movieInfoPage = new MovieInfoPage() { BindingContext = e.SelectedItem };
         
            this.Navigation.PushAsync(movieInfoPage);

        }
    }
}
