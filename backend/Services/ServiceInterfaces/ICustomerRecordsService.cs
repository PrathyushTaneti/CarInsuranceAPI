using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface ICustomerRecordsService
    {
        internal ActionResult<List<CustomerRecord>> GetAllCustomerRecords();

        internal ActionResult<CustomerRecord> GetRecordById(int id);

        internal ActionResult<int> CreateNewDetail(CustomerRecord customerRecord);

        internal ActionResult<bool> UpdateRecord(int id, CustomerRecord customerRecord);

        internal ActionResult<bool> DeleteRecord(int id);
    }
}
