using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Context;
using WebappIdentity_del2.Helpers.Factory;
using WebappIdentity_del2.Helpers.Repositories;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Db
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AppDatabase")));
//user and seed
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ContactService>();
//Product
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<IdentityContext>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
