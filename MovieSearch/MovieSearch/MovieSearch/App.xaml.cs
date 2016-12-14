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
             
            //The root page of the application
            var searchPage = new SearchPage(new Movies());
            var searchNavigationPage = new NavigationPage(searchPage);
            searchNavigationPage.Title = "Search for a movie!";

            var tabbar = new TabbedPage();

            tabbar.Children.Add(searchNavigationPage);


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
