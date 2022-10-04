using InvoiceProj;
using InvoiceProj.Models;
using InvoiceProj.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InvoiceDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInvoiceRepository<Invoice>, InvoiceRepository>();

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
    pattern: "{controller=Invoice}/{action=Index}");

app.Run();

