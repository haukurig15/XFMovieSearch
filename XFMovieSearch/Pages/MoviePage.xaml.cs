﻿using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch.Pages
{
    public partial class MoviePage : ContentPage
    {

        private Movie _movie;
        private MovieServices _movieService;

        public MoviePage(Movie movie, MovieServices movieService)
        {
            this._movie = movie;
            this._movieService = movieService;
            this.BindingContext = movie;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movie = await _movieService.getListOfMovieDetails(this._movie);
            InitializeComponent();
        }
    }
}
