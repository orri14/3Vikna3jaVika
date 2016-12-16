using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;
using Xamarin.Forms;

namespace MovieSearch
{
	public partial class TopRatedPage : ContentPage
	{
        private Movies _movies;

        public TopRatedPage (Movies movies)
		{
			InitializeComponent ();
            this._movies = movies;
  
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            this._indicator.IsRunning = true;
            this._indicator.IsVisible = true;

            await _movies.loadMoviesByTopRated();

            var topRatedPage = new MovieListPage() { BindingContext = this._movies };

            this._indicator.IsRunning = false;
            this._indicator.IsVisible = false;

            this.BindingContext = _movies;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _movies.clearMovies();
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
