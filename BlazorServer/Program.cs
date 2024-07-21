using Microsoft.AspNetCore.ResponseCompression;
using BlazorServer.Hubs;
using BlazorServer.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using BlazorServer.Data.Database;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CookiesManager>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/ocetet-steam" });
});
//builder.Services.AddSingleton<LoginManager>();
builder.Services.AddSingleton<UserConnectionMapper>();
builder.Services.AddScoped<LoginSession>();

builder.Services.AddDbContext<MessagesContext>(options =>
    options.UseNpgsql("Host=localhost;Database=BoringMediaMessages;Username=postgres;Password=root"));

builder.Services.AddDbContext<UsersContext>(options =>
    options.UseNpgsql("Host=localhost;Database=BoringMediaUsers;Username=postgres;Password=root"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToPage("/_Host");


app.Run();
