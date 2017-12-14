using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class TopRatedPage : ContentPage
    {
        private MovieServices _movieService;
       // private List<Movie> _movieList;
        private MovieListViewModel _viewModel;

        public TopRatedPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, new List<Movie>(), this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        public void LoadTopRatedMovies()
        {
            this._viewModel.LoadTopRatedMovies();
        }

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            //this._movieList = await _movieService.getListOfTopRatedMovies();
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieService));
            InitializeComponent();
        }*/
    }
}
