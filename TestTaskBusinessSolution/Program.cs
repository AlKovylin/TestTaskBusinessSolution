using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTaskBusinessSolution;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.BLL.Services;
using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Entities;
using TestTaskBusinessSolution.DAL.Extensions;
using TestTaskBusinessSolution.DAL.Repositorys;

var builder = WebApplication.CreateBuilder(args);

string? connect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opton => opton.UseSqlServer(connect, option => option.EnableRetryOnFailure()));

builder.Services.AddUnitOfWork()
                .AddCustomRepository<Order, OrderRepository>()
                .AddCustomRepository<Item, ItemRepository>()
                .AddCustomRepository<Provider, ProviderRepository>();

builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IProviderService, ProviderService>();

var mapperConfig = new MapperConfiguration((v) =>
{
    v.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Orders/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");
app.Run();
