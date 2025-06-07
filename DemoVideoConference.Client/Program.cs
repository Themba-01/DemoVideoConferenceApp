using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DemoVideoConference.Client;
using DemoVideoConference.Client.States;
using Microsoft.FluentUI.AspNetCore.Components;
using NetcodeHub.Packages.Extensions.LocalStorage;
using DemoVideoConference.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using DemoVideoConferenceApp.Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluentUIComponents();
builder.Services.AddNetcodeHubLocalStorageService();

string clientName = builder.Configuration["HttpClient:Name"]! ??
    throw new InvalidOperationException("config Setup for HttpClient not found");

builder.Services.AddHttpClient(clientName, options =>
{
    string baseAddress = builder.Configuration["Server:BaseAddress"]!
    ?? throw new InvalidOperationException("Base Address not found");
    options.BaseAddress = new Uri($"{baseAddress}/api/");
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<ITwilioService, TwilioService>();

builder.Services.AddScoped<IHttpExtension, HttpExtension>();

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>
    (sp => sp.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<NavState>();

await builder.Build().RunAsync();
