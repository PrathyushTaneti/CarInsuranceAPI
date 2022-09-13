using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;
using PetaPoco;
using IDatabase = PetaPoco.IDatabase;
using Database = PetaPoco.Database;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class SeverityLevelsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public SeverityLevelsController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<SeverityLevel> Get()
        {
            try
            {
                return this.dbContext.Query<SeverityLevel>("select * from SeverityLevel").ToList() ?? new List<SeverityLevel>();
            }
            catch (Exception e)
            {
                return new List<SeverityLevel>();
            }
        }
    }
}
