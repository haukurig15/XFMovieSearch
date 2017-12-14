using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        private List<Movie> _movieList;
        private MovieServices _movieService;

        public MovieListPage(List<Movie> movieList, MovieServices movieService)
        {
            
            this._movieList = movieList;
            this._movieService = movieService;
            this.BindingContext = new MovieListViewModel(this.Navigation, this._movieList, this._movieService);
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movieList = await _movieService.GetActorsForList(this._movieList);
            InitializeComponent();
        }
    }
}
