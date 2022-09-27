using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cakeryz.Data;
using Cakeryz.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CakeryzContextConnection") ?? throw new InvalidOperationException("Connection string 'CakeryzContextConnection' not found.");

builder.Services.AddDbContext<CakeryzContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<CakeryzUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CakeryzContext>();;

builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("RequireAdministratorRole",
    //     policy => policy.RequireRole("Admin"));
    options.AddPolicy("adminPolicy", builder => builder.RequireRole("Admin"));
});

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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

