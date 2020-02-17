using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages {
    public partial class Counter {
        private int currentCount = 0;
        
        public void IncrementCount() {
            currentCount++;
        }
    }
}
