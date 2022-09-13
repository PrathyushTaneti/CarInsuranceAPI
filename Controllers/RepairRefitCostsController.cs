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
    [ApiController]
    [Route("API/[controller]")]
    public class RepairRefitCostsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public RepairRefitCostsController()
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<RepairRefitCost> GetRepairRefitCosts()
        {
            try
            {
                return this.dbContext.Query<RepairRefitCost>("Select * from PartsCost").ToList() ?? new List<RepairRefitCost>();
            }
            catch (Exception e)
            {
                return new List<RepairRefitCost>();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public RepairRefitCost GetRepairRefitCost(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<RepairRefitCost>("Select * from RepairRefitCost where Id = @0", id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public bool PutRepairRefitCost(int id, RepairRefitCost repairRefitCost)
        {
            if (id == repairRefitCost.Id)
            {
                try
                {
                    this.dbContext.Update(repairRefitCost);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        [HttpPost]
        public int PostRepairRefitCost(RepairRefitCost repairRefitCost)
        {
            if (repairRefitCost != null)
            {
                try
                {
                    this.dbContext.Insert(repairRefitCost);
                    return repairRefitCost.Id;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteRepairRefitCost(int id)
        {
            if (this.GetRepairRefitCost(id) != null)
            {
                try
                {
                    this.dbContext.Delete(id);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
