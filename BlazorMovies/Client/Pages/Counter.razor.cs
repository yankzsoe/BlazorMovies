using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages {
    public partial class Counter {
        [Inject] SingletonServices singleton { get; set; }
        [Inject] TransientServices transient { get; set; }

        List<Movie> movies;
        protected override void OnInitialized() {
            movies = new List<Movie>() {
            new Movie(){Title = "Spider-Man: Far From Home", ReleaseDate = new DateTime(2019, 7, 2)},
            new Movie(){Title = "Moana", ReleaseDate = new DateTime(2016, 11, 23)},
            new Movie(){Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16)}
        };
        }
        private int currentCount = 0;

        private void IncrementCount() {
            currentCount++;
            transient.Value = currentCount;
            singleton.Value = currentCount;
        }
    }
}
