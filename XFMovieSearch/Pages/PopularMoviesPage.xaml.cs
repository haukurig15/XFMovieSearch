﻿using MovieDatabase;
using Xamarin.Forms;
using XFMovieSearch.ViewModel;

namespace XFMovieSearch.Pages
{
    public partial class PopularMoviesPage : ContentPage
    {
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public PopularMoviesPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        public void LoadPopularMovies()
        {
            this._viewModel.LoadPopularMovies();

        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.ListView.SelectedItem = null;
        }

    }
}
