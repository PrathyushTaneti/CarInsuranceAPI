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
using BeenFieldAPI.Utility;
using System.Web.Http.Validation;

namespace BeenFieldAPI.Controllers
{    
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class CustomerRecordsController : ControllerBase
    {
        private readonly ICustomerRecordsService customerRecords;
        public CustomerRecordsController(ICustomerRecordsService customerRecords)
        {
            this.customerRecords = customerRecords;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<CustomerRecord>> GetAllCustomerRecords()
        {
            return this.customerRecords.GetAllCustomerRecords();
        }

        [HttpGet]
        [Route("[action]/{id:int:min(1)}")]
        public ActionResult<CustomerRecord> GetCustomerRecordById(int id)
        {
            if(id <= 0 && !ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            return this.customerRecords.GetRecordById(id);
        }

        [HttpPut]
        [Route("[action]/{id:int:min(1)}")]
        public ActionResult<bool> PutCustomerRecord(int id, CustomerRecord customerRecord)
        {
            return this.customerRecords.UpdateRecord(id, customerRecord);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostCustomerRecord(CustomerRecord customerRecord)
        {
            return this.customerRecords.CreateNewDetail(customerRecord);
        }

        [HttpDelete]
        [Route("[action]/{id:int:min(1)}")]
    public ActionResult<bool> DeleteCustomerRecordById(int id)
        {
            return this.customerRecords.DeleteRecord(id);
        }
    }
}
