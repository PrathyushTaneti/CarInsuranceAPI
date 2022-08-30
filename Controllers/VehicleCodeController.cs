using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCodeController : ControllerBase
    {
        private readonly IDatabase dbContext;
        public VehicleCodeController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<VehicleRecord> GetAllDetails()
        {
            return this.dbContext.Query<VehicleRecord>("Select * from VehicleRecords").ToList() ?? new List<VehicleRecord>();
        }

        [HttpGet("{id}")]
        public VehicleRecord GetDetailById(int id)
        {
            return this.dbContext.SingleOrDefault<VehicleRecord>("Select * from VehicleRecords where Id = @0", id);
        }

        [HttpGet("vehicleMake")]
        public List<string> GetDetailsByMake(string vehicleMake)
        {
            return this.dbContext.Query<string>("Select concat(VehicleModel,' ',VehicleVariant) from VehicleRecords where VehicleMake = @0", vehicleMake).ToList() ?? new List<string>();
        }

        [HttpGet("vehicleMake/vehicleModel")]
        public List<string> GetDetailsByMakeAndModel(string vehicleMake, string vehicleModel)
        {
            return this.dbContext.Query<string>("Select concat(VehicleModel,' ',VehicleVariant) from VehicleRecords where VehicleMake = @0", vehicleMake).ToList() ?? new List<string>();
        }

        [HttpPost]
        public int CreateDetail(VehicleRecord vehicle)
        {
            this.dbContext.Insert(vehicle);
            return vehicle.Id;
        }

        [HttpPut("{id}")]
        public bool UpdateDetail(int id, VehicleRecord vehicle)
        {
            if (this.GetDetailById(id) != null)
            {
                this.dbContext.Update(vehicle);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteDetail(int id)
        {
            if (this.GetDetailById(id) != null)
            {
                this.dbContext.Delete<VehicleRecord>(id);
                return true;
            }
            return false;
        }
    }
}
