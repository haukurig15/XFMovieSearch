﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieDatabase;
using Xamarin.Forms;
using XFMovieSearch.Pages;

namespace XFMovieSearch.ViewModel
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private Movie _selectedMovie;
        private List<Movie> _movieList = new List<Movie>();
        private MovieServices _movieService;

        public MovieListViewModel(INavigation navigation, MovieServices movieService)
        {
            this._navigation = navigation;
            this._movieService = movieService;
        }

        public List<Movie> Movie
        {
            get => this._movieList;

            set
            {
                this._movieList = value;
                OnPropertyChanged();
            }
        }


        public Movie SelectedMovie
        {
            get => this._selectedMovie;

            set
            {
                if (value != null)
                {
                    this._selectedMovie = value;
                    this._navigation.PushAsync(new MoviePage(this._selectedMovie, this._movieService), true);
                }
            }
        }

        public async Task LoadCast()
        {
            await this._movieService.GetActorsForList(Movie);
        }


        public async void LoadTopRatedMovies()
        {
            
            Movie = await _movieService.getListOfTopRatedMovies();
            await LoadCast();
           
        }

        public async void LoadPopularMovies()
        {

            Movie = await _movieService.getListOfPopularMovies();
            await LoadCast();

        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await LoadCast();

                    IsRefreshing = false;
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
