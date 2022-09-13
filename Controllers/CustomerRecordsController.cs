using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.Services.ServiceInterfaces;

namespace BeenFieldAPI.Controllers
{    
    [ApiController]
    [Route("API/[controller]")]
    public class CustomerRecordsController : ControllerBase
    {
        private readonly ICustomerRecords customerRecords;
        public CustomerRecordsController(ICustomerRecords customerRecords)
        {
            this.customerRecords = customerRecords;
        }

        [HttpGet]
        public List<CustomerRecord> GetCustomerRecords()
        {
            return this.customerRecords.GetAllCustomerRecords();
        }

        [HttpGet]
        [Route("{id}")]
        public CustomerRecord GetCustomerRecord(int id)
        {
            return this.customerRecords.GetRecordById(id);
        }

        [HttpPut]
        [Route("{id}")]
        public bool PutCustomerRecord(int id, CustomerRecord customerRecord)
        {
            return this.customerRecords.UpdateRecord(id, customerRecord);
        }

        [HttpPost]
        public int PostCustomerRecord(CustomerRecord customerRecord)
        {
            return this.customerRecords.CreateNewDetail(customerRecord);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteCustomerRecord(int id)
        {
            return this.customerRecords.DeleteRecord(id);
        }
    }
}
