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

        [HttpGet("{vehicleMake}/{vehicleModel}/{vehicleVariant}/{bodyPart}/{panelDescription}")]
        public DamageThree Get(string vehicleMake, string vehicleModel, string vehicleVariant, string bodyPart, string panelDescription)
        {
            try
            { 
                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMake = @0, @@VehicleModel = @1, @@BodyPart = @2;", vehicleMake, vehicleModel, bodyPart) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMake = @0, @@VehicleModel = @1, @@VehicleVariant = @2 ,@@PanelDescription = @3;", vehicleMake, vehicleModel, vehicleVariant, panelDescription) ?? new List<double>();

                List<double> partsCostList = this.dbContext.Fetch<double>("; exec PartsCostEstimation @@BodyPart = @0 , @@VehicleMake = @1 ,@@VehicleModel = @2 , @@VehicleVariant = @3;", bodyPart, vehicleMake, vehicleModel, vehicleVariant) ?? new List<double>();

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
