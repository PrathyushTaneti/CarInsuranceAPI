using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IRepairRefitCostService
    {
        internal ActionResult<List<RepairRefitCost>> GetRepairRefitCosts();

        internal ActionResult<RepairRefitCost> GetRepairRefitCost(int id);

        internal ActionResult<bool> PutRepairRefitCost(int id, RepairRefitCost repairRefitCost);

        internal ActionResult<int> PostRepairRefitCost(RepairRefitCost repairRefitCost);

        internal ActionResult<bool> DeleteRepairRefitCost(int id);
    }
}
