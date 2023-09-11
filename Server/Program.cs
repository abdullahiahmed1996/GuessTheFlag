using GuessTheFlag.Server.Data;
using GuessTheFlag.Server.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("GuessTheFlagConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddRazorPages();

/// <summary>
/// L�gger till en tj�nst i dependency injection-container f�r att hantera landrelaterad data.
/// </summary>
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
/// <summary>
/// L�gger till en tj�nst i dependency injection-container f�r att hantera flaggrelaterad data.
/// </summary>
builder.Services.AddScoped<IFlagRepo, FlagRepo>();
/// <summary>
/// L�gger till en tj�nst i dependency injection-container f�r att hantera anv�ndarrelaterad data.
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
