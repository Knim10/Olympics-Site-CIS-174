using Microsoft.EntityFrameworkCore;
using OlympicGamesSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DbContext with SQL Server
builder.Services.AddDbContext<OlympicsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OlympicsDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sports}/{action=Index}/{id?}");

app.Run();
