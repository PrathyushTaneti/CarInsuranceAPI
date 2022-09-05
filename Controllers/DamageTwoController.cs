using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using System.Data.SqlClient;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageTwoController : ControllerBase
    {
        public readonly IDatabase dbContext;
        public DamageTwoController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet("{vehicleMake}/{vehicleModel}/{vehicleVariant}/{bodyPart}/{severity}/{panelDescription}")]
        public DamageTwo Get(string vehicleMake, string vehicleModel, string vehicleVariant, string bodyPart, string severity, string panelDescription)
        {
            try
            {
               List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@CarBodyPanel = @1", severity, bodyPart) ?? new List<double>();

                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMake = @0, @@VehicleModel = @1, @@BodyPart = @2;", vehicleMake, vehicleModel, bodyPart) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMake = @0, @@VehicleModel = @1, @@VehicleVariant = @2 ,@@PanelDescription = @3;", vehicleMake, vehicleModel, vehicleVariant, panelDescription) ?? new List<double>();

                double otherLabourCost = (otherLabourCostList.ToArray().Length != 0) ? otherLabourCostList.ToArray()[0] : 0;
                double repairAndRefitCost = (repairAndRefitCostList.ToArray().Length != 0) ? repairAndRefitCostList.ToArray()[0] : 0;
                double paintingCost = (paintingCostList.ToArray().Length != 0) ? paintingCostList.ToArray()[0] : 0;
                return new DamageTwo(otherLabourCost, repairAndRefitCost, paintingCost);
            }
            catch (Exception e)
            { 
                return new DamageTwo(-1,-1,-1);
            }
        }
    }
}
