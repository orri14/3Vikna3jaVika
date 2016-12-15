using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;
using Xamarin.Forms;

using System.Diagnostics;

namespace MovieSearch
{
    public partial class SearchPage : ContentPage
    {
        private Movies _movies;

        private Entry _titleEntry = new Entry
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Placeholder = "Enter a title...",
            PlaceholderColor = Color.White,
            TextColor = Color.White,
            FontFamily = "HelveticaNeue-Bold",
            FontSize = 46,
            
        };

        private Button _searchButton = new Button
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Text = "SEARCH",
            TextColor = Color.FromRgb(70,0,0),
            FontFamily = "HelveticaNeue-Bold",
            FontSize = 46,
            BackgroundColor = Color.White,
        };

        private ActivityIndicator _indicator = new ActivityIndicator
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Color = Color.White
        };

        private async void onSearchButtonClicked(object sender, EventArgs args)
        {
            this._indicator.IsRunning = true;
            this._indicator.IsVisible = true;
            this._searchButton.IsEnabled = false;
            this._titleEntry.IsEnabled = false;

            await _movies.loadMoviesByTitle(_titleEntry.Text);

            var searchResultPage = new MovieListPage() { BindingContext = this._movies };

            await this.Navigation.PushAsync(searchResultPage);

            this._indicator.IsRunning = false;
            this._searchButton.IsEnabled = true;
            this._titleEntry.IsEnabled = true;
            this._indicator.IsVisible = false;
        }

        public SearchPage(Movies movies)
        {
            _movies = movies;

            this.BackgroundColor = Color.FromRgb(70, 0, 0);

            this.Content = new StackLayout
            {
                Margin = 25,
                Spacing = 25,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                                       {
                                           new StackLayout { Children = {this._titleEntry, }, },
                                           this._searchButton,
                                           this._indicator,
                                       }
            };

            this._searchButton.Clicked += onSearchButtonClicked;
        }
    }
}
