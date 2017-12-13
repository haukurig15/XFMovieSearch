using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            var movieService = new MovieServices(movieApi);

            var moviePage = new XFMovieSearchPage(movieService, new List<MovieDatabase.Movie>(), new List<MovieDetail>());
            var movieNavigationPage = new NavigationPage(moviePage);
            movieNavigationPage.Title = "Search";

            var topRatedPage = new TopRatedPage(movieService, new List<MovieDatabase.Movie>(), new List<MovieDetail>());
            var topRatedNavigationPage = new NavigationPage(topRatedPage);
            topRatedNavigationPage.Title = "Top Rated";

            var popularPage = new PopularMoviesPage(movieService, new List<MovieDatabase.Movie>(), new List<MovieDetail>());
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
    }
}
