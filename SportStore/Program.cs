using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDBContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
var app = builder.Build();
//app.MapGet('/', () => 'hello world');

app.UseStaticFiles();
app.MapControllerRoute("pagination",
    "Product/Page{productPage}",
    new {Controller ="Home" , Action= "Index"});
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
