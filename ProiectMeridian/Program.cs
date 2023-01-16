using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectMeridian.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Phones");
    options.Conventions.AllowAnonymousToPage("/Phones/Index");
    options.Conventions.AllowAnonymousToPage("/Phones/Details");

});
builder.Services.AddDbContext<ProiectMeridianContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMeridianContext") ?? throw new InvalidOperationException("Connection string 'ProiectMeridianContext' not found.")));


builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMeridianContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectMeridianContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();