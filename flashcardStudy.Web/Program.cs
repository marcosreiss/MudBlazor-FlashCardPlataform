using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using flashcardStudy.Web;
using MudBlazor.Services;
using flascardStudy.Core;
using flascardStudy.Core.Handler;
using flashcardStudy.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(
    WebConfiguration.HttpClientName,
    opt =>
    {
        opt.BaseAddress = new Uri(Configuration.BackendUrl);
    });

builder.Services.AddTransient<IDeckHandler, DeckHandler>();
builder.Services.AddTransient<IFlashCardHandler, FlashCardHandler>();



await builder.Build().RunAsync();
