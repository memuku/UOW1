using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UOWW.Core.Interfaces;
using UOWW.Infrastructure.Repository;
using UOWW.Infrastructure.UOWW;
using UOWW.Service.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PMSDbContext>(options =>
    options.UseInMemoryDatabase("demo"));

builder.Services.AddTransient<IUnitofWork, UnitofWork>();
builder.Services.AddTransient<ProjectService>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddRazorPages();

// Add authorization services
builder.Services.AddAuthorization(); // Add this line to add the required authorization services

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
