using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class CustomerRecordsService : ControllerBase, ICustomerRecordsService
    {
        private readonly IDatabase dbContext;

        private readonly DbAccess dbAccess;
        public CustomerRecordsService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<int> ICustomerRecordsService.CreateNewDetail(CustomerRecord customerRecord)
        {
            try
            {
                if (customerRecord != null && !IsCustomerDetailPresent(customerRecord.Id))
                {
                    this.dbContext.Insert(customerRecord);
                    return Accepted(new ApiResponse(200, "Success", customerRecord.Id));
                }
                return new BadRequestResult();
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500, "Error", e.StackTrace!.ToString()));
            }
        }

        ActionResult<bool> ICustomerRecordsService.DeleteRecord(int id)
        {
            try
            {
                if (id >= 0 && IsCustomerDetailPresent(id))
                {
                    this.dbContext.Delete<CustomerRecord>(id);
                    return Accepted(true);
                }
                return new NotFoundResult();
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500, "Error", e.StackTrace!.ToString()));
            }
        }

        ActionResult<List<CustomerRecord>> ICustomerRecordsService.GetAllCustomerRecords()
        {
            try
            {
                List<CustomerRecord> customerRecordsList = this.dbContext.Query<CustomerRecord>("; exec GetAllDetails @@TableName = 'CustomerRecord', @@Id = @0", 0).ToList()
                    ?? new List<CustomerRecord>();
                if (customerRecordsList.ToArray().Length == 0)
                {
                    throw new NullReferenceException();
                }
                return Ok(new ApiResponse(200, "Success", customerRecordsList));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500, "Error", e.StackTrace!.ToString()));
            }
        }

        ActionResult<CustomerRecord> ICustomerRecordsService.GetRecordById(int id)
        {
            try
            {
                if (IsCustomerDetailPresent(id) && id > 0)
                {
                    CustomerRecord customer = this.dbContext.FirstOrDefault<CustomerRecord>("; exec GetAllDetails @@TableName = 'CustomerRecord', @@Id = @0", id);
                    return Ok(new ApiResponse(200, "Success", customer));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "Not Found"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500, "Error", e.StackTrace!.ToString()));
            }
        }

        ActionResult<bool> ICustomerRecordsService.UpdateRecord(int id, CustomerRecord customerRecord)
        {
            try
            {
                if (id == customerRecord.Id && IsCustomerDetailPresent(id))
                {
                    this.dbContext.Update(customerRecord);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "ERROR", e.StackTrace!.ToString()));
            }
        }

        private bool IsCustomerDetailPresent(int id)
        {
            try
            {
                if (id > 0)
                {
                    List<CustomerRecord> customerRecordsList = this.dbContext.Query<CustomerRecord>("select * from CustomerRecord").ToList()
                       ?? new List<CustomerRecord>();
                    return (customerRecordsList.FirstOrDefault(customer => customer.Id == id) != null);
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
