using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class PopularMoviesPage : ContentPage
    {
        private MovieServices _movieService;
        private List<Movie> _movieList;
        private List<MovieDetail> _movieDetailList;

        public PopularMoviesPage(MovieServices movieService, List<Movie> movieList, List<MovieDetail> movieDetailList)
        {
            this._movieService = movieService;
            this._movieList = movieList;
            this._movieDetailList = movieDetailList;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movieList = await _movieService.getListOfPopularMovies();
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieDetailList, this._movieService));
        }
    }
}
