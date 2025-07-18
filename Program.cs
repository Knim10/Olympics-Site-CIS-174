using Microsoft.EntityFrameworkCore;
using OlympicGamesSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DbContext with SQL Server
builder.Services.AddDbContext<OlympicsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OlympicsDB")));

// Add Ticket repository for DI
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

// Enable session BEFORE authorization
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "home",
    pattern: "Olympic/{action=Index}/{id?}",
    defaults: new { controller = "Home" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
