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
    public class CustomerRecordsController : ControllerBase
    {
        private readonly IDatabase dbContext;

        public CustomerRecordsController(EstimationModelDbContext context)
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        // GET: api/CustomerRecords
        [HttpGet]
        public List<CustomerRecord> GetCustomerRecords()
        {
            try
            {
                return this.dbContext.Query<CustomerRecord>("select * from CustomerRecords").ToList() ?? new List<CustomerRecord>();
            }
            catch(Exception e)
            {
                return new List<CustomerRecord>();
            }
        }

        // GET: api/CustomerRecords/5
        [HttpGet("{id}")]
        public CustomerRecord GetCustomerRecord(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<CustomerRecord>("Select * from CustomerRecords where Id = @0", id);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // PUT: api/CustomerRecords/5
        [HttpPut("{id}")]
        public bool PutCustomerRecord(int id, CustomerRecord customerRecord)
        {
            if (id == customerRecord.Id)
            {
                try
                {
                    this.dbContext.Update(customerRecord);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        // POST: api/CustomerRecords
        [HttpPost]
        public int PostCustomerRecord(CustomerRecord customerRecord)
        {
            if (customerRecord != null)
            {
                try
                {
                    this.dbContext.Insert(customerRecord);
                    return customerRecord.Id;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            return -1;
        }

        // DELETE: api/CustomerRecords/5
        [HttpDelete("{id}")]
        public bool DeleteCustomerRecord(int id)
        {
            if (this.GetCustomerRecord(id) != null)
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
