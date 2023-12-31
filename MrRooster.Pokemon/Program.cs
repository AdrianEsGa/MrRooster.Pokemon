using MRooster.Pokemon.Domain.Abstractions;
using MRooster.Pokemon.Domain.Options;
using MrRooster.Pokemon.Infrastructure.Database;
using MrRooster.Pokemon.Infrastructure.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddOptions<ConnectionStringOptions>().BindConfiguration(nameof(ConnectionStringOptions));

//Add database
builder.Services.AddSingleton<PokemonDbContext>();

//Add repositories
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddSingleton<ITeamRepository, TeamRepository>();

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
