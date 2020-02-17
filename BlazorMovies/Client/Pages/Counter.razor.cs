using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorMovies.Client.Shared.MainLayout;

namespace BlazorMovies.Client.Pages {
    public partial class Counter {
        [Inject] SingletonServices singleton { get; set; }
        [Inject] TransientServices transient { get; set; }
        [Inject] IJSRuntime js { get; set; }

        [CascadingParameter] public StyleClass styleClass { get; set; }
        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount() {
            currentCount++;
            transient.Value = currentCount;
            singleton.Value = currentCount;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        private async Task IncrementCountJavaScript() {
            await js.InvokeVoidAsync("dotnetInstanceInvocation",
                DotNetObjectReference.Create(this));
            await js.InvokeVoidAsync("dotnetInstanceIvocationReturnValue",
                DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount() {
            return Task.FromResult(currentCountStatic);
        }

        [JSInvokable]
        public int GetValues() {
            return 1700;
        }
    }
}
