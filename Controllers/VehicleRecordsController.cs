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
    public class VehicleRecordsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public VehicleRecordsController()
        {
            dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        // GET: api/VehicleRecords
        [HttpGet]
        public List<VehicleRecord> GetVehicleRecords()
        {
            try
            {
                return this.dbContext.Query<VehicleRecord>("Select * from VehicleRecords").ToList() ?? new List<VehicleRecord>();
            }
            catch (Exception e)
            {
                return new List<VehicleRecord>();
            }
        }

        // GET: api/VehicleRecords/5
        [HttpGet("{id}")]
        public VehicleRecord GetVehicleRecord(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<VehicleRecord>("Select * from VehicleRecords where Id = @0", id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // PUT: api/VehicleRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool PutVehicleRecord(int id, VehicleRecord vehicleRecord)
        {
            if (id == vehicleRecord.Id)
            {
                try
                {
                    this.dbContext.Update(vehicleRecord);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        // POST: api/VehicleRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public int PostVehicleRecord(VehicleRecord vehicleRecord)
        {
            if (vehicleRecord != null)
            {
                try
                {
                    this.dbContext.Insert(vehicleRecord);
                    return vehicleRecord.Id;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }

        // DELETE: api/VehicleRecords/5
        [HttpDelete("{id}")]
        public bool DeleteVehicleRecord(int id)
        {
            if (this.GetVehicleRecord(id) != null)
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
