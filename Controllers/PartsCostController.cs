using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsCostController : ControllerBase
    {
        public readonly IDatabase dbContext;
        public PartsCostController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<PartsCost> GetAllDetails()
        {
            return this.dbContext.Query<PartsCost>("Select * from PartsCost").ToList() ?? new List<PartsCost>();
        }

        [HttpGet("{id}")]
        public PartsCost GetDetailsById(int id)
        {
            return this.dbContext.SingleOrDefault<PartsCost>("Select * from PartsCost where Id = @0", id);
        }

        [HttpPost]
        public int CreateNewDetail(PartsCost part)
        {
            this.dbContext.Insert(part);
            return part.Id;
        }

        [HttpPut("{id}")]
        public bool UpdateNewDetail(int id, PartsCost part)
        {
            if (this.GetDetailsById(id) != null)
            {
                this.dbContext.Update(part);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteDetail(int id)
        {
            if (this.GetDetailsById(id) != null)
            {
                this.dbContext.Delete<PartsCost>(id);
                return true;
            }
            return false;
        }
    }
}
