using ASP.NET_Web.Models;
using ASP.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using ASP.NET_Web.Seeder;
Env.Load();

// Create the builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DATABASE_SOURCE"] ?? throw new InvalidOperationException("Connection string 'AspNetWebContextConnection' not found.");

builder.Services.AddDbContext<AspNetWebContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AspNetWebContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- ADD THIS BLOCK TO RUN THE SEEDER ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await RoleSeeder.SeedRolesAndAdminAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// ----------------------------------------

app.UseSwagger(); // Generates the swagger.json file
app.UseSwaggerUI(); // Generates the beautiful HTML UI

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithRedirects("/Error/{0}");

// Force HTTP requests to upgrade to HTTPS
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // Enable Authentacation
app.UseAuthorization(); // Enable Authorization

app.MapRazorPages();

app.MapStaticAssets();

// Map incoming URL routes to actual controller classes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Run the server
app.Run();