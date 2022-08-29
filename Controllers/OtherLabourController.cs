using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherLabourController : ControllerBase
    {
        private readonly IDatabase dbContext;
        public OtherLabourController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<OtherLabour> GetAllLabourDetails()
        {
            return this.dbContext.Query<OtherLabour>("Select * from OtherLabour").ToList() ?? new List<OtherLabour>();
        }

        [HttpGet("{id}")]
        public OtherLabour GetLabourDetailById(int id)
        {
            return this.dbContext.SingleOrDefault<OtherLabour>("Select * from OtherLabour where Id = @0", id);
        }


        [HttpPost]
        public int CreateLabourDetail(OtherLabour labour)
        {
            this.dbContext.Insert(labour);
            return labour.Id;
        }

        [HttpPut("{id}")]
        public bool UpdateLabourDetail(int id, OtherLabour labour)
        {
            if (this.GetLabourDetailById(id) != null)
            {
                this.dbContext.Update(labour);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteLabourDetail(int id)
        {
            if (this.GetLabourDetailById(id) != null)
            {
                this.dbContext.Delete<OtherLabour>(id);
                return true;
            }
            return false;
        }
    }
}
