using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class MovieServices
    {
        private IApiMovieRequest _movieApi;

        public MovieServices(IApiMovieRequest movieApi)
        {
            _movieApi = movieApi;
        }

        public async Task<List<Movie>> getListOfMoviesMatchingSearch(string nameField)
        {
            List<Movie> responseMovieList = new List<Movie>();

            if (nameField.Length == 0)
            {
                return responseMovieList;
            }
            else
            {
                ApiSearchResponse<MovieInfo> response = await _movieApi.SearchByTitleAsync(nameField);
                var res = response?.Results;
                if (res != null)
                {
                    foreach (MovieInfo info in response.Results)
                    {

                        responseMovieList.Add(new Movie("")
                        {
                            Id = info.Id,
                            Title = $"{info.Title} ({info.ReleaseDate:yyyy})",
                            Actors = "",
                            ImageUrl = info.PosterPath,
                            Overview = info.Overview
                        });
                    }
                }
            }
            return responseMovieList;
        }


        public async Task<List<Movie>> getListOfTopRatedMovies()
        {
            List<Movie> responseMovieList = new List<Movie>();
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetTopRatedAsync(1);
            var res = response?.Results;
            if (res != null)
            {

                foreach (MovieInfo info in response.Results)
                {

                    responseMovieList.Add(new Movie("")
                    {
                        Id = info.Id,
                        Title = $"{info.Title} ({info.ReleaseDate:yyyy})",
                        Actors = "",
                        ImageUrl = info.PosterPath,
                        Overview = info.Overview
                    });
                }

            }
            return responseMovieList;
        }

        public async Task<List<Movie>> getListOfPopularMovies()
        {
            List<Movie> responseMovieList = new List<Movie>();
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetPopularAsync();
            var res = response?.Results;
            if (res != null)
            {
                foreach (MovieInfo info in response.Results)
                {


                    responseMovieList.Add(new Movie("")
                    {
                        Id = info.Id,
                        Title = $"{info.Title} ({info.ReleaseDate:yyyy})",
                        Actors = "",
                        ImageUrl = info.PosterPath,
                        Overview = info.Overview,
                        RunningTime = ""
                    });
                }
            }
            return responseMovieList;
        }


        public async Task<Movie> getListOfMovieDetails(Movie movie)
        {

            var movieDetail = await _movieApi.FindByIdAsync(movie.Id);
            var res = movieDetail?.Item;
            if (res != null)
            {
                movie.Genre = movieDetail.Item.Genres;
                var genre = "";

                for (int i = 0; i < movie.Genre.Count(); i++)
                {
                    if (i == movie.Genre.Count() - 1)
                    {
                        genre += movie.Genre[i].Name;
                    }
                    else
                    {
                        genre += movie.Genre[i].Name + ", ";
                    }
                }
                movie.Genres = genre;
                movie.RunningTime = movieDetail.Item.Runtime.ToString() + " min";
                movie.Tagline = movieDetail.Item.Tagline;
                movie.BackdropPath = movieDetail.Item.BackdropPath;

            }
            return movie;
        }

        public async Task<List<Movie>> GetActorsForList(List<Movie> movieList)
        {
            if (movieList.Count() != 0)
            {
                foreach (Movie movie in movieList)
                {
                    ApiQueryResponse<MovieCredit> cast = await _movieApi.GetCreditsAsync(movie.Id);
                    string actors = "";
                    int number = 3;
                    var res = cast?.Item?.CastMembers;
                    if (res != null)
                    {
                        if (cast.Item.CastMembers.Count < 3)
                        {
                            number = cast.Item.CastMembers.Count;
                        }
                        for (int i = 0; i < number; i++)
                        {
                            if (i == number - 1)
                            {
                                actors += cast.Item.CastMembers[i].Name;

                            }
                            else
                            {
                                actors += cast.Item.CastMembers[i].Name + ", ";

                            }
                        }
                        movie.Actors = actors;
                    }
                }
            }
            return movieList;
        }

    } 
}
