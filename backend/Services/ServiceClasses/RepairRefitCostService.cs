using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class RepairRefitCostService : ControllerBase, IRepairRefitCostService
    {
        private readonly IDatabase dbContext;
        private DbAccess dbAccess;
        public RepairRefitCostService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<bool> IRepairRefitCostService.DeleteRepairRefitCost(int id)
        {
            if (this.IsRepairRefitPresent(id))
            {
                try
                {
                    this.dbContext.Delete<RepairRefitCost>(id);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                catch (Exception e)
                {
                    return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
                }
            }
            return false;
        }

        ActionResult<RepairRefitCost> IRepairRefitCostService.GetRepairRefitCost(int id)
        {
            try
            {
                RepairRefitCost repair = this.dbContext.SingleOrDefault<RepairRefitCost>("; exec GetAllDetails @@TableName = 'RepairRefitCost', @@Id = @0", id);
                return repair != null ? Ok(new ApiResponse(200, "Success", repair)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<RepairRefitCost>> IRepairRefitCostService.GetRepairRefitCosts()
        {
            try
            {
                List<RepairRefitCost> list = this.dbContext.Query<RepairRefitCost>("; exec GetAllDetails @@TableName = 'RepairRefitCost', @@Id = @0", 0).ToList() ?? new List<RepairRefitCost>();
                return list.Count != 0 ? Ok(new ApiResponse(200, "Success", list)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<int> IRepairRefitCostService.PostRepairRefitCost(RepairRefitCost repairRefitCost)
        {
            try
            {
                if (repairRefitCost != null)
                {
                    this.dbContext.Insert(repairRefitCost);
                    return Ok(new ApiResponse(200, "Success", repairRefitCost.Id));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<bool> IRepairRefitCostService.PutRepairRefitCost(int id, RepairRefitCost repairRefitCost)
        {
            try
            {
                if (this.IsRepairRefitPresent(id) && id == repairRefitCost.Id)
                {
                    this.dbContext.Update(repairRefitCost);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", true));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        private bool IsRepairRefitPresent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return false;
                }
                List<RepairRefitCost> list = this.dbContext.Query<RepairRefitCost>("; exec GetAllDetails @@TableName = 'RepairRefitCost', @@Id = @0", 0).ToList() ?? new List<RepairRefitCost>();
                return list.SingleOrDefault(detail => detail.Id == id) != null ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
