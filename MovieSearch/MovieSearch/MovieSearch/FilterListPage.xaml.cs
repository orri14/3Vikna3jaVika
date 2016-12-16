using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;

namespace MovieSearch
{
	public partial class FilterListPage : ContentPage
	{
        public Movies _movies { get; set; }
        private bool _preLoad { get; set; } = true;
        private bool _isHot { get; set; }
        private ListView _listview;

        public ICommand RefreshCommand { get; set; }
        
        public FilterListPage (Movies movies, bool isHot)
		{
			InitializeComponent ();
            this._movies = movies;
            this._isHot = isHot;
            this._listview = this.FindByName<ListView>("listview");
            refreshPage();
            this._listview.RefreshCommand = new Command(() => 
            {
                this.refreshPage();
            });
            
        }

        private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            

            var movieInfoPage = new MovieInfoPage() { BindingContext = e.SelectedItem };

            ((ListView)sender).SelectedItem = null;

            this.Navigation.PushAsync(movieInfoPage);
            
        }

        private async void refreshPage()
        {

            
            this._indicator.IsRunning = (_preLoad) ? true : false; 
            this._indicator.IsVisible = (_preLoad) ? true : false;

            this._listview.IsEnabled = false;

            if (this._isHot)
            {
                await this._movies.loadMoviesByPopularity();
            }
            else
            {
                await this._movies.loadMoviesByTopRated();
            }

            BindingContext = this._movies;

            this._listview.EndRefresh();
            this._indicator.IsRunning = false;
            this._indicator.IsVisible = false;
            this._listview.IsEnabled = true;
            this._preLoad = false;
            
        }

    }
}
