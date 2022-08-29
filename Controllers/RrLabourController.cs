using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RrLabourController : ControllerBase
    {
        public readonly IDatabase dbContext;
        public RrLabourController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<RrLabour> GetAllDetails()
        {
            return this.dbContext.Query<RrLabour>("Select * from RrLabour").ToList() ?? new List<RrLabour>();
        }

        [HttpGet("{id}")]
        public RrLabour GetDetailsById(int id)
        {
            return this.dbContext.SingleOrDefault<RrLabour>("Select * from RrLabour where Id = @0", id);
        }

        [HttpPost]
        public int CreateNewDetail(RrLabour labour)
        {
            this.dbContext.Insert(labour);
            return labour.Id;
        }

        [HttpPut("{id}")]
        public bool UpdateDetail(int id, RrLabour labour)
        {
            if (this.GetDetailsById(id) != null)
            {
                this.dbContext.Update(labour);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteDetail(int id)
        {
            if (this.GetDetailsById(id) != null)
            {
                this.dbContext.Delete<RrLabour>(id);
                return true;
            }
            return false;
        }
    }
}
