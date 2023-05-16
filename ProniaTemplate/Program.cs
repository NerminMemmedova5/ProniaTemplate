using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProniaDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "Default",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"
    );

app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=home}/{action=index}/{id?}"
    );

app.Run();
