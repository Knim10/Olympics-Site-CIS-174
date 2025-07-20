using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OlympicGamesSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DbContext with SQL Server
builder.Services.AddDbContext<OlympicsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OlympicsDB")));

// Register ITicketRepository implementation
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Add ASP.NET Core Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>() // 🔷 Required for seeding roles
.AddEntityFrameworkStores<OlympicsDbContext>();

// Add Session (optional)
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

// Enable session and authentication
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // enable Identity UI pages

// 🔷 Run DataSeeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await DataSeeder.SeedAdminAsync(userManager, roleManager);
}

await app.RunAsync();
