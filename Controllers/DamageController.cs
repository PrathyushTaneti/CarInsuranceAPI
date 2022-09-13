using BeenFieldAPI.DTOClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class DamageController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public DamageController()
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        [Route("MinorRepair/{bodyPartId}/{severity}/{cityName}")]
        public Damage GetExpense(int bodyPartId, string severity, string cityName)
        {
            try
            {
                if (bodyPartId <= 0 || String.IsNullOrEmpty(severity) || String.IsNullOrEmpty(cityName))
                {
                    throw new Exception("Invalid Input");
                }
                List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@BodyPartId = @1, @@CityName = @2", severity, bodyPartId, cityName) ?? new List<double>();
                double otherLabourExpense = (otherLabourCostList.ToArray().Length != 0) ? otherLabourCostList.ToArray()[0] : 0;
                return new Damage(otherLabourExpense,0,0,0);
            }
            catch (Exception e)
            {
                return new Damage(0,0,0,0);
            }
        }

        [HttpGet]
        [Route("MajorRepair/{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{severity}/{panelId}/{cityName}/{paintId}")]
        public Damage Get(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, string severity, int panelId, string cityName,int paintId)
        {
            try
            {

                if (String.IsNullOrEmpty(vehicleMakeCode) || String.IsNullOrEmpty(vehicleModelCode) || String.IsNullOrEmpty(vehicleVariantCode) || bodyPartId <= 0 || String.IsNullOrEmpty(severity) || panelId <= 0 || String.IsNullOrEmpty(cityName))
                {
                    throw new Exception("Invalid Input");
                }
                List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@BodyPartId = @1, @@CityName = @2;", severity, bodyPartId, cityName) ?? new List<double>();

                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@BodyPartId = @2, @@CityName = @3", vehicleMakeCode, vehicleModelCode, bodyPartId, cityName) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@VehicleVariantCode = @2 ,@@PanelId = @3, @@CityName = @4, @@PaintId = @5;", vehicleMakeCode, vehicleModelCode, vehicleVariantCode, panelId, cityName, paintId) ?? new List<double>();

                double otherLabourCost = (otherLabourCostList.ToArray().Length != 0) ? otherLabourCostList.ToArray()[0] : 0;
                double repairAndRefitCost = (repairAndRefitCostList.ToArray().Length != 0) ? repairAndRefitCostList.ToArray()[0] : 0;
                double paintingCost = (paintingCostList.ToArray().Length != 0) ? paintingCostList.ToArray()[0] : 0;
                return new Damage(otherLabourCost, repairAndRefitCost, paintingCost,0);
            }
            catch (Exception e)
            {
                return new Damage(-1, -1, -1,-1);
            }
        }

        [HttpGet]
        [Route("Replacement/{vehicleMakeCode}/{vehicleModelCode}/{vehicleVariantCode}/{bodyPartId}/{panelId}/{cityName}/{paintId}")]
        public Damage Get(string vehicleMakeCode, string vehicleModelCode, string vehicleVariantCode, int bodyPartId, int panelId, string cityName, int paintId)
        {
            try
            {
                if (String.IsNullOrEmpty(vehicleMakeCode) || String.IsNullOrEmpty(vehicleModelCode) || String.IsNullOrEmpty(vehicleVariantCode) || bodyPartId <= 0 || panelId <= 0 || String.IsNullOrEmpty(cityName))
                {
                    throw new Exception("Invalid Inputs");
                }
                List<double> repairAndRefitCostList = this.dbContext.Fetch<double>("; exec RepairRefitCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@BodyPartId = @2, @@CityName = @3;", vehicleMakeCode, vehicleModelCode, bodyPartId, cityName) ?? new List<double>();

                List<double> paintingCostList = this.dbContext.Fetch<double>("; exec PaintingCostEstimation @@VehicleMakeCode = @0, @@VehicleModelCode = @1, @@VehicleVariantCode = @2 ,@@PanelId = @3, @@CityName = @4, @@PaintId = @5;", vehicleMakeCode, vehicleModelCode, vehicleVariantCode, panelId, cityName, paintId) ?? new List<double>();

                List<double> partsCostList = this.dbContext.Fetch<double>("; exec PartsCostEstimation @@BodyPartId = @0 , @@VehicleMakeCode = @1 ,@@VehicleModelCode = @2 , @@VehicleVariantCode = @3, @@CityName = @4;", bodyPartId, vehicleMakeCode, vehicleModelCode, vehicleVariantCode, cityName) ?? new List<double>();

                double repairAndRefitCost = (repairAndRefitCostList.ToArray().Length != 0) ? repairAndRefitCostList.ToArray()[0] : 0;
                double paintingCost = (paintingCostList.ToArray().Length != 0) ? paintingCostList.ToArray()[0] : 0;
                double partsCost = (partsCostList.ToArray().Length != 0) ? partsCostList.ToArray()[0] : 0;

                return new Damage(0,repairAndRefitCost, paintingCost, partsCost);
            }
            catch (Exception e)
            {
                return new Damage(-1, -1, -1,-1);
            }
        }
    }
}
