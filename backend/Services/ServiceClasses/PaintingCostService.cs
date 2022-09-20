using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using IDatabase = PetaPoco.IDatabase;

namespace BeenFieldAPI.Services.ServiceClasses
{
    public class PaintingCostService : ControllerBase, IPaintingCostService
    {
        private readonly IDatabase dbContext;
        private readonly DbAccess dbAccess;
        public PaintingCostService()
        {
            this.dbAccess = new DbAccess();
            this.dbContext = this.dbAccess.dbConnection;
        }

        ActionResult<bool> IPaintingCostService.DeletePaintingCost(int id)
        {
            try
            {
                if (this.IsPaintingDetailPresent(id))
                {
                    this.dbContext.Delete<PaintingCost>(id);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(204, new ApiResponse(204, "Success", false));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<PaintCodesDTO>> IPaintingCostService.Get()
        {
            try
            {
                List<PaintCodesDTO> paintCodeList = new();
                foreach (PaintingCost paint in this.dbContext.Query<PaintingCost>("select distinct Paint,PaintId from PaintingCost order by PaintId;").ToList())
                {
                    paintCodeList.Add(new PaintCodesDTO(paint));
                }
                return (paintCodeList.Count != 0) ? Ok(new ApiResponse(200, "Success", paintCodeList)) : StatusCode(204, new ApiResponse(204, "Success", "No Content"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<PaintingCost> IPaintingCostService.GetPaintingCost(int id)
        {
            try
            {
                if (this.IsPaintingDetailPresent(id))
                {
                    PaintingCost paintingCost = this.dbContext.SingleOrDefault<PaintingCost>("; exec GetAllDetails @@TableName = 'PaintingCost', @@Id = @0", id);
                    return Ok(new ApiResponse(200, "Success", paintingCost));
                }
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<List<PaintingCost>> IPaintingCostService.GetPaintingCosts()
        {
            try
            {
                List<PaintingCost> list = this.dbContext.Query<PaintingCost>("; exec GetAllDetails @@TableName = 'PaintingCost', @@Id = @0", 0).ToList() ?? new List<PaintingCost>();
                return (list.Count != 0) ? Ok(new ApiResponse(200, "Success", list)) : StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        ActionResult<int> IPaintingCostService.PostPaintingCost(PaintingCost paintingCost)
        {
            if (paintingCost != null)
            {
                try
                {
                    this.dbContext.Insert(paintingCost);
                    return Ok(new ApiResponse(200, "Success", paintingCost.Id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
                }
            }
            return new BadRequestResult();
        }

        ActionResult<bool> IPaintingCostService.PutPaintingCost(int id, PaintingCost paintingCost)
        {
            try
            {
                if (this.IsPaintingDetailPresent(id) && id == paintingCost.Id)
                {
                    this.dbContext.Update(paintingCost);
                    return Ok(new ApiResponse(200, "Success", true));
                }
                return StatusCode(404, new ApiResponse(404, "Success", false));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ApiResponse(500, "Error", e.StackTrace!));
            }
        }

        private bool IsPaintingDetailPresent(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            List<PaintingCost> list = this.dbContext.Query<PaintingCost>("; exec GetAllDetails @@TableName = 'PaintingCost', @@Id = @0", 0).ToList() ?? new List<PaintingCost>();
            return list.FirstOrDefault(detail => detail.Id == id) != null;
        }
    }
}
