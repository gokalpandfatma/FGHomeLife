using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using FGHomeLife.Data;
using FGHomeLife.Services.SPServices.Blog;
using FGHomeLife.Services.EFServices.Blog;
using FGHomeLife.Services.EFServices.Home;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext configuration
builder.Services.AddDbContext<FGAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Warning'leri configure edelim
    options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogStoredProcService, BlogStoredProcService>();

// Cache ve Session için
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "blogDetail",
    pattern: "blog/{slug}",
    defaults: new { controller = "Blog", action = "Detail" });

app.MapControllerRoute(
    name: "blogCategory",
    pattern: "blog/kategori/{category}",
    defaults: new { controller = "Blog", action = "Index" });

app.MapControllerRoute(
    name: "blogTag",
    pattern: "blog/etiket/{tag}",
    defaults: new { controller = "Blog", action = "Index" });

app.Run();