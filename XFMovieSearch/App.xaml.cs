using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class App : Application
    {

        private List<MovieDatabase.Movie> _topRatedMovies = new List<MovieDatabase.Movie>();
        private List<MovieDatabase.Movie> _popularMovies = new List<MovieDatabase.Movie>();
        private MovieServices _movieService;

        public App()
        {
            InitializeComponent();

            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            this._movieService = new MovieServices(movieApi);

            LoadTopRatedMovies();
            LoadPopularMovies();


            var moviePage = new XFMovieSearchPage(this._movieService, new List<MovieDatabase.Movie>());
            var movieNavigationPage = new NavigationPage(moviePage);
            movieNavigationPage.Title = "Search";

            var topRatedPage = new TopRatedPage(this._movieService, this._topRatedMovies);
            var topRatedNavigationPage = new NavigationPage(topRatedPage);
            topRatedNavigationPage.Title = "Top Rated";

            var popularPage = new PopularMoviesPage(this._movieService, this._popularMovies);
            var popularNavigationPage = new NavigationPage(popularPage);
            popularNavigationPage.Title = "Popular movies";

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(movieNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);
            tabbedPage.Children.Add(popularNavigationPage);


            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        private async void LoadTopRatedMovies()
        {
            this._topRatedMovies = await this._movieService.getListOfTopRatedMovies();
        }

        private async void LoadPopularMovies()
        {
            this._popularMovies = await this._movieService.getListOfPopularMovies();
        }
    }
}
