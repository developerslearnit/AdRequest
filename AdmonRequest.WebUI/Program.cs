using AdmonRequest.WebUI.ServiceInstaller;
using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.InstallServicesInAssembly();
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/auth/login";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
        }); ;


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseHangfireDashboard("/bgtask/email");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
