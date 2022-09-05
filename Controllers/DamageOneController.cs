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
                List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@CarBodyPanel = @1", severity, bodyPart) ?? new List<double>();
                double otherLabourExpense = (otherLabourCostList.ToArray().Length != 0) ? otherLabourCostList.ToArray()[0] : 0; 
                return new DamageOne(otherLabourExpense);
            }
            catch (Exception e)
            {
                return new DamageOne(-1);
            }
        }
    }
}
