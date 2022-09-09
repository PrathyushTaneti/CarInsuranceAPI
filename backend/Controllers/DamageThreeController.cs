using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageThreeController : ControllerBase
    {
        private readonly IDatabase dbContext;
        public DamageThreeController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet("{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{panelDescription}/{cityName}")]
        public DamageThree Get(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, string panelDescription, string cityName)
        {
            try
            { 
                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@BodyPartId = @2, @@CityName = @3;", vehicleMakeCode, vehicleModelCode, bodyPartId, cityName) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@VehicleVariantCode = @2 ,@@PanelDescription = @3, @@CityName = @4;", vehicleMakeCode, vehicleModelCode, vehicleVariantCode, panelDescription, cityName) ?? new List<double>();

                List<double> partsCostList = this.dbContext.Fetch<double>("; exec PartsCostEstimation @@BodyPartId = @0 , @@VehicleMakeCode = @1 ,@@VehicleModelCode = @2 , @@VehicleVariantCode = @3, @@CityName = @4;", bodyPartId, vehicleMakeCode, vehicleModelCode, vehicleVariantCode, cityName) ?? new List<double>();

                double repairAndRefitCost = (repairAndRefitCostList.ToArray().Length != 0) ? repairAndRefitCostList.ToArray()[0] : 0;
                double paintingCost = (paintingCostList.ToArray().Length != 0) ? paintingCostList.ToArray()[0] : 0;
                double partsCost = (partsCostList.ToArray().Length != 0) ? partsCostList.ToArray()[0] : 0;

                return new DamageThree(repairAndRefitCost, paintingCost, partsCost);
            }
            catch (Exception e)
            {
                return new DamageThree(-1,-1,-1);
            }
        }
    }
}
