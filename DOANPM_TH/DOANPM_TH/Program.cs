using DOANPM_TH.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DOANPM_TH.Data;
using DOANPM_TH.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));
// builder.Services.AddSession();
// Configure services
int sessionTimeout = builder.Configuration.GetValue<int>("SessionSettings:IdleTimeout");
string sessionCookieName = builder.Configuration.GetValue<string>("SessionSettings:CookieName");

builder.Services.AddDistributedMemoryCache(); // In-memory caching
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(sessionTimeout);
    options.Cookie.IsEssential = true;
});

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

// Set up session in the pipeline
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeCustomer}/{action=Index}/{id?}");

app.Run();
