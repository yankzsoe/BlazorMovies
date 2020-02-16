using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers {
    static public class IJSRuntimeExtensionMethods {
        static public async ValueTask<bool> Confirm(this IJSRuntime js, string message) {
            await js.InvokeVoidAsync("console.log", message);
            return await js.InvokeAsync<bool>("confirm", message);
        }

        static public async ValueTask MyFunction(this IJSRuntime js, string message) {
            await js.InvokeVoidAsync("my_function", message);
        }
    }
}
