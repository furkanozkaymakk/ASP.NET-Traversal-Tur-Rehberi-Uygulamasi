using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Entity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Travelsal.NetCoreProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Razor sayfa yenileme için
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSession();
var services = builder.Services;

services.AddDbContext<Context>();

// Validator için eklendi
services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().
	AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();

services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Login/AccessDeniedd"); //AccessDenied
});

services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

services.AddMvc(config =>
{
    
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

services.ContainerDependencies();

// Auto Mapper ý dahil etme
services.AddAutoMapper(typeof(Program));
// Kullandýðýmýzý buraya ekleyeceðiz
services.CustomerValidator();

services.AddControllersWithViews().AddFluentValidation();

services.AddMvc();

services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

ILoggerFactory loggerFactory = new LoggerFactory();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}\\Logs\\Logs1.txt");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseSession();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

// Ana sayfa için yol gösterimi
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

// Area lar için yol gösterimi
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
