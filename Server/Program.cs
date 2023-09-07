using GuessTheFlag.Server.Data;
using GuessTheFlag.Server.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("GuessTheFlagConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

/// <summary>
/// Lägger till en tjänst i dependency injection-container för att hantera landrelaterad data.
/// </summary>
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
/// <summary>
/// Lägger till en tjänst i dependency injection-container för att hantera flaggrelaterad data.
/// </summary>
builder.Services.AddScoped<IFlagRepo, FlagRepo>();
/// <summary>
/// Lägger till en tjänst i dependency injection-container för att hantera användarrelaterad data.
/// </summary>
builder.Services.AddScoped<IUserRepo, UserRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
