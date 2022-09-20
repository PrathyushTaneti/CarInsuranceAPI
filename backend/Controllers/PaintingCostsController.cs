using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeenFieldAPI.Models;
using PetaPoco;
using BeenFieldAPI.DTOClasses;
using BeenFieldAPI.Services.ServiceInterfaces;
using BeenFieldAPI.Utility;

namespace BeenFieldAPI.Controllers
{
    [ApiController]
    [Route(ApiEndPoint.DefaultRoute)]
    public class PaintingCostsController : ControllerBase
    {
        private readonly IPaintingCostService paintingCostService;
        public PaintingCostsController(IPaintingCostService paintingCostService)
        {
            this.paintingCostService = paintingCostService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<PaintingCost>> GetAllPaintingCostDetails()
        {
            return this.paintingCostService.GetPaintingCosts();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<PaintCodesDTO>> GetAllPaintCodes()
        {
            return this.paintingCostService.Get();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<PaintingCost> GetPaintingCostById(int id)
        {
            return this.paintingCostService.GetPaintingCost(id);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<bool> PutPaintingCost(int id, PaintingCost paintingCost)
        {
            return this.paintingCostService.PutPaintingCost(id, paintingCost);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<int> PostPaintingCost(PaintingCost paintingCost)
        {
            return this.paintingCostService.PostPaintingCost(paintingCost);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<bool> DeletePaintingCostById(int id)
        {
            return this.paintingCostService.DeletePaintingCost(id);
        }
    }
}
