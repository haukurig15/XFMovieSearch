using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;
        private List<Movie> _movieList;

        public XFMovieSearchPage(MovieServices movieService, List<Movie> movieList)
        {
            this._movieService = movieService;
            this._movieList = movieList;
            InitializeComponent();
        }

        private async void GetMoviesButton_OnClicked(object sender, EventArgs e)
        {
            this.Spinner.IsRunning = true;
            this._movieList = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieService));
            this.MovieEntry.Text = "";
            this.Spinner.IsRunning = false;
        }


    }
}
