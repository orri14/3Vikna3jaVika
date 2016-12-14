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
            HorizontalOptions = LayoutOptions.Fill,
            Placeholder = "Enter a title...",
            PlaceholderColor = Color.White,
            TextColor = Color.White,
            FontFamily = "HelviticaNeue-Bold",
            FontSize = 36
        };

        private Button _searchButton = new Button
        {
            Text = "SEARCH",
            TextColor = Color.White,
            FontFamily = "HelviticaNeue-Bold",
            BorderWidth = 2,
            FontSize = 46,
            BorderColor = Color.White,
            BackgroundColor = Color.FromRgb(30,0,0),
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        public SearchPage(Movies movies)
        {
            _movies = movies;

            this.BackgroundColor = Color.FromRgb(70, 0, 0);

            this.Content = new StackLayout
            {
                Margin = 30,
                VerticalOptions = LayoutOptions.Start,
                Spacing = 10,
                Children =
                                       {
                                           new StackLayout { Children = {this._titleEntry, }, },
                                           this._searchButton,
                                       }
            };

            this._searchButton.Clicked += async (sender, args) =>
            {
                await _movies.loadMoviesByTitle(_titleEntry.Text);

                var searchResultPage = new MovieListPage() { BindingContext = this._movies };
                searchResultPage.Title = "Result for: " + _titleEntry.Text;
                
                          
                await this.Navigation.PushAsync(searchResultPage);
            };

        }
    }
}
