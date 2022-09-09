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

        [HttpGet]
        public List<SeverityLevel> Get()
        {
            try
            {
                return this.dbContext.Query<SeverityLevel>("select * from SeverityLevel").ToList() ?? new List<SeverityLevel>();
            }
            catch(Exception e)
            {
                return new List<SeverityLevel>();
            }
        }

        [HttpGet("{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{severity}/{panelDescription}/{cityName}")]
        public DamageTwo Get(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, string severity, string panelDescription, string cityName)
        {
            try
            {
               List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@BodyPartId = @1, @@CityName = @2;", severity, bodyPartId, cityName) ?? new List<double>();

                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@BodyPartId = @2, @@CityName = @3", vehicleMakeCode, vehicleModelCode, bodyPartId, cityName) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@VehicleVariantCode = @2 ,@@PanelDescription = @3, @@CityName = @4;", vehicleMakeCode, vehicleModelCode, vehicleVariantCode, panelDescription, cityName) ?? new List<double>();

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
