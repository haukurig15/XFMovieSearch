using System;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;

        public XFMovieSearchPage(MovieServices movieService)
        {
            this._movieService = movieService;
            InitializeComponent();
        }

        private async void GetMoviesButton_OnClicked(object sender, EventArgs e)
        {
            var movieResult = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);
            this.MovieLabel.Text = movieResult[0].Title; 
        }
    }
}
