using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

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
                string vehicleTypeCode = this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords where VehicleMake = @0", vehicleMake).VehicleTypeCode ?? "";
                string vehicleVariantCode = this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords where VehicleMake = @0 AND VehicleModel = @1 AND VehicleVariant = @2", vehicleMake, vehicleModel, vehicleVariant).VehicleVariantCode ?? "";
                int RepairRefitCostCost = 0;
                int paintingCost = 0;
                if (vehicleTypeCode != "" && vehicleVariantCode != "")
                {
                    RepairRefitCostCost = this.dbContext.SingleOrDefault<RepairRefitCost>("Select * from RepairRefitCost where BodyPart = @0 AND VehicleTypeCode = @1", bodyPart, vehicleTypeCode).Expense ?? 0;
                    paintingCost = this.dbContext.SingleOrDefault<PaintingCost>("Select * from PaintingCost where PanelDescription = @0 AND VehicleVariantCode = @1", panelDescription, vehicleVariantCode).Expense ?? 0;
                }

                double OtherLabourCostCost = 0;
                switch (severity)
                {
                    case "s1":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select LowSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S1":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select LowSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S2":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select MediumSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "s2":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select MediumSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "S3":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select HighSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    case "s3":
                        OtherLabourCostCost = this.dbContext.FirstOrDefault<OtherLabourCost>("select HighSeverity from OtherLabourCost where PanelId IN (select PanelId from OtherLabourCost where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    default:
                        OtherLabourCostCost = 0;
                        break;
                }
                return new DamageTwo((int)OtherLabourCostCost, paintingCost, RepairRefitCostCost);
            }
            catch (Exception e)
            { 
                return null;
            }
            return null;
        }
    }
}
