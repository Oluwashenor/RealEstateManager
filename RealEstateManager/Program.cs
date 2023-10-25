using Microsoft.EntityFrameworkCore;
using RealEstateManager.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(configuration.GetConnectionString("RealEstateDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<RealEstateContext>();
context.EnsureSeedData();

app.UseAuthorization();

app.MapControllers();

app.Run();
