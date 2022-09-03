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
                string vehicleVariantCode = this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords Where VehicleMake = @0 AND VehicleModel = @1 AND VehicleVariant = @2", vehicleMake, vehicleModel, vehicleVariant).VehicleVariantCode ?? "";

                string vehicleTypeCode = this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords Where VehicleMake = @0", vehicleMake).VehicleTypeCode ?? "";

                int RepairRefitCostExpense = this.dbContext.FirstOrDefault<RepairRefitCost>("Select * from RepairRefitCost where BodyPart = @0 AND VehicleTypeCode = @1", bodyPart, vehicleTypeCode).Expense ?? 0;

                int paintingExpense = this.dbContext.FirstOrDefault<PaintingCost>("Select * from PaintingCost where PanelDescription = @0 AND VehicleVariantCode = @1", panelDescription, vehicleVariantCode).Expense ?? 0;

                int newBodyPartsExpense = this.dbContext.FirstOrDefault<PartsCost>("Select * from PartsCost where BodyPart = @0 AND VehicleVariantCode = @1", bodyPart, vehicleVariantCode).Cost ?? 0;

                return new DamageThree(RepairRefitCostExpense, paintingExpense, newBodyPartsExpense);
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }
}
