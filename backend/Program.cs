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


container.Register<ICustomerRecordsService, CustomerRecordsService>();
container.Register<ICityCodesService, CityCodesService>();
container.Register<IDamageService, DamageService>();
container.Register<IOtherLabourService, OtherLabourService>();
container.Register<IPaintingCostService, PaintingCostService>();
container.Register<IPartsCostService, PartsCostService>();
container.Register<IRepairRefitCostService, RepairRefitCostService>();
container.Register<ISeverityLevelsService, SeverityLevelsService>();
container.Register<IVehicleRecordsService, VehicleRecordsService>();



// Configure the HTTP request pipeline.

var app = builder.Build();
app.Services.UseSimpleInjector(container);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.Run(async context =>
{
    await context.Response.WriteAsync("Hello Man");
});*/

/*app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("USE");
    await next();
    await context.Response.WriteAsync("ME");
});*/

app.UseCors(header =>
    header.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
