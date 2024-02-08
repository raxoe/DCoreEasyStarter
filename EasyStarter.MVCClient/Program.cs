using EasyStarter.MVCClient.APIServices;
using Microsoft.Extensions.Http;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
//builder.Services.AddScoped<HttpClient>();
//builder.Services.AddHttpClient<T>(client =>
//{
//    client.BaseAddress = new Uri("https://api.example.com/");
//});

//builder.Services.AddScoped<IWeatherApiService, WeatherApiService>();

//var retryPolicy = HttpPolicyExtensions
//    .HandleTransientHttpError()
//    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

//var socketHandler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(15) };
//var pollyHandler = new PolicyHttpMessageHandler(retryPolicy)
//{
//    InnerHandler = socketHandler,
//};


builder.Services.AddHttpClient<IWeatherApiService, WeatherApiService>()
    .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(
                response => !response.IsSuccessStatusCode)
            .RetryAsync(5))
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new SocketsHttpHandler();
        handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
        //handler.AllowAutoRedirect = false;
        return handler;
    })
    .ConfigureHttpClient((configureClient) =>
    {
        configureClient.BaseAddress = new Uri("https://localhost:44320");
        configureClient.Timeout = new TimeSpan(0, 0, 30);
    });

builder.Services.AddHttpClient<ICategoryApiService, CategoryApiService>()
    .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(
                response => !response.IsSuccessStatusCode)
            .RetryAsync(5))
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new SocketsHttpHandler();
        handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
        //handler.AllowAutoRedirect = false;
        return handler;
    })
    .ConfigureHttpClient((configureClient) =>
    {    
        configureClient.BaseAddress = new Uri("https://localhost:44320/api/");
        configureClient.Timeout = new TimeSpan(0, 0, 30);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
