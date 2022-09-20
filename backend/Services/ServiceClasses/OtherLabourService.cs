using Microsoft.EntityFrameworkCore.Storage;
using IDatabase = PetaPoco.IDatabase;
using Database = PetaPoco.Database;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Models;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class OtherLabourService : ControllerBase, IOtherLabourService
    {
        private readonly IDatabase dbContext;

        private DbAccess dbAccess;

        public OtherLabourService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<bool> IOtherLabourService.DeleteOtherLabourCost(int id)
        {
            try
            {
                if (this.IsLabourServicePresent(id))
                {
                    this.dbContext.Delete<OtherLabourCost>(id);
                    return Ok(true);
                }
                return new NotFoundResult();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

        ActionResult<OtherLabourCost> IOtherLabourService.GetOtherLabourCost(int id)
        {
            try
            {
                if (this.IsLabourServicePresent(id) && id > 0)
                {
                    OtherLabourCost labour = this.dbContext.SingleOrDefault<OtherLabourCost>("; exec GetAllDetails @@TableName = 'OtherLabourCost',@@Id = @0", id);
                    return (labour != null) ? Ok(new ApiResponse(200,"Success",labour)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
                }
                return BadRequest(new ApiResponse(500,"ERROR","Detail Not Found"));
            }
            catch (Exception e)
            {
                return StatusCode(500,new ApiResponse(500,"ERROR",e.StackTrace!.ToString()));
            }
        }

        ActionResult<List<OtherLabourCost>> IOtherLabourService.GetOtherLabourCosts()
        {
            try
            {
                List<OtherLabourCost> list = this.dbContext.Query<OtherLabourCost>("; exec GetAllDetails @@TableName = 'OtherLabourCost',@@Id = @0",0).ToList() ?? new List<OtherLabourCost>();
                return (list.Count() != 0) ? Ok(new ApiResponse(200,"Success",list)) : StatusCode(204,new ApiResponse(204,"Success","No Content"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(500,"Error",e.StackTrace!.ToString()));
            }
        }

        ActionResult<int> IOtherLabourService.PostOtherLabourCost(OtherLabourCost otherLabourCost)
        {
            try
            {
                if (otherLabourCost != null)
                {
                    this.dbContext.Insert(otherLabourCost);
                    return Ok(new ApiResponse(200,"Success", otherLabourCost.Id));
                }
                return new BadRequestResult();
            }
            catch (Exception e)
            {
                return StatusCode(500,new ApiResponse(500,"ERROR",e.StackTrace!.ToString()));
            }
        }

        ActionResult<bool> IOtherLabourService.PutOtherLabourCost(int id, OtherLabourCost otherLabourCost)
        {
            try
            {
                if (id == otherLabourCost.Id && this.IsLabourServicePresent(id))
                {
                    this.dbContext.Update(otherLabourCost);
                    return Ok(new ApiResponse(200,"Success",true));
                }
                return new NotFoundResult();
            }
            catch (Exception e)
            {
                return StatusCode(500,new ApiResponse(500, "ERROR", e.StackTrace!.ToString()));
            }

        }

        private bool IsLabourServicePresent(int id)
        {
            try
            {
                List<OtherLabourCost> otherLabourCostList = this.dbContext.Query<OtherLabourCost>("Select * from OtherLabourCost").ToList() ?? new List<OtherLabourCost>();
                return otherLabourCostList.FirstOrDefault(labour => labour.Id == id) != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
