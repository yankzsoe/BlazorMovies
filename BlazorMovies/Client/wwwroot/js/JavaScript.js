function my_function(message) {
    console.log("message from JavaScript file: " + message);
}

function dotnetStaticInvocation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript: " + result);
        });
}