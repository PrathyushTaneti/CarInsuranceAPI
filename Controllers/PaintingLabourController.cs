using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingLabourController : ControllerBase
    {
        public readonly IDatabase dbContext;
        public PaintingLabourController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<PaintingLabour> GetAllDetails()
        {
            return this.dbContext.Query<PaintingLabour>("Select * from PaintingLabour").ToList() ?? new List<PaintingLabour>();
        }

        [HttpGet("{id}")]
        public PaintingLabour GetDetailById(int id)
        {
            return this.dbContext.SingleOrDefault<PaintingLabour>("Select * from PaintingLabour Where Id = @0", id);
        }

        [HttpPost]
        public int CreateNewDetail(PaintingLabour paintingLabour)
        {
            this.dbContext.Insert(paintingLabour);
            return paintingLabour.Id;
        }

        [HttpPut("{id}")]
        public bool UpdateDetails(int id, PaintingLabour paintingLabour)
        {
            if (this.GetDetailById(id) != null)
            {
                this.dbContext.Update(paintingLabour);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteDetail(int id)
        {
            if (this.GetDetailById(id) != null)
            {
                this.dbContext.Delete<PaintingLabour>(id);
            }
            return false;
        }
    }
}
