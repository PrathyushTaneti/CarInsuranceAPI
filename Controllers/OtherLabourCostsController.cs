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
    public class OtherLabourCostsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public OtherLabourCostsController(EstimationModelDbContext context)
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient"); 
        }

        // GET: api/OtherLabourCosts
        [HttpGet]
        public List<OtherLabourCost> GetOtherLabourCosts()
        {
            try
            {
                return this.dbContext.Query<OtherLabourCost>("Select * from OtherLabourCost").ToList() ?? new List<OtherLabourCost>();
            }
            catch(Exception e)
            {
                return new List<OtherLabourCost>();
            }
        }

        // GET: api/OtherLabourCosts/5
        [HttpGet("{id}")]
        public OtherLabourCost GetOtherLabourCost(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<OtherLabourCost>("Select * from OtherLabourCost where Id = @0", id);
            }
            catch(Exception e)
            {
                return new OtherLabourCost();
            }
        }

        // PUT: api/OtherLabourCosts/5
        [HttpPut("{id}")]
        public bool PutOtherLabourCost(int id, OtherLabourCost otherLabourCost)
        {
            if (id == otherLabourCost.Id)
            {
                try
                {
                    this.dbContext.Update(otherLabourCost);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        // POST: api/OtherLabourCosts
        [HttpPost]
        public int PostOtherLabourCost(OtherLabourCost otherLabourCost)
        {
          if(otherLabourCost != null)
            {
                try
                {
                    this.dbContext.Insert(otherLabourCost);
                    return otherLabourCost.Id;
                }
                catch(Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }

        // DELETE: api/OtherLabourCosts/5
        [HttpDelete("{id}")]
        public bool DeleteOtherLabourCost(int id)
        {
            if(this.GetOtherLabourCost(id) != null)
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
