using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageOneController : ControllerBase
    {
        private readonly IDatabase dbContext;
        public DamageOneController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet("{vehicleMake}/{vehicleModel}/{vehicleVariant}/{bodyPart}/{severity}/")]
        public DamageOne GetExpense(string vehicleMake, string vehicleModel, string vehicleVariant, string bodyPart, string severity)
        {
            try
            {
                double otherLabourExpense = 0;
                switch (severity)
                {
                    case "s1":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S1":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).LowSeverity ?? 0;
                        break;

                    case "S2":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "s2":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).MediumSeverity ?? 0;
                        break;

                    case "S3":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    case "s3":
                        otherLabourExpense =  this.dbContext.FirstOrDefault<OtherLabour>("select * from OtherLabour where PanelId IN (select PanelId from OtherLabour where CarBodyPanel = @0)", bodyPart).HighSeverity ?? 0;
                        break;

                    default:
                        return null;
                }

                return new DamageOne((int)otherLabourExpense);
            }
            catch(Exception e)
            {
                return null;
            }
            return null;
        }
    }
}
