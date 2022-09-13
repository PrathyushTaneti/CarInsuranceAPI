using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.DTOClasses;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class PaintingCostsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public PaintingCostsController(EstimationModelDbContext context)
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<PaintingCost> GetPaintingCosts()
        {
            try
            {
                return this.dbContext.Query<PaintingCost>("Select * from PaintingCost").ToList() ?? new List<PaintingCost>();
            }
            catch (Exception e)
            {
                return new List<PaintingCost>();
            }
        }

        [HttpGet]
        [Route("GetPaintingCodes")]
        public List<PaintCodesDTO> Get()
        {
            try
            {
                List<PaintCodesDTO> paintCodeList = new List<PaintCodesDTO>();
                foreach(PaintingCost paint in this.dbContext.Query<PaintingCost>("select distinct Paint,PaintId from PaintingCost order by PaintId;").ToList())
                {
                    paintCodeList.Add(new PaintCodesDTO(paint));
                }
                return paintCodeList;
            }
            catch(Exception e)
            {
                return new List<PaintCodesDTO>();
            }
        }

        [HttpGet]
        [Route("{id}")]
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

        [HttpPut]
        [Route("{id}")]
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

        [HttpDelete]
        [Route("{id}")]
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
