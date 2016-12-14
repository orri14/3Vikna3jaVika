using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MovieSearch.Model
{
    public class Movies
    {
        private List<FilmInfo> _movies;
        private ApiService _apiService;

        public Movies()
        {
            this._movies = new List<FilmInfo>();
            this._apiService = new ApiService();
        }

        public List<FilmInfo> FilmInfos => this._movies;
        
        public void addMovie(FilmInfo movie)
        {
            this._movies.Add(movie);
        }

        public void clearMovies()
        {
            this._movies.Clear();
        }

        public async Task loadMoviesByTitle(string title)
        {
            clearMovies();
            List<FilmInfo> results = await _apiService.getMoviesByTitle(title);
            _movies.AddRange(results);

        }

        public async Task loadMoviesByTopRated()
        {
            clearMovies();
            List<FilmInfo> results = await _apiService.getTopRatedMovies();
            _movies.AddRange(results);
        }
    }
}