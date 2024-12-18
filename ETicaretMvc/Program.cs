using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Concretes;
using ETicaretApi.Persistence.Repositories.Customer;
using ETicaretApi.Persistence.Repositories.Product;
using ETicaretApi.Persistence.Repositories.Order;
using ETicaretApi.Persistence.Repositories.ProductImage;
using ETicaretApi.Application.Abstractions.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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
