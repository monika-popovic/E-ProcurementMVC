global using E_Procurement.Data;
using E_Procurement.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.WebHost.UseWebRoot(
//Path.Combine(Directory.GetCurrentDirectory()
//, "wwwroot"));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<ISubcategoryRepository, SubcategoryRepository>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
