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
            var searchNavigationPage = new NavigationPage(searchPage) { 
                Title = "SEARCH",
                BarBackgroundColor = Color.FromRgb(212, 175, 55),
                BarTextColor = Color.White
                //Icon = "TabbarIcons/Search-Filled-50.png";
            };

            var topRatedPage = new TopRatedPage(new Movies());
            var topRatedNavigationPage = new NavigationPage(topRatedPage)
            {
                Title = "TOP RATED",
                BarBackgroundColor = Color.FromRgb(212, 175, 55),
                BarTextColor = Color.White
                //Icon = "TabbarIcons/Star-Filled-50.png";
            };


            var tabbar = new TabbedPage() { 
                BarBackgroundColor = Color.FromRgb(212,175,55),
                BarTextColor = Color.White
            };
            

            tabbar.Children.Add(searchNavigationPage);
            tabbar.Children.Add(topRatedNavigationPage);

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
