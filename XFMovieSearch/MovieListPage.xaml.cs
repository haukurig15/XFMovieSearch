using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage(Movie movie)
        {
            this.BindingContext = movie;
            InitializeComponent();
        }
    }
}
