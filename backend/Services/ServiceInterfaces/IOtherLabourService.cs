using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IOtherLabourService
    {
        internal ActionResult<List<OtherLabourCost>> GetOtherLabourCosts();

        internal ActionResult<OtherLabourCost> GetOtherLabourCost(int id);

        internal ActionResult<bool> PutOtherLabourCost(int id, OtherLabourCost otherLabourCost);

        internal ActionResult<int> PostOtherLabourCost(OtherLabourCost otherLabourCost);

        internal ActionResult<bool> DeleteOtherLabourCost(int id);
    }
}
