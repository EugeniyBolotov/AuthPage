using AuthPage;
using Blazorise;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using AuthPage.Implemenatations;
using AuthPage.Abstractions;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons()
    .AddBlazoriseRichTextEdit()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();

               

builder.Services.AddScoped(x => {
    var apiUrl = new Uri(builder.Configuration["apiUrl"]);

    // use fake backend if "fakeBackend" is "true" in appsettings.json
    if (builder.Configuration["fakeBackend"] == "true")
        return new HttpClient(new FakeBackendHandler()) { BaseAddress = apiUrl };

    return new HttpClient() { BaseAddress = apiUrl };
});

await builder.Build().RunAsync();