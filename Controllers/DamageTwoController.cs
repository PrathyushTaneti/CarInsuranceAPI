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
                string vehicleTypeCode =  this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords where VehicleMake = @0", vehicleMake).VehicleTypeCode ?? "";
                string vehicleVariantCode = this.dbContext.FirstOrDefault<VehicleRecord>("Select * from VehicleRecords where VehicleMake = @0 AND VehicleModel = @1 AND VehicleVariant = @2", vehicleMake, vehicleModel, vehicleVariant).VehicleVariantCode ?? "";
                int rRLabourCost = 0;
                int paintingCost  = 0;
                if (vehicleTypeCode != "" && vehicleVariantCode != "")
                {
                    rRLabourCost =  this.dbContext.SingleOrDefault<RrLabour>("Select * from RrLabour where BodyPart = @0 AND VehicleTypeCode = @1",bodyPart, vehicleTypeCode).Expense ?? 0;
                    paintingCost = this.dbContext.SingleOrDefault<PaintingLabour>("Select * from PaintingLabour where PanelDescription = @0 AND VehicleVariantCode = @1", panelDescription, vehicleVariantCode).Expense ?? 0;
                }

                double otherLabourCost = 0;
                switch (severity)
                {
                    case "s1":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select LowSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S1":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select LowSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S2":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select MediumSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "s2":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select MediumSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "S3":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select HighSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    case "s3":
                        otherLabourCost = this.dbContext.FirstOrDefault<OtherLabour>("select HighSeverity from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    default:
                        otherLabourCost = 0;
                        break;
                }

                /*return "Labour Expense : " + otherLabourCost.ToString() + "\nRepair Expense : " + rRLabourCost.ToString() + "\nPainting Expense : " + paintingCost.ToString() + "\nTotal Cost  : "+(otherLabourCost + rRLabourCost + paintingCost).ToString();*/
                return new DamageTwo((int)otherLabourCost, paintingCost, rRLabourCost);
            }
            catch (Exception e)
            {
               /* return -1;*/
                /* return 0;*/
                return null;
            }
            return null;
        }
    }
}
