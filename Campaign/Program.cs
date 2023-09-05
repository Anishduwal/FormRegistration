
using Campaign.Data;
using Campaign.Models;
using Campaign.Repository.FieldDetail;
using Campaign.Repository.Organization;
using Microsoft.EntityFrameworkCore;
using Mpmt.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IOrganizationRepo, OrganizationRepo>();
builder.Services.AddScoped<IFieldDetailRepo, FieldDetailRepo>();
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

//builder.Services.AddDbContext<MyDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Organization}/{action=Index}/{id?}");

app.Run();
