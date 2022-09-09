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

        [HttpGet]
        public List<CityCodes> GetCities()
        {
            try
            {
                return  this.dbContext.Query<CityCodes>("select distinct * from CityCodes;").ToList() ?? new List<CityCodes>();
            }
            catch (Exception e)
            {
                return new List<CityCodes>();
            }
        }

        [HttpGet("{bodyPartId}/{severity}/{cityName}")]
        public DamageOne GetExpense(int bodyPartId, string severity, string cityName)
        {
            try
            {
                List<double> otherLabourCostList = this.dbContext.Fetch<double>("; exec OtherLabourCostEstimation @@Severity = @0 , @@BodyPartId = @1, @@CityName = @2", severity, bodyPartId, cityName) ?? new List<double>();
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
