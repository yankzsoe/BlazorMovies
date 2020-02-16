﻿using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages {
    public partial class Counter {
        [Inject] SingletonServices singleton { get; set; }
        [Inject] TransientServices transient { get; set; }
        [Inject] IJSRuntime js { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;
        private async Task IncrementCount() {
            currentCount++;
            transient.Value = currentCount;
            singleton.Value = currentCount;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount() {
            return Task.FromResult(currentCountStatic);
        }
    }
}
