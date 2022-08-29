using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTableController : ControllerBase
    {
        private readonly IDatabase dbContext;
        public CustomerTableController()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        [HttpGet]
        public List<CustomerTable> GetAllCustomerDetails()
        {
            return this.dbContext.Query<CustomerTable>("Select * from [CustomerTable]").ToList() ?? new List<CustomerTable>();
        }

        [HttpGet("{custId}")]
        public CustomerTable GetCustomerDetailById(int custId)
        {
            return this.dbContext.SingleOrDefault<CustomerTable>("Select * from [CustomerTable] where Id = @0", custId);
        }

        [HttpPost]
        public int CreateNewDetail(CustomerTable customerDetail)
        {
            this.dbContext.Insert(customerDetail);
            return customerDetail.Id;
        }

        [HttpPut("{custId}")]
        public bool UpdateCustomerDetail(int custId, CustomerTable customerDetail)
        {
            if (this.GetCustomerDetailById(custId) != null)
            {
                this.dbContext.Update(customerDetail);
                return true;
            }
            return false;
        }

        [HttpDelete("{custId}")]
        public bool DeleteCustomerDetail(int custId)
        {
            if (this.GetCustomerDetailById(custId) != null)
            {
                this.dbContext.Delete<CustomerTable>(custId);
                return true;
            }
            return false;
        }
    }
}
