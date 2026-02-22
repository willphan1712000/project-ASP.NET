// Create the builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

// builder.Services.AddHttpsRedirection(option =>
// {
//     option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//     option.HttpsPort = 5110; // change this port in production
// });

var app = builder.Build();

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

app.MapStaticAssets();

// Map incoming URL routes to actual controller classes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Run the server
app.Run();