function my_function(message) {
    console.log("message from JavaScript file: " + message);
}

function dotnetStaticInvocation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript: " + result);
        });
}

function dotnetInstanceInvocation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}

function dotnetInstanceIvocationReturnValue(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("GetValues")
        .then(result => {
            console.log("return value is: " + result);
        });
}