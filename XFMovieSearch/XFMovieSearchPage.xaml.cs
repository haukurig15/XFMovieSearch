using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public XFMovieSearchPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, new List<Movie>(), this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        private async void GetMoviesButton_OnClicked(object sender, EventArgs e)
        {
            this.Spinner.IsRunning = true;
            this._viewModel.Movie = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);

            //InitializeComponent();
            //await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieService));
            //this.MovieEntry.Text = "";
            this.Spinner.IsRunning = false;
        }


    }
}
