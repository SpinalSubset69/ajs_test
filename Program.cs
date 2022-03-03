using AJSExample.Data;
using AJSExample.Data.Implementation;
using AJSExample.Helpers;
using AJSExample.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//EntityFrameWork
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("devConnection"));
});
//Mapping Profiles
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Product Repository DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
