using Microsoft.EntityFrameworkCore;
using rdp.Data.Context;
using rdp.Data.Interfaces;
using rdp.Data.Mapping.Abstract;
using rdp.Data.Mapping.Concrete;
using rdp.Data.Repositories;
using rdp.Data.Uow;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// The type or namespace name 'T' could not be found (are you missing a using directive or an assembly reference?)
// builder.Services.AddScoped<IGenericRepository<T>,GenericRepository<T>>(); 

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); // Generic oldugu için "<>" değilde " () " içine yazdik 

builder.Services.AddScoped<IUserMapper,UserMapper>();
builder.Services.AddScoped<IUow,Uow>();
builder.Services.AddScoped<IAccountMapper,AccountMapper>();
builder.Services.AddScoped<IApplicationUserRepository,ApplicationUserRepository>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();

builder.Services.AddDbContext<BankContext>(optionsAction:options =>
    options.UseSqlServer("Server=Ryuka;Database=NewBankDb;Integrated Security=True;TrustServerCertificate=True"));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();