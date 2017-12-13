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
        //private int i = 0;

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
                foreach (MovieInfo info in response.Results)
                {
                 
                    responseMovieList.Add(new Movie() { Id = info.Id, Title = info.Title, Year = info.ReleaseDate, Actors = "", ImageUrl = info.PosterPath});
                }
            }
            return responseMovieList;
        }

        public async Task<List<Movie>> GetActorsForList(List<Movie> movieList)
        {
            
            foreach (Movie movie in movieList)
            {
                ApiQueryResponse<MovieCredit> cast = await _movieApi.GetCreditsAsync(movie.Id);
                string actors = "";
                int number = 3;
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
            return movieList;
        }


        public async Task<List<Movie>> getListOfTopRatedMovies()
        {
            List<Movie> responseMovieList = new List<Movie>();
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetTopRatedAsync(1);
            foreach (MovieInfo info in response.Results)
            {
                

                responseMovieList.Add(new Movie() { Id = info.Id, Title = info.Title, Year = info.ReleaseDate, Actors = "", ImageUrl = info.PosterPath });
            }

            return responseMovieList;
        }

        public async Task<List<Movie>> getListOfPopularMovies()
        {
            List<Movie> responseMovieList = new List<Movie>();
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetPopularAsync();
            foreach (MovieInfo info in response.Results)
            {
                

                responseMovieList.Add(new Movie() { Id = info.Id, Title = info.Title, Year = info.ReleaseDate, Actors = "", ImageUrl = info.PosterPath });
            }

            return responseMovieList;
        }

      
        public async Task<List<MovieDetail>> getListOfMovieDetails(List<Movie> movieList)
        {
            List<MovieDetail> movieDetailList = new List<MovieDetail>();
            foreach (Movie movie in movieList)
            {
                var movieDetail = await _movieApi.FindByIdAsync(movie.Id);
                var runTime = movieDetail.Item.Runtime.ToString();
                movieDetailList.Add(new MovieDetail()
                {
                    Title = movieDetail.Item.Title,
                    Overview = movieDetail.Item.Overview,
                    Year = movieDetail.Item.ReleaseDate,
                    Genre = movieDetail.Item.Genres,
                    ImageUrl = movieDetail.Item.PosterPath,
                    RunningTime = runTime
                });
            }
            return movieDetailList;
        }

    } 
}
