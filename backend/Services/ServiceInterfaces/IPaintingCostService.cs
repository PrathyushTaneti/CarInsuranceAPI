using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeenFieldAPI.Services.ServiceInterfaces
{
    public interface IPaintingCostService
    {
        internal ActionResult<List<PaintingCost>> GetPaintingCosts();

        internal ActionResult<List<PaintCodesDTO>> Get();

        internal ActionResult<PaintingCost> GetPaintingCost(int id);

        internal ActionResult<bool> PutPaintingCost(int id, PaintingCost paintingCost);

        internal ActionResult<int> PostPaintingCost(PaintingCost paintingCost);

        internal ActionResult<bool> DeletePaintingCost(int id);
    }
}
