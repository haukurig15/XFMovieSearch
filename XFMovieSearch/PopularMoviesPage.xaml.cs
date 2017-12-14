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

        public PopularMoviesPage(MovieServices movieService)
        {
            this._movieService = movieService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movieList = await _movieService.getListOfPopularMovies();
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieService));
        }
    }
}
