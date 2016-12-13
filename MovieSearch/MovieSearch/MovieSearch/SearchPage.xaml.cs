using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.Model;
using Xamarin.Forms;

namespace MovieSearch
{
    public partial class SearchPage : ContentPage
    {
        private Movies _movies;
        public SearchPage(Movies movies)
        {
            _movies = movies;

            this.InitializeComponent();

        }
    }
}
