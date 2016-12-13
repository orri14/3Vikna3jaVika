using System.Collections.Generic;

namespace MovieSearch.Model
{
    public class Movies
    {
        private List<FilmInfo> _movies;

        public Movies()
        {
            this._movies = new List<FilmInfo>();
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

        public void loadMoviesByTitle(string title)
        {
            clearMovies();
            //TODO call API service and add search results to _movies
        }

        public void loadMoviesByTopRated()
        {
            clearMovies();
            //TODO: call API service and add top rated movies to _movies
        }
    }
}