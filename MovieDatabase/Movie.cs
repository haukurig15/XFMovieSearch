using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DM.MovieApi.MovieDb.Genres;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MovieDatabase;

namespace MovieDatabase
{
    

    public class Movie  : INotifyPropertyChanged
    {
        private string _actors;

        public Movie(string actors){
            this._actors = actors;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        //public string Actors { get; set; }

        public string Actors
        {
            get => this._actors; 

            set
            {
                this._actors = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl { get; set; }
        public ImageSource ImageSource => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + this.ImageUrl));
        public IReadOnlyList<Genre> Genre { get; set; }
        public string Genres { get; set; }
        public string RunningTime { get; set; }
        public string Overview { get; set; }
        public string BackdropPath { get; set; }
        public ImageSource BackdropPathSource => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + this.BackdropPath));
        public string Tagline { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
    }




}