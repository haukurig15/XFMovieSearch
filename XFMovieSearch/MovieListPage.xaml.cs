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
        private List<MovieDetail> _movieDetailList;

        public MovieListPage(List<Movie> movieList, List<MovieDetail> movieDetailList, MovieServices movieService)
        {
            
            this._movieList = movieList;
            this._movieDetailList = movieDetailList;
            this._movieService = movieService;
            this.BindingContext = new MovieListViewModel(this.Navigation, this._movieList, this._movieDetailList);
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
