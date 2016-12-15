using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;
using Xamarin.Forms;

namespace MovieSearch
{
    public partial class App : Application
    {
        public App()
        {
            var movies = new Movies();
            //The root page of the application
            var searchPage = new SearchPage(movies);
            var searchNavigationPage = new NavigationPage(searchPage);
            
            searchNavigationPage.Title = "SEARCH";
            searchNavigationPage.BarBackgroundColor = Color.White;
            searchNavigationPage.BarTextColor = Color.Black;
            
            
            var popularPage = new MovieListPage();
            var popularNavigationPage = new NavigationPage(popularPage);
            popularNavigationPage.Title = "TOP RATED";
            searchNavigationPage.BarBackgroundColor = Color.White;
            searchNavigationPage.BarTextColor = Color.Black;
            

            var tabbar = new TabbedPage();
 
            tabbar.Children.Add(searchNavigationPage);
            //tabbar.Children.Add(popularNavigationPage);

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
    }
}
