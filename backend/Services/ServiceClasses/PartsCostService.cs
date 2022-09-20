using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage;
using IDatabase = PetaPoco.IDatabase;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class PartsCostService : ControllerBase, IPartsCostService
    {
        private readonly IDatabase dbContext;
        private readonly DbAccess dbAccess;

        public PartsCostService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<bool> IPartsCostService.DeletePartsCost(int id)
        {
            try
            {
                if (this.IsPartsDetailPresent(id))
                {
                    this.dbContext.Delete<PartsCost>(id);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<PartsCostUtil>> IPartsCostService.Get()
        {
            try
            {
                List<PartsCostUtil> partsCost = new List<PartsCostUtil>();
                foreach (PartsCost part in this.dbContext.Query<PartsCost>("select distinct BodyPart, BodyPartId from PartsCost").ToList() ?? new List<PartsCost>())
                {
                    partsCost.Add(new PartsCostUtil(part.BodyPart!, part.BodyPartId!));
                }
                return partsCost.Count() != 0 ? Ok(new ApiResponse(200, "Success", partsCost)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<PartsCost> IPartsCostService.GetPartsCost(int id)
        {
            try
            {
                PartsCost partCost = this.dbContext.SingleOrDefault<PartsCost>("; exec GetAllDetails @@TableName = 'PartsCost', @@Id = @0", id);
                return partCost != null ? Ok(new ApiResponse(200, "Success", partCost)) : StatusCode(204, new ApiResponse(204, "Error", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<PartsCost>> IPartsCostService.GetPartsCosts()
        {
            try
            {
                List<PartsCost> list = this.dbContext.Query<PartsCost>("; exec GetAllDetails @@TableName = 'PartsCost', @@Id = @0", 0).ToList() ?? new List<PartsCost>();
                return list.Count() != 0 ? Ok(new ApiResponse(200, "Success", list)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<int> IPartsCostService.PostPartsCost(PartsCost partsCost)
        {
            try
            {
                if (partsCost != null)
                {
                    this.dbContext.Insert(partsCost);
                    return Ok(new ApiResponse(200, "Success", partsCost.Id));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content")); ;
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<bool> IPartsCostService.PutPartsCost(int id, PartsCost partsCost)
        {
            try
            {
                if (this.IsPartsDetailPresent(id) && id == partsCost.Id)
                {
                    this.dbContext.Update(partsCost);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", "No Content")); ;
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        private bool IsPartsDetailPresent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return false;
                }
                List<PartsCost> list = this.dbContext.Query<PartsCost>("; exec GetAllDetails @@TableName = 'PartsCost'").ToList() ?? new List<PartsCost>();
                if (list.Count() == 0)
                {
                    return false;
                }
                return list.FirstOrDefault(detail => detail.Id == id) != null ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
