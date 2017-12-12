﻿using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieDatabase
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public List<string> Actors { get; set; }
        public string ImageUrl { get; set; }
        public string localImagePath { get; set; }
        public ImageSource ImageSource => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + this.ImageUrl));
        //public ImageSource ImageSource => ImageSource.FromResource("https://image.tmdb.org/t/p/w500" + this.ImageUrl + ".png");

       
    }
}