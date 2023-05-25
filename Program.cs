using ConsumeSpotifyWebAPI.Services;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
configuration.AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient<ISpotifyServices, SpotifyServices>(c =>
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api");
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();
var app = builder.Build();


// Configure the HTTP request pipeline.


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
