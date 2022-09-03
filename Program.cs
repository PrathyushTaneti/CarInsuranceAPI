using BeenFieldAPI.Models;
/*using BeenFieldAPI.Services.ServiceClasses;
using BeenFieldAPI.Services.ServiceInterfaces;*/
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EstimationModelDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection"),
  sqlServerOptionsAction: sqlOptions =>
  {
      sqlOptions.EnableRetryOnFailure();
  }
  ));

/*Scaffold - DbContext "Server=.\SQLExpress; Database=NEWDB; Trusted_Connection=True;" Microsoft.EntityframeworkCore.SQLserver - OutputDir Models
*/
   // Add services to the container.

   builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
var container = new Container();

builder.Services.AddSimpleInjector(container, options =>
{
 options.AddAspNetCore().AddControllerActivation();
options.AddAspNetCore();
});*/
/*
container.Register<ICustomerTableService, CustomerTableService>();



app.Services.UseSimpleInjector(container);*/

// Configure the HTTP request pipeline.

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseCors(builder =>
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
