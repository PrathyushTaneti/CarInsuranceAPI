using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using PetaPoco;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class CustomerRecords : ICustomerRecords
    {
        private readonly IDatabase dbContext;

        public CustomerRecords()
        {
            this.dbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }
        public int CreateNewDetail(CustomerRecord customerRecord)
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

        public bool DeleteRecord(int id)
        {
            if (this.GetRecordById(id) != null && id >= 0)
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

        public  List<CustomerRecord> GetAllCustomerRecords()
        {
            try
            {
                List<CustomerRecord> customerRecordsList = this.dbContext.Query<CustomerRecord>("select * from CustomerRecords").ToList()
                    ?? new List<CustomerRecord>();
                return  customerRecordsList;
            }
            catch (Exception e)
            {
                return new List<CustomerRecord>();
            }
        }

        public CustomerRecord GetRecordById(int id)
        {
            try
            {
                return this.dbContext.SingleOrDefault<CustomerRecord>("Select * from CustomerRecords where Id = @0", id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateRecord(int id, CustomerRecord customerRecord)
        {
            if (id == customerRecord.Id && this.GetRecordById(id) != null)
            {
                try
                {
                    this.dbContext.Update(customerRecord);
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
