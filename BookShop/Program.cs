using BookShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BookShopDbContextConnection"]);
});
builder.Services.AddRazorPages();


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
app.MapRazorPages();
DbInitializer.Seed(app);

app.Run();
