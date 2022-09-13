using BeenFieldAPI.Models;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface ICustomerRecords
    {
        public List<CustomerRecord> GetAllCustomerRecords();

        public CustomerRecord GetRecordById(int id);

        public int CreateNewDetail(CustomerRecord customerRecord);

        public bool UpdateRecord(int id, CustomerRecord customerRecord);

        public bool DeleteRecord(int id);

    }
}
