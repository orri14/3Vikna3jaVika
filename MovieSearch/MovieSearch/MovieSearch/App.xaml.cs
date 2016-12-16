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
    public partial class App : Application
    {
        private Movies _searchMovies;
        private Movies _topRatedMovies;
        private Movies _popularMovies;

        public App()
        {
            populateMovieLists();
            //The root page of the application
            var searchPage = new SearchPage(_searchMovies);
            var searchNavigationPage = new NavigationPage(searchPage) { 
                Title = "SEARCH",
                BarBackgroundColor = Color.FromRgb(212, 175, 55),
                BarTextColor = Color.White,
                //Icon = "TabbarIcons/Search-Filled-50.png"
            };

            var topRatedPage = new FilterListPage(_topRatedMovies, false);
            var topRatedNavigationPage = new NavigationPage(topRatedPage)
            {
                Title = "TOP RATED",
                BarBackgroundColor = Color.FromRgb(212, 175, 55),
                BarTextColor = Color.White,
                //Icon = "TabbarIcons/Star-Filled-50.png"
            };

            var popularPage = new FilterListPage(_popularMovies, true);
            var popularNavigationPage = new NavigationPage(popularPage)
            {
                Title = "HOT",
                BarBackgroundColor = Color.FromRgb(212, 175, 55),
                BarTextColor = Color.White,
                //Icon = "TabbarIcons/Gas-Filled-50.png"
            };


            var tabbar = new TabbedPage() { 
                BarBackgroundColor = Color.FromRgb(212,175,55),
                BarTextColor = Color.White
            };
            

            tabbar.Children.Add(searchNavigationPage);
            tabbar.Children.Add(topRatedNavigationPage);
            tabbar.Children.Add(popularNavigationPage);

            this.MainPage = tabbar;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void populateMovieLists()
        {
            this._searchMovies = new Movies();
            this._topRatedMovies = new Movies();
            this._popularMovies = new Movies();

        }
    }
}
