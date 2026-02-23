using ASP.NET_Web.Models;
using ASP.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

// Create the builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AspNetWebContextConnection") ?? throw new InvalidOperationException("Connection string 'AspNetWebContextConnection' not found.");

builder.Services.AddDbContext<AspNetWebContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AspNetWebContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger(); // Generates the swagger.json file
app.UseSwaggerUI(); // Generates the beautiful HTML UI

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

// Force HTTP requests to upgrade to HTTPS
app.UseHttpsRedirection();

app.UseRouting();

// Enable Authorization
app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

app.MapStaticAssets();

// Map incoming URL routes to actual controller classes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Run the server
app.Run();