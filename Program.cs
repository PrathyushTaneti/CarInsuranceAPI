using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceClasses;
using BeenFieldAPI.Services.ServiceInterfaces;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var container = new Container();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
    options.AddAspNetCore();
});


container.Register<ICustomerRecords, CustomerRecords>();




// Configure the HTTP request pipeline.

var app = builder.Build();
app.Services.UseSimpleInjector(container);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(header =>
    header.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
