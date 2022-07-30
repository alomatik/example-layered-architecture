using Microsoft.EntityFrameworkCore;
using NLayer.Repository;
using NLayer.Service.Extensions;
using NLayer.Service.Mapping.AutoMapper;
using NLayer.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ProductApiService>(configureClient =>
{
    configureClient.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<CategoryApiService>(configureClient =>
{
    configureClient.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
