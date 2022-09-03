using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingCostsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public PaintingCostsController(EstimationModelDbContext context)
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        // GET: api/PaintingCosts
        [HttpGet]
        public List<PaintingCost> GetPaintingCosts()
        {
            try
            {
                return this.dbContext.Query<PaintingCost>("Select * from PaintingCost").ToList() ?? new List<PaintingCost>();
            }
            catch(Exception e)
            {
                return new List<PaintingCost>();
            }
        }

        // GET: api/PaintingCosts/5
        [HttpGet("{id}")]
        public PaintingCost GetPaintingCost(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<PaintingCost>("Select * from PaintingCost where Id = @0", id);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // PUT: api/PaintingCosts/5
        [HttpPut("{id}")]
        public bool PutPaintingCost(int id, PaintingCost paintingCost)
        {
            if (id == paintingCost.Id)
            {
                try
                {
                    this.dbContext.Update(paintingCost);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        // POST: api/PaintingCosts
        [HttpPost]
        public int PostPaintingCost(PaintingCost paintingCost)
        {
          if (paintingCost != null)
          {
                try
                {
                    this.dbContext.Insert(paintingCost);
                    return paintingCost.Id;
                }
                catch(Exception e)
                {
                    return -1;
                }
          }
            return -1;
        }

        // DELETE: api/PaintingCosts/5
        [HttpDelete("{id}")]
        public bool DeletePaintingCost(int id)
        {
           if(this.GetPaintingCost(id) != null)
            {
                try
                {
                    this.dbContext.Delete(id);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
