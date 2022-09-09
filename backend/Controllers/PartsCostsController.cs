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
    public class PartsCostsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public PartsCostsController(EstimationModelDbContext context)
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        /*[HttpGet]
        public List<PartsCost> GetPartsCosts()
        {
            try
            {
                return this.dbContext.Query<PartsCost>("Select * from PartsCost").ToList() ?? new List<PartsCost>();
            }
            catch (Exception e)
            {
                return new List<PartsCost>();
            }
        }*/

        [HttpGet]
        public List<PartsCostUtil> Get()
        {
            try
            {
                List<PartsCost> partsCostList = this.dbContext.Query<PartsCost>("select distinct BodyPart, BodyPartId from PartsCost").ToList() ?? new List<PartsCost>();

                List<PartsCostUtil> partsCost = new List<PartsCostUtil>();

                foreach(PartsCost part in partsCostList)
                {
                    partsCost.Add(new PartsCostUtil(part.BodyPart, part.BodyPartId));
                }
                return partsCost;
            }
            catch(Exception e)
            {
                return new List<PartsCostUtil>();
            }
        }

        [HttpGet("{id}")]
        public PartsCost GetPartsCost(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<PartsCost>("Select * from PartsCost where Id = @0", id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public bool PutPartsCost(int id, PartsCost partsCost)
        {
            if (id == partsCost.Id)
            {
                try
                {
                    this.dbContext.Update(partsCost);
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
        public int PostPartsCost(PartsCost partsCost)
        {
            if (partsCost != null)
            {
                try
                {
                    this.dbContext.Insert(partsCost);
                    return partsCost.Id;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }

        [HttpDelete("{id}")]
        public bool DeletePartsCost(int id)
        {
            if (this.GetPartsCost(id) != null)
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
