using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class TopRatedPage : ContentPage
    {
        private MovieServices _movieService;
        private List<Movie> _movieList;
        private List<MovieDetail> _movieDetailList;

        public TopRatedPage(MovieServices movieService, List<Movie> movieList, List<MovieDetail> movieDetailList)
        {
            this._movieService = movieService;
            this._movieList = movieList;
            this._movieDetailList = movieDetailList;
            InitializeComponent();
        }

       /* protected override async void OnAppearing()
        {
            this.Spinner.IsRunning = true;
            this._movieList = await _movieService.getListOfTopRatedMovies();
            this._movieDetailList = await _movieService.getListOfMovieDetails(this._movieList);
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieDetailList, this._movieService));
            this.Spinner.IsRunning = false;

        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movieList = await _movieService.GetActorsForList(this._movieList);
            InitializeComponent();
        }
    }
}
