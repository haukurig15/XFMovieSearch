using System;

using Xamarin.Forms;

namespace XFMovieSearch
{
    public class MovieListPage : ContentPage
    {
        public MovieListPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

